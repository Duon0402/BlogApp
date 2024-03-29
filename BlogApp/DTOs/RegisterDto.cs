﻿using System.ComponentModel.DataAnnotations;

namespace BlogApp.DTOs
{
    public class RegisterDto
    {
        [Required] public string UserName { get; set; }
        [Required] public string FullName {  get; set; }
        [Required] public string Password { get; set; }
    }
}
