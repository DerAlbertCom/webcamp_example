using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using BadHomburgBlog.Data;
using BadHomburgBlog.DomainModels;
using BadHomburgBlog.ViewModels;

namespace BadHomburgBlog.Controllers
{
    public class BlogEntryController : Controller
    {
        //
        // GET: /BlogEntry/

        public ActionResult Show(string date, string title)
        {
            DateTime blogDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            using (var dbContext = new BlogDbContext()){
                var query = from be in dbContext.BlogEntries
                            where be.Title == title &&
                                  be.Date == blogDate
                            select be;
                var model = query.Single().MapFrom<BlogEntry, BlogEntryModel>();
                return View(model);
            }
        }

        [Authorize]
        public ActionResult Create(int id)
        {
            return View(new BlogEntryModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(int id, BlogEntryModel model)
        {
            if (ModelState.IsValid){
                using (var dbContext = new BlogDbContext()){
                    var blog = dbContext.Blogs.Single(b => b.Id == id);
                    var blogEntry = new BlogEntry();
                    blogEntry.Author = GetCurrentWebUser(dbContext);
                    model.MapTo(blogEntry);
                    blog.BlogEntries.Add(blogEntry);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Details", "Blog", new {id = id});
            }
            return View(model);
        }

        private WebUser GetCurrentWebUser(BlogDbContext dbContext)
        {
            return dbContext.Users.Single(u => u.Name == User.Identity.Name);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            using (var dbContext = new BlogDbContext()){
                var model = dbContext.BlogEntries.Single(be => be.Id == id).MapFrom<BlogEntry, BlogEntryModel>();
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, BlogEntryModel model)
        {
            if (ModelState.IsValid){
                using (var dbContext = new BlogDbContext()){
                    var blogEntry = dbContext.BlogEntries.Single(be => be.Id == id);
                    model.MapTo(blogEntry);
                    dbContext.SaveChanges();
                }
                return RedirectToShow(model);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int id, CommentModel model)
        {
            using (var dbContext = new BlogDbContext()){
                var blogEntry = dbContext.BlogEntries.Single(be => be.Id == id);
                if (ModelState.IsValid){
                    var newComment = model.MapFrom<CommentModel, Comment>();
                    blogEntry.Comments.Add(newComment);
                    dbContext.SaveChanges();
                    return RedirectToShow(blogEntry.MapFrom<BlogEntry, BlogEntryModel>());
                }
                return View("Show", blogEntry.MapFrom<BlogEntry, BlogEntryModel>());
            }
        }

        private ActionResult RedirectToShow(BlogEntryModel model)
        {
            return RedirectToAction("Show", new {date = model.Date.ToString("yyyyMMdd"), title = model.Title});
        }
    }
}