using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                new
                {
                    Controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(null,
                "Page{page}",
                new
                { Controller = "Product", action = "List", category = (string)null },
                new { Page = @"\d+" }
            );

            routes.MapRoute(null,
                "{Category}",
                new { Controller = "Product", action = "List", page = 1 }
            );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Product", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}"); 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
