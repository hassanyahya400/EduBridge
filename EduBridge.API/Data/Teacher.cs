using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EduBridge.API.Data
{
    [Table("Teachers")]
    public class Teacher : EduBridgeUser
    {
        public string? Rank { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

    }
}

