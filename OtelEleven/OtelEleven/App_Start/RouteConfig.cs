using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OtelEleven
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
                name: "Anasayfa",
                url: "Anasayfa",
                defaults: new { controller = "Ana", action = "Anasayfa", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Kampanyalar",
                url: "Kampanyalar",
                defaults: new { controller = "Ana", action = "Ekstralar", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Etkinlikler",
                url: "Etkinlikler",
                defaults: new { controller = "Ana", action = "Etkinlikler", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Hakkimizda",
                url: "Hakkimizda",
                defaults: new { controller = "Ana", action = "Hakkimizda", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Odalar",
                url: "Odalar",
                defaults: new { controller = "Ana", action = "Odalar", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Rezervasyon",
                url: "Rezervasyon",
                defaults: new { controller = "Ana", action = "Rezervasyon", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Düzenle",
                url: "Düzenle",
                defaults: new { controller = "Manage", action = "Index", id = UrlParameter.Optional }
            ); 
                routes.MapRoute(
                name: "Yorumyap",
                url: "Yorumyap",
                defaults: new { controller = "Ana", action = "Yorumyap", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ana", action = "Intro", id = UrlParameter.Optional }
            );

        }
    }
}
