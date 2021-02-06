﻿using System.Web.Http;
using YellowNotes.Api.Attributes;

namespace YellowNotes.Api
{
    internal static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new CheckModelForNullAttribute());
            config.Filters.Add(new SimpleAuthorizeAttribute());
            config.Filters.Add(new RequestExceptionAttribute());

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
