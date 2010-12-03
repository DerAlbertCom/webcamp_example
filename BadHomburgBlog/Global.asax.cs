using System;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using BadHomburgBlog.Data;
using BadHomburgBlog.DomainModels;
using BadHomburgBlog.ViewModels;

namespace BadHomburgBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "show", // Route name
                "{date}/{title}", // URL with parameters
                new {controller = "BlogEntry", action = "Show"}, // Parameter defaults
                new {date = @"\d{8}"}
                );

            routes.MapRoute(
                "admin", // Route name
                "admin/{controller}/{action}/{id}", // URL with parameters
                new {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                } // Parameter defaults
                );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                } // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            DatabaseSetup.Initialize();

            CreateMappings();
        }

        private void CreateMappings()
        {
            Mapper.CreateMap<Blog, BlogModel>();
            Mapper.CreateMap<BlogModel, Blog>();

            Mapper.CreateMap<BlogEntry, BlogEntryModel>();
            Mapper.CreateMap<BlogEntryModel, BlogEntry>();

            Mapper.CreateMap<Comment, CommentModel>();
            Mapper.CreateMap<CommentModel, Comment>();
        }
    }
}