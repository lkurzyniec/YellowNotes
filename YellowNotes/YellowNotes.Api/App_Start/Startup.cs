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
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigureOAuth(app);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(AppConfiguration.AccessTokenExpireTimeInMin),
                Provider = new SimpleAuthorizationServerProvider(new AuthService()),
                RefreshTokenProvider = new SimpleRefreshTokenProvider(new TokenService())
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}