using YellowNotes.Api.Models;

namespace YellowNotes.Api.Interfaces
{
    public interface ITokenService
    {
        void SaveRefreshToken(RefreshTokenModel refreshToken);
        RefreshTokenModel GetRefreshToken(string hashedToken);
        void RemoveRefreshToken(string hashedToken);
        void RemoveExpiredRefreshTokens(string userName);
    }
}