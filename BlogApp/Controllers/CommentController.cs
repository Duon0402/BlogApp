using AutoMapper;
using BlogApp.DTOs;
using BlogApp.Entities;
using BlogApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class CommentController : BaseApiController
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentController(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateComment")]
        public async Task<ActionResult<CreateCommentDto>> CreateBlogPost(CreateCommentDto commentDto)
        {
            if (commentDto == null) return BadRequest("Invalid Data");
            var cmt = await _commentRepository.CreateComment(commentDto);
            _mapper.Map<Comment>(cmt);
            return Ok(cmt);
        }

        [HttpGet("GetCommentsByBlogPostId")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetCommentsByBlogPostId(int blogId, string orderBy)
        {
            var listCmt = await _commentRepository.GetCommentsByBlogPostId(blogId, orderBy);
            return Ok(listCmt);
        }
    }
}
