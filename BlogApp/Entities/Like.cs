namespace BlogApp.Entities
{
    public class Like
    {
        public int Id { get; set; }

        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
