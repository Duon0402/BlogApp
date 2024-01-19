using AutoMapper;
using BlogApp.DTOs;
using BlogApp.Entities;

namespace BlogApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<BlogPost, CreateBlogPostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
        }
    }
}
