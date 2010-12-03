using System.Collections.Generic;

namespace BadHomburgBlog.DomainModels
{
    public class Blog
    {
        public Blog()
        {
            BlogEntries = new List<BlogEntry>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<BlogEntry> BlogEntries { get; private set; }
    }
}