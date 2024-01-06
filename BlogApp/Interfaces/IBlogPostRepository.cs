using BlogApp.DTOs;
using BlogApp.Entities;

namespace BlogApp.Interfaces
{
    public interface IBlogPostRepository
    {
        void CreateBlogPost(BlogPost blogPost);
        void DeleteBlogPost(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetBlogPosts();
        Task<BlogPost> GetBlogPostById(int id);
    }
}
