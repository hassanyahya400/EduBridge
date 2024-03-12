using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
    [Table("Courses")]
    public class Course
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Unit { get; set; }

        [Required]
        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}