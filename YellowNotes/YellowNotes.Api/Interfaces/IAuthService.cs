using YellowNotes.Dto;

namespace YellowNotes.Api.Interfaces
{
    public interface IAuthService
    {
        bool AuthenticateUser(string userName, string password, out UserDto user);
    }
}