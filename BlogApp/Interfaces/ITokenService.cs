using BlogApp.Entities;

namespace BlogApp.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
