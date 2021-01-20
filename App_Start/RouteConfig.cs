using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace navettes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Navette",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Navettes", action = "Create", id = UrlParameter.Optional }
           );
           routes.MapRoute(
               name: "Navette1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Navettes", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Abonnements",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Abonnements", action = "Create", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Abonnements1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Abonnements", action =  "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Stes",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Stes", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Stes1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Stes", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "buses",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "buses", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "buse1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "buses", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Offres",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Offres", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Offres1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Offres", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Demandes",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Demandes", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Demandes1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Demandes", action = "Edit", id = UrlParameter.Optional }
           );
        }
    }
}
