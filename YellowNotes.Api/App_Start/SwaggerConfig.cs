using System.Web.Http;
using WebActivatorEx;
using YellowNotes.Api;
using Swashbuckle.Application;
using System;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace YellowNotes.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "YellowNotes.Api");
                        c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "YellowNotes.Api.xml"));
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("YellowNotes API docs");
                    });
        }
    }
}
