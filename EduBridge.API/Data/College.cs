using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBridge.API.Data
{
        
    public class College
	{
        [Key]
		public int Id { get; set; }

        [Required]
		public string? Name { get; set; }

        public string? ShortName { get; set; }

        public string? Address { get; set; }

        public string? PermanentAddress { get; set; }

        public string? City { get; set; }

        public virtual IList<Department>? Departments { get; }

    }
}