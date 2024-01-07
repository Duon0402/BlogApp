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

        public async Task<BlogPostDto> CreateBlogPost(BlogPostDto blogPostDto)
        {
            var newBlogPost = _mapper.Map<BlogPost>(blogPostDto);
            _dataContext.BlogPosts.AddAsync(newBlogPost);
            await _dataContext.SaveChangesAsync();
            return blogPostDto;
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
