using BlogApp.DTOs;
using BlogApp.Entities;

namespace BlogApp.Interfaces
{
    public interface ICommentRepository
    {
        Task<CreateCommentDto> CreateComment(CreateCommentDto commentDto);
        Task<List<CommentDto>> GetCommentsByBlogPostId(int blogId, string orderBy);
    }
}
