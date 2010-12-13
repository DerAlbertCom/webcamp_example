using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BadHomburgBlog.Data;
using BadHomburgBlog.DomainModels;
using BadHomburgBlog.ViewModels;

namespace BadHomburgBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            using (var dbContext = new BlogDbContext()){
                var model = dbContext.Blogs.First().MapFrom<Blog, BlogModel>();
                return View(model);
            }
        }

        public ActionResult About()
        {
            var dbContext = new BlogDbContext();
            return View();
        }
    }
}