using BlogApp.Data;
using BlogApp.Helpers;
using BlogApp.Interfaces;
using BlogApp.Reponsitory;
using BlogApp.Repositories;
using BlogApp.Services;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Extentions
{
    public static class AplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
