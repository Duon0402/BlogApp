using Microsoft.AspNetCore.Identity;

namespace BlogApp.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
