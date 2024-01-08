﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogApp.Data;
using BlogApp.DTOs;
using BlogApp.Entities;
using BlogApp.Helpers;
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

        public async Task<PagedList<BlogPostDto>> GetBlogPosts(BlogPostParams blogPostParams)
        {
            var query = _dataContext.BlogPosts.AsQueryable();

            query = blogPostParams.OderBy switch
            {
                "old" => query.OrderBy(bp => bp.CreatedAt),
                _ => query.OrderByDescending(bp => bp.CreatedAt)
            };

            return await PagedList<BlogPostDto>.CreateAsync(query.ProjectTo<BlogPostDto>(_mapper.ConfigurationProvider)
                .AsNoTracking(),
                blogPostParams.PageNumber, blogPostParams.PageSize);
        }
    }
}
