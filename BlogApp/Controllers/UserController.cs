using AutoMapper;
using BlogApp.Entities;
using BlogApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            return await _userRepository.GetUserById(id);
        }

        [HttpGet("GetUserByUsername/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }
    }
}
