using System;
using System.ComponentModel.DataAnnotations;

namespace EduBridge.API.Models.Department
{
	public class CreateDepartmentDto : BaseDepartmentDto
	{
        [Required]
        public int CollegeId { get; set; }
    }
}

