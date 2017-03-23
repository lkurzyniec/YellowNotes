using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using YellowNotes.Api.Providers;
using YellowNotes.Api.Services;
using YellowNotes.Api.Utils;

[assembly: OwinStartup(typeof(YellowNotes.Api.Startup))]
namespace YellowNotes.Api
{
    public class Startup
    {
        /// <remarks>Order of methods invocation has matter</remarks>
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            app.UseCors(CorsProvider.GetCorsOptions());
            ConfigureOAuth(app);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(AppConfiguration.AccessTokenExpireTimeInMin),
                Provider = new SimpleAuthorizationServerProvider(new AuthService(), new ClientService()),
                RefreshTokenProvider = new SimpleRefreshTokenProvider(new TokenService())
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}