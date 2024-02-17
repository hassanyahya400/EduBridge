using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? OtherNames { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int Level { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}

