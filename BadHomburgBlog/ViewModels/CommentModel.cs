using System.ComponentModel.DataAnnotations;

namespace BadHomburgBlog.ViewModels
{
    public class CommentModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
    }
}