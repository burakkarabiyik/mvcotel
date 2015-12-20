using System.Web.Mvc;

namespace OtelEleven.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Admin",
                url: "Admin/Admin",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "Slider",
                url: "Admin/Slider",
                defaults: new { controller = "Sliders", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "SliderCreate",
                url: "Admin/Slider/Create",
                defaults: new { controller = "Sliders", action = "Create", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "OdalarCreate",
                url: "Admin/Odalar/Create",
                defaults: new { controller = "Odalars", action = "Create", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "Odalars",
                url: "Admin/Odalars",
                defaults: new { controller = "Odalars", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "kullanicilar",
                url: "Admin/kullanicilar",
                defaults: new { controller = "kullanicilar", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "Etkinliklers",
                url: "Admin/Etkinliklers",
                defaults: new { controller = "Etkinlikler", action = "Index", id = UrlParameter.Optional }

            );
            context.MapRoute(
                name: "EtkinliklerEkle",
                url: "Admin/Etkinlikler/Ekle",
                defaults: new { controller = "Etkinlikler", action = "Create", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "Kampanyalars",
                url: "Admin/Kampanyalars",
                defaults: new { controller = "Kampanyas", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
               name: "Odaolustur",
               url: "Admin/Odaolustur",
               defaults: new { controller = "Odas", action = "Index", id = UrlParameter.Optional }
           );
            context.MapRoute(
                name: "KampanyalarEkle",
                url: "Admin/Kampanyalar/Ekle",
                defaults: new { controller = "kampanyas", action = "Create", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "Rez",
                url: "Admin/Rezervasyondüzenle",
                defaults: new { controller = "Admin", action = "RezervasyonDüzenle", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}