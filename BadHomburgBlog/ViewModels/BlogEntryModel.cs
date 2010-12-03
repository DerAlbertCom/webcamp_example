using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BadHomburgBlog.ViewModels
{
    public class BlogEntryModel
    {
        public BlogEntryModel()
        {
            Comments = new Collection<CommentModel>();
            Date = DateTime.Today;
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        private string text;

        [DataType(DataType.MultilineText)]
        [Required]
        public string Text
        {
            get { return text ?? string.Empty; }
            set { text = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value.Date; }
        }

        public string AuthorName { get; set; }

        public ICollection<CommentModel> Comments { get; private set; }
    }
}