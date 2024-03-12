using System;
using System.ComponentModel.DataAnnotations;

namespace EduBridge.API.Models.User
{
    public abstract class BaseUserDto
	{
        public string? Id { get; set; }

        [Required]
        public string? FullName { get; set; }
         
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Gender { get; set; }

        public int DepartmentId { get; set; }
    }
}

