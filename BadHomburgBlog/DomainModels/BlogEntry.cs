using System;
using System.Collections.Generic;

namespace BadHomburgBlog.DomainModels
{
    public class BlogEntry
    {
        public BlogEntry()
        {
            Comments = new List<Comment>();
            Date = DateTime.Today;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public virtual WebUser Author { get; set; }
        public virtual ICollection<Comment> Comments { get; private set; }
    }
}