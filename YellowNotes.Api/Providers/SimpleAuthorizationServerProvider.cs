using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using YellowNotes.Api.Services;
using YellowNotes.Api.Utils;

namespace YellowNotes.Api.Providers
{
    internal class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService _authService;
        private readonly IClientService _clientService;

        public SimpleAuthorizationServerProvider(IAuthService authService, IClientService clientService)
        {
            _authService = authService;
            _clientService = clientService;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //looking in Authorization header using Basic scheme
            if (!context.TryGetBasicCredentials(out var clientId, out var clientSecret))
            {
                //looking as x-www-form-urlencoded
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (!AuthenticateClient(context, clientId, clientSecret))
            {
                return Task.CompletedTask;
            }

            var deviceId = context.Parameters.Get("device");
            context.OwinContext.Set("device", deviceId);

            context.Validated();
            return Task.CompletedTask;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.CompletedTask;

            string device = context.OwinContext.Get<string>("device");
            if (!ValidateDevice(device))
            {
                context.SetError("invalid_device", "device must be sent");
                return;
            }

            if (!_authService.AuthenticateUser(context.UserName, HashProvider.Get(context.Password), out var user))
            {
                context.SetError("invalid_grant", "user name or password is invalid");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ApiConstants.ClaimDevice, device));

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {"fullname", user.FullName},
                {"as:client_id", context.ClientId},
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_client_id", "refresh_token issued by different client_id");
                return Task.CompletedTask;
            }
            
            var identity = new ClaimsIdentity(context.Ticket.Identity);
            identity.AddClaim(new Claim("newClaim", "someValue"));

            context.Ticket.Properties.Dictionary.Add("newProp", "newValue");

            var ticket = new AuthenticationTicket(identity, context.Ticket.Properties);
            context.Validated(ticket);

            return Task.CompletedTask;
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.CompletedTask;
        }

        private bool AuthenticateClient(OAuthValidateClientAuthenticationContext context, string clientId, string clientSecret)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                context.SetError("invalid_client_id", "client_id must be supplied");
                return false;
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                context.SetError("invalid_client_secret", "client_secret must be supplied");
                return false;
            }

            var client = _clientService.GetClient(clientId);
            if (client == null)
            {
                context.SetError("invalid_client_id", "client_id is invalid");
                return false;
            }

            if (client.Secret != HashProvider.Get(clientSecret))
            {
                context.SetError("invalid_client_secret", "client_secret is invalid");
                return false;
            }

            if (!client.Active)
            {
                context.SetError("invalid_client", "client is inactive");
                return false;
            }

            return true;
        }

        private static bool ValidateDevice(string device)
        {
            return !string.IsNullOrWhiteSpace(device);
        }
    }
}
