using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PatriciaEdgarAndDonEdgar
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "ShowBook",
               url: "Content/Book/{bookname}",
               defaults: new { controller = "Book", action = "ShowBook", bookname = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ShowArticle",
               url: "Content/Article/{articlename}",
               defaults: new { controller = "Article", action = "ShowArticle", articlename = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ShowSpeech",
               url: "Content/Speech/{speechname}",
               defaults: new { controller = "Speech", action = "ShowSpeech", articlename = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "ContactUs",
              url: "Feedback",
              defaults: new { controller = "ContactUs", action = "ContactUs" }
           );

            routes.MapRoute(
               name: "Page",
               url: "{page}",
               defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional }
           );

        }
    }
}