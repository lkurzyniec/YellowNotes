using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Infrastructure;
using YellowNotes.Api.Interfaces;
using YellowNotes.Dto;

namespace YellowNotes.Api.Providers
{
    public class SimpleRefreshTokenProvider : AuthenticationTokenProvider
    {
        private readonly ITokenService _tokenService;

        public SimpleRefreshTokenProvider(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            string userName = context.Ticket.Identity.FindFirst(ClaimTypes.Name).Value;

            string token = Guid.NewGuid().ToString("n");
            var refreshToken = new RefreshTokenDto
            {
                UserName = userName,
                Token = GetHash(token),
                IssuedDate = DateTime.UtcNow,
                ExpiresDate = DateTime.UtcNow.AddMinutes(5)
            };

            context.Ticket.Properties.IssuedUtc = refreshToken.IssuedDate;
            context.Ticket.Properties.ExpiresUtc = refreshToken.ExpiresDate;

            refreshToken.ProtectedTicket = context.SerializeTicket();

            _tokenService.SaveRefreshToken(refreshToken);
            context.SetToken(token);
        }

        public override async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            
            var token = GetHash(context.Token);

            var refreshToken = _tokenService.GetRefreshToken(token);
            if (refreshToken != null)
            {
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                _tokenService.RemoveRefreshToken(token);
                _tokenService.RemoveExpiredRefreshTokens(refreshToken.UserName);
            }
        }

        private static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
    }
}