using System;
using System.ComponentModel.DataAnnotations;

namespace EduBridge.API.Models.Authentication
{
	public class  EduBridgeUserDto : LoginDto
	{
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? Gender { get; set; }

        public int DepartmentId { get; set; }
    }
}

