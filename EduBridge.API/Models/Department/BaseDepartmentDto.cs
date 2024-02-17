using System;
using System.ComponentModel.DataAnnotations;

namespace EduBridge.API.Models.Department
{
	public abstract class BaseDepartmentDto
	{
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? ShortName { get; set; }
    }
}

