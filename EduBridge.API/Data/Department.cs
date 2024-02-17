using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
    [Table("Department")]
    public class Department
	{
        [Key]
        public int Id { get; set; }

        [Required]
		public string? Name { get; set; }

        [Required]
		public string? ShortName { get; set; }

        public virtual IList<Teacher>? Teachers { get; set; }

        public virtual IList<Student>? Students { get; set; }

        public virtual IList<Course>? Courses { get; set; }

        public virtual IList<Room>? Rooms { get; set; }

        [ForeignKey(nameof(CollegeId))]
        public int CollegeId { get; set; }

        public College? College { get; set; }
    }
}

	