using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapMvcAttributeRoutes();


            routes.MapRoute("Default", "{*url}", new { controller = "Home", action = "Index", url = UrlParameter.Optional });
        }
    }
}
