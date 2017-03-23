using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Infrastructure;
using YellowNotes.Api.Interfaces;
using YellowNotes.Api.Models;
using YellowNotes.Api.Utils;

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
            string userName = context.Ticket.Identity.Name;
            string clientId = context.Ticket.Properties.Dictionary["as:client_id"];

            string token = Guid.NewGuid().ToString("n");
            var refreshToken = new RefreshTokenModel
            {
                ClientId = clientId,
                UserName = userName,
                Token = HashProvider.Get(token),
                ProtectedTicket = context.SerializeTicket(),
                IssuedDate = DateTime.UtcNow,
                ExpiresDate = DateTime.UtcNow.AddMinutes(AppConfiguration.RefreshTokenExpireTimeInMin)
            };
            _tokenService.SaveRefreshToken(refreshToken);

            context.Ticket.Properties.IssuedUtc = refreshToken.IssuedDate;
            context.Ticket.Properties.ExpiresUtc = refreshToken.ExpiresDate;

            context.SetToken(token);
        }

        public override async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var token = HashProvider.Get(context.Token);

            var refreshToken = _tokenService.GetRefreshToken(token);
            if (refreshToken != null)
            {
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                _tokenService.RemoveRefreshToken(token);
                _tokenService.RemoveExpiredRefreshTokens(refreshToken.UserName);
            }
        }
    }
}