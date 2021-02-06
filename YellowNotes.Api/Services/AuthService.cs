using System.Collections.Generic;
using YellowNotes.Api.Models;

namespace YellowNotes.Api.Services
{
    internal interface IAuthService
    {
        bool AuthenticateUser(string userName, string password, out UserModel user);
    }

    internal class AuthService : IAuthService
    {
        private static readonly Dictionary<string, UserModel> Users =
            new Dictionary<string, UserModel>
            {
                ["lkurzyniec"] = new UserModel { FirstName = "Łukasz", LastName = "Kurzyniec", UserName = "lkurzyniec", Password = "D7IFNjmsmNjrFNmrJpSxnEQBf9h/LLgUsuOI+fWuyc0=" },  //wieza132
                ["jkowalski"] = new UserModel { FirstName = "Jan", LastName = "Kowalski", UserName = "jkowalski", Password = "7NcYcNGWMxapfjrDQIyYNa2M8PPBvHA1J8MCZVNPda4=" },        //test123
            };

        public bool AuthenticateUser(string userName, string password, out UserModel user)
        {
            if (!Users.TryGetValue(userName, out user))
            {
                return false;
            }

            if (user.Password != password)
            {
                return false;
            }

            return true;
        }
    }
}
