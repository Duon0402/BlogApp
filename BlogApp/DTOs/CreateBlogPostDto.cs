namespace BlogApp.DTOs
{
    public class CreateBlogPostDto
    {
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
