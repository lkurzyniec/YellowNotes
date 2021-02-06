using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using YellowNotes.Api.Middlewares;
using YellowNotes.Api.Providers;
using YellowNotes.Api.Services;
using YellowNotes.Api.Utils;

[assembly: OwinStartup(typeof(YellowNotes.Api.Startup))]
namespace YellowNotes.Api
{
    internal class Startup
    {
        /// <remarks>Order of methods invocation has matter</remarks>
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(DependencyConfig.Register);
            GlobalConfiguration.Configuration.EnsureInitialized();

            app.UseCors(CorsProvider.GetCorsOptions());
            UseOAuth(app);

            app.UseCorrelationIdHeaderRewriterMiddleware();

            app.UseWebApi(GlobalConfiguration.Configuration);
        }

        public void UseOAuth(IAppBuilder app)
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
