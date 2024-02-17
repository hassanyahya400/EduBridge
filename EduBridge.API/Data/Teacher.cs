using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? OtherNames { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Rank { get; set; }

        public DateTime DateOfBirth { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}

