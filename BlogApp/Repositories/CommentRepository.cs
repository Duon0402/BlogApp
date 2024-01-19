using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogApp.Data;
using BlogApp.DTOs;
using BlogApp.Entities;
using BlogApp.Helpers;
using BlogApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CommentRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<CreateCommentDto> CreateComment(CreateCommentDto commentDto)
        {
            var cmt = _mapper.Map<Comment>(commentDto);
            await _dataContext.Comments.AddAsync(cmt);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<CreateCommentDto>(cmt);
        }

        public async Task<List<CommentDto>> GetCommentsByBlogPostId(int blogId, string orderBy)
        {
            var query = (from comment in _dataContext.Comments
                               join user in _dataContext.Users on comment.UserId equals user.Id
                               where comment.BlogPostId == blogId
                               select new CommentDto
                               {
                                   UserName = char.ToUpper(user.UserName[0]) + user.UserName.Substring(1),
                                   BlogPostId = blogId,
                                   Content = comment.Content,
                                   CreatedAt = comment.CreatedAt
                               }).AsQueryable();

            query = orderBy switch
            {
                "old" => query.OrderBy(cmt => cmt.CreatedAt),
                "new" => query.OrderByDescending(cmt => cmt.CreatedAt)
            };

            return await query.Select(cmt => new CommentDto
            {
                BlogPostId = blogId,
                CreatedAt = cmt.CreatedAt,
                Content = cmt.Content,
                UserName = cmt.UserName,
            }).ToListAsync();
        }
    }
}
