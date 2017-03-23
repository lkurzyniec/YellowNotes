using System;
using System.Collections.Generic;
using System.Linq;
using YellowNotes.Api.Interfaces;
using YellowNotes.Api.Models;

namespace YellowNotes.Api.Services
{
    public class TokenService : ITokenService
    {
        private static readonly List<RefreshTokenModel> RefreshTokens = new List<RefreshTokenModel>();

        public void SaveRefreshToken(RefreshTokenModel refreshToken)
        {
            RefreshTokens.Add(refreshToken);
        }

        public RefreshTokenModel GetRefreshToken(string hashedToken)
        {
            return RefreshTokens.SingleOrDefault(rt => rt.Token == hashedToken);
        }

        public void RemoveRefreshToken(string hashedToken)
        {
            var token = RefreshTokens.SingleOrDefault(rt => rt.Token == hashedToken);
            if (token != null)
            {
                RefreshTokens.Remove(token);
            }
        }

        public void RemoveExpiredRefreshTokens(string userName)
        {
            var expiredTokens =
                RefreshTokens.Where(x => x.UserName == userName && DateTime.UtcNow >= x.ExpiresDate).ToList();
            foreach (var expiredToken in expiredTokens)
            {
                RefreshTokens.Remove(expiredToken);
            }
        }
    }
}