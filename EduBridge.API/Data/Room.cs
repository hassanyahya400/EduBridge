﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
    [Table("Room")]
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? ShortName { get; set; }

        [Required]
        public int Capacity { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
