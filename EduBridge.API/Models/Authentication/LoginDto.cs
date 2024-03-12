using System;
using System.ComponentModel.DataAnnotations;

namespace EduBridge.API.Models.Authentication
{
	public class LoginDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; } = null;

		[Required]
		[StringLength(15, ErrorMessage = "Password must be between 5 and 15 characters", MinimumLength = 5)]
		public string Password { get; set; } = null;
    }
}