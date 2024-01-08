using AutoMapper;
using BlogApp.DTOs;
using BlogApp.Entities;
using BlogApp.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, 
            ITokenService tokenService, IMapper mapper )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await UserExists(registerDto.UserName)) return BadRequest("Username is taken");

            var newUser = _mapper.Map<User>(registerDto);

            newUser.UserName = registerDto.UserName.ToLower();
            
            var result = await _userManager.CreateAsync(newUser, registerDto.Password);

            if(!result.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                UserName = registerDto.UserName,
                FullName = registerDto.UserName,
                Token = await _tokenService.CreateToken(newUser),
            };
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.UserName)) return BadRequest("Please enter a Username");
            if (string.IsNullOrEmpty(loginDto.Password)) return BadRequest("Please enter a Password");

            var user = await _userManager.Users
                .SingleOrDefaultAsync(u => u.UserName == loginDto.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid Username");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Invalid Password");

            return new UserDto
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Token = await _tokenService.CreateToken(user),
            };
        }

        private async Task<bool> UserExists(string userName)
        {
            return await _userManager.Users.AnyAsync(u => u.UserName == userName.ToLower());
        }
    }
}
