using BlogApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.DTOs
{
    public class CommentDto
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int BlogPostId { get; set; }
        public string UserName { get; set; }
    }
}
