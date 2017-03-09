using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
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
            var deviceId = context.Parameters.Get("device");
            context.OwinContext.Set("device", deviceId);

            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string device = context.OwinContext.Get<string>("device");
            if (!ValidateDevice(device))
            {
                context.SetError("invalid_device", "device must be sent");
                return;
            }

            UserDto user;
            if (!_authService.AuthenticateUser(context.UserName, context.Password, out user))
            {
                context.SetError("invalid_grant", "user name or password is incorrect");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ApiConstants.ClaimDevice, device));

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {"fullname", user.FullName}
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
        }

        private static bool ValidateDevice(string device)
        {
            return !string.IsNullOrWhiteSpace(device);
        }
    }
}