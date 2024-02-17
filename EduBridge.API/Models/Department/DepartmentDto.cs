using System;
using System.ComponentModel.DataAnnotations;
using EduBridge.API.Models.Department;

namespace EduBridge.API.Models
{
	public class DepartmentDto : BaseDepartmentDto
	{
        public int Id { get; set; }

        public int CollegeId { get; set; }

    }
}

