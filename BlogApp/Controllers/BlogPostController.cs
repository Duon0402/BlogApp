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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
            var blogPosts = _blogPostRepository.GetBlogPosts();
            if (blogPosts == null) return NotFound();
            return Ok(blogPosts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
            var blogPost = _blogPostRepository.GetBlogPostById(id);
            if (blogPost == null) return BadRequest("Not Found");
            return Ok(blogPost);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreateBlogPost(BlogPost blogPost)
        {
            if (blogPost == null) return BadRequest("Create Fail");
            if (blogPost.Id == 0 || blogPost.Id == null)
            {
                _blogPostRepository.CreateBlogPost(blogPost);
            }
            return Ok();
        }
    }
}
