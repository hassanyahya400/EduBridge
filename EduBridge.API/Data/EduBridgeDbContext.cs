using System;
using EduBridge.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduBridge.API.Data
{
	public class EduBridgeDbContext : IdentityDbContext<EduBridgeUser>
	{
		public EduBridgeDbContext(DbContextOptions
            options) : base(options)
		{
          
		}

		public DbSet<College> Colleges { get; set; }

		public DbSet<Course> Courses { get; set; }

		public DbSet<Department> Departments { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CollegeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<Course>().HasIndex(course => new {course.Title, course.Code}).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(course => new { course.Name, course.ShortName }).IsUnique();
        }
    }
}