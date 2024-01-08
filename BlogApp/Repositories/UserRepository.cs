using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Reponsitory
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .SingleOrDefaultAsync();
        }
    }
}
