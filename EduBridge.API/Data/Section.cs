using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
    [Table("Sections")]
    public class Section
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        [Required]
        public int TeacherId { get; set; }

        public virtual IList<Student>? Students { get; }
    }
}

