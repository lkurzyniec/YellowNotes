using YellowNotes.Dto;

namespace YellowNotes.Api.Interfaces
{
    public interface ITokenService
    {
        void SaveRefreshToken(RefreshTokenDto refreshToken);
        RefreshTokenDto GetRefreshToken(string hashedToken);
        void RemoveRefreshToken(string hashedToken);
        void RemoveExpiredRefreshTokens(string userName);
    }
}