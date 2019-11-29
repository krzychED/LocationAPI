using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LocationProcessAPI.Configuration
{
    public class LocationProcessAPIConfig
    {
        public static string configFilePath = "C:\\Users\\krzyc\\myProject\\LocationProcessAPI\\LocationProcessAPI\\Configuration\\Gateway.config";

        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "LocationApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}