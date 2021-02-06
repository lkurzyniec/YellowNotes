using System;
using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin.Cors;
using YellowNotes.Api.Utils;

namespace YellowNotes.Api.Providers
{
    internal class CorsProvider
    {
        private static readonly string _allowedOrgins = AppConfiguration.CorsPolicyOrigins;
        private static readonly CorsPolicy _corsPolicy = new CorsPolicy { AllowAnyMethod = true, AllowAnyHeader = true };

        static CorsProvider()
        {
            if (_allowedOrgins == "*")
            {
                _corsPolicy.AllowAnyOrigin = true;
            }
            else
            {
                ValidateOrgins();
            }
        }

        public static CorsOptions GetCorsOptions()
        {
            return new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(_corsPolicy)
                }
            };
        }

        /// <remarks>Based on System.Web.Http.Cors.EnableCorsAttribute.ValidateOrigins()</remarks>
        private static void ValidateOrgins()
        {
            var origins = _allowedOrgins.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var uriString in origins)
            {
                if (!uriString.EndsWith("/") && Uri.IsWellFormedUriString(uriString, UriKind.Absolute))
                {
                    _corsPolicy.Origins.Add(uriString);
                }
            }
        }
    }
}