using System;
using System.Linq;
using System.Web.Mvc;
using BadHomburgBlog.Data;
using BadHomburgBlog.DomainModels;
using BadHomburgBlog.ViewModels;

namespace BadHomburgBlog.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            using (var dbContext = new BlogDbContext()){
                var model = dbContext.Blogs.MapFrom<Blog, BlogModel>();
                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
            using (var dbContext = new BlogDbContext())
            {
                var model = dbContext.Blogs.Where(b=>b.Id==id).Single().MapFrom<Blog, BlogModel>();
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var dbContext = new BlogDbContext())
            {
                var model = dbContext.Blogs.Where(b => b.Id == id).Single().MapFrom<Blog, BlogModel>();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, BlogModel model)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new BlogDbContext()){
                    var entity = dbContext.Blogs.Single(bm => bm.Id == id);
                    model.MapTo(entity);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new BlogModel());
        }

        [HttpPost]
        public ActionResult Create(BlogModel model)
        {
            if (ModelState.IsValid){
                using (var dbContext= new BlogDbContext()){
                    var entity = model.MapFrom<BlogModel, Blog>();
                    dbContext.Blogs.Add(entity);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

    }
}