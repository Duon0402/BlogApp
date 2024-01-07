using BlogApp.DTOs;
using BlogApp.Entities;

namespace BlogApp.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPostDto> CreateBlogPost(BlogPostDto blogPostDto);
        Task<IEnumerable<BlogPost>> GetBlogPosts();
        Task<BlogPost> GetBlogPostById(int id);
    }
}
