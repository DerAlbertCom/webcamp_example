using System;
using System.Data.Entity;
using System.Web;
using BadHomburgBlog.DomainModels;

namespace BadHomburgBlog.Data
{
    /// Package für Datenbank:     EFCTP4
    /// Package für Mapper :         Automapper
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() : base(GetConnectionString())
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        private static string GetConnectionString()
        {
            var filename = HttpContext.Current.Server.MapPath("~/App_Data/Blog.sdf");
            return string.Format("Data Source={0}", filename);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<WebUser> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}