using System.Collections.Generic;
using YellowNotes.Api.Interfaces;
using YellowNotes.Dto;

namespace YellowNotes.Api.Services
{
    public class AuthService : IAuthService
    {
        private static readonly Dictionary<string, UserDto> Users =
            new Dictionary<string, UserDto>
            {
                ["lkurzyniec"] = new UserDto { FirstName = "Łukasz", LastName = "Kurzyniec", UserName = "lkurzyniec", Password = "D7IFNjmsmNjrFNmrJpSxnEQBf9h/LLgUsuOI+fWuyc0=" },  //wieza132
                ["jkowalski"] = new UserDto { FirstName = "Jan", LastName = "Kowalski", UserName = "jkowalski", Password = "7NcYcNGWMxapfjrDQIyYNa2M8PPBvHA1J8MCZVNPda4=" },        //test123
            };

        public bool AuthenticateUser(string userName, string password, out UserDto user)
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