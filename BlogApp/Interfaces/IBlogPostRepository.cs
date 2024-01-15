using BlogApp.DTOs;
using BlogApp.Entities;
using BlogApp.Helpers;

namespace BlogApp.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPostDto> CreateBlogPost(BlogPostDto blogPostDto);
        Task<PagedList<BlogPostDto>> GetBlogPosts(BlogPostParams blogPostParams);
        Task<BlogPostDto> GetBlogPostById(int id);
    }
}
