﻿using AutoMapper;
using BlogApp.DTOs;
using BlogApp.Entities;

namespace BlogApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<BlogPost, BlogPostDto>();
        }
    }
}
