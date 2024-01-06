using AutoMapper;
using BlogApp.Data;
using BlogApp.DTOs;
using BlogApp.Entities;
using BlogApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public BlogPostRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async void CreateBlogPost(BlogPost blogPost)
        {
            var newBlogPost = new BlogPost()
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                CreatedAt = blogPost.CreatedAt
            };

            await _dataContext.BlogPosts.AddAsync(newBlogPost);
        }

        public void DeleteBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPost> GetBlogPostById(int id)
        {
            return await _dataContext.BlogPosts.FindAsync(id);
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            return await _dataContext.BlogPosts.ToListAsync();
        }
    }
}
