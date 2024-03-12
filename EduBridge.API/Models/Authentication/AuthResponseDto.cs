﻿using System;
namespace EduBridge.API.Models.Authentication
{
	public class AuthResponseDto
    {
        public string? UserId { get; set; }

        public string? Email { get; set; }

        public string? Token { get; set; }

        public string? RefreshToken { get; set; }
    }
}