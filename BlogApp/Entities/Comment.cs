using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public string UserId { get; set; }
    }
}
