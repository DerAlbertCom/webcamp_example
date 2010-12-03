using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BadHomburgBlog.ViewModels
{
    public class BlogModel
    {
        public BlogModel()
        {
            BlogEntries = new Collection<BlogEntryModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<BlogEntryModel> BlogEntries { get; private set; }
    }
}