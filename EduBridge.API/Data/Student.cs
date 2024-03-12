using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
    [Table("Students")]
    public class Student : EduBridgeUser
    {
        public int Level { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}

