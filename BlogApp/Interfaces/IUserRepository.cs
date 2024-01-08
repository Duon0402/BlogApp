using BlogApp.Entities;

namespace BlogApp.Interfaces
{
    public interface IUserRepository 
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}
