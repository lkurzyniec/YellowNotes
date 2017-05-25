using YellowNotes.Api.Models;
using YellowNotes.Dto;

namespace YellowNotes.Api.Interfaces
{
    internal interface IAuthService
    {
        bool AuthenticateUser(string userName, string password, out UserModel user);
    }
}