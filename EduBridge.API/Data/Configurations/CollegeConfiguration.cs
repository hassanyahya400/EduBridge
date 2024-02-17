using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduBridge.API.Data.Configurations
{
	public class CollegeConfiguration : IEntityTypeConfiguration<College>
	{
		public CollegeConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<College> builder)
        {
            builder.HasData(
                new College
                {
                    Id = 1091430,
                    Name = "Islamic College University",
                    ShortName = "ICU",
                    Address = "Al-Madina Al-munawarah",
                    City = "Al-madina"
                },
                new College
                {
                    Id = 745262,
                    Name = "ACADIP University",
                    ShortName = "ACADIP",
                    Address = "Acadip drive, cairo",
                    City = "Iwo"
                }
                );
        }
    }
}

