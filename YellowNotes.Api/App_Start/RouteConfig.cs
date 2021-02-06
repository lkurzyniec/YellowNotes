using System.Web.Mvc;
using System.Web.Routing;

namespace YellowNotes.Api
{
    internal class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Help Area",
                url: "",
                defaults: new { controller = "Help", action = "Index", id = UrlParameter.Optional }
            )
            .DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
        }
    }
}