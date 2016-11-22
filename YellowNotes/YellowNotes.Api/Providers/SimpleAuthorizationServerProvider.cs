using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using YellowNotes.Api.Interfaces;
using YellowNotes.Dto;

namespace YellowNotes.Api.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService _authService;

        public SimpleAuthorizationServerProvider(IAuthService authService)
        {
            _authService = authService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            
            UserDto user;
            if (!_authService.AuthenticateUser(context.UserName, context.Password, out user))
            {
                context.SetError("invalid_grant", "user name or password is incorrect");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

            context.Validated(identity);
        }
    }
}