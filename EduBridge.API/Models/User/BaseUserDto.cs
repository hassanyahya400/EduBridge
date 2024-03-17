using System;
using System.ComponentModel.DataAnnotations;

namespace EduBridge.API.Models.User
{
    public abstract class BaseUserDto
	{
        public string? FullName { get; set; }
         
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public int? DepartmentId { get; set; }
    }
}

