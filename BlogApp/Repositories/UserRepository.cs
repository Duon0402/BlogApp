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

        public async Task<User> GetUserById(string id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .SingleOrDefaultAsync();
        }

    }
}
