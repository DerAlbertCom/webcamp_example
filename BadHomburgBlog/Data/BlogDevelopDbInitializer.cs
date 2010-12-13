using System.Data.Entity.Database;
using BadHomburgBlog.DomainModels;
using BadHomburgBlog.Services;

namespace BadHomburgBlog.Data
{
    public class BlogDevelopDbInitializer : DropCreateDatabaseIfModelChanges<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            base.Seed(context);

            var hashing = new Hashing();
            var author = new WebUser {Name = "admin", PasswordHash = hashing.GetHash("admin")};

            var blog = new Blog {
                Title = "Mein Blog!"
            };

            blog.BlogEntries.Add(new BlogEntry {
                Title = "Eintrag 1",
                Author = author,
                Text = "Text 1"
            });
            blog.BlogEntries.Add(new BlogEntry {
                Title = "Eintrag 2",
                Author = author,
                Text = "Text 2"
            });
            blog.BlogEntries.Add(new BlogEntry {
                Title = "Eintrag 3",
                Author = author,
                Text = "Text 3"
            });
            context.Blogs.Add(blog);
            context.SaveChanges();
        }
    }
}