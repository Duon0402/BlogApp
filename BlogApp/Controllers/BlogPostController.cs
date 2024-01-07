using AutoMapper;
using BlogApp.DTOs;
using BlogApp.Entities;
using BlogApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogPostController : BaseApiController
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public BlogPostController(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        [HttpGet("GetBlogPosts")]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
            var blogPosts = await _blogPostRepository.GetBlogPosts();
            if (blogPosts == null) return NotFound();
            return Ok(blogPosts);
        }

        [HttpGet("GetBlogPost/{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
            var blogPost = await _blogPostRepository.GetBlogPostById(id);
            if (blogPost == null) return BadRequest("Not Found");
            return  Ok(blogPost);
        }

        [HttpPost("CreateBlogPost")]
        public async Task<ActionResult<BlogPost>> CreateBlogPost(BlogPostDto blogPostDto)
        {
            if (blogPostDto == null) return BadRequest("Invalid Data");
            var newBlogPost = await _blogPostRepository.CreateBlogPost(blogPostDto);
            _mapper.Map<BlogPost>(newBlogPost);
            return Ok(newBlogPost);
        }
    }
}
