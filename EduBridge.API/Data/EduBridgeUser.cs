using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EduBridge.API.Data
{
	public class EduBridgeUser : IdentityUser
	{
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? OtherNames { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? Gender { get; set; }

    }
}

