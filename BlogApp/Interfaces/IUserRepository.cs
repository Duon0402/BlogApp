using BlogApp.Entities;

namespace BlogApp.Interfaces
{
    public interface IUserRepository 
    {
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserById(string id);
    }
}
