using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
    [Table("Course")]
    public class Course
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        public string? Title { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
