namespace BlogApp.DTOs
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int BlogPostId { get; set; }
        public string UserId { get; set; }
    }
}
