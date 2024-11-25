using Azure;
using Microsoft.EntityFrameworkCore;
using ProjectTagsAPI.Models;

namespace ProjectTagsAPI.Data
{
    public class ProjectTagsContext : DbContext
    {
        public ProjectTagsContext(DbContextOptions<ProjectTagsContext> options) : base(options) { }

        public DbSet<ProjectData> Projects { get; set; }
        public DbSet<TagData> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Project entity
            modelBuilder.Entity<ProjectData>(entity =>
            {
                entity.HasKey(p => p.ProjectName); // Set ProjectName as the primary key
                entity.Property(p => p.ProjectName).IsRequired(); // Mark as required

                
            });

            // Configure Tag entity
            modelBuilder.Entity<TagData>(entity =>
            {
                entity.HasKey(t => t.TagName); // Set TagName as the primary key
                entity.Property(t => t.TagName).IsRequired(); // Mark as required

                // Configure precision for CuttingTime
                entity.Property(t => t.CuttingTime)
                      .HasPrecision(10, 2); // Precision: 10, Scale: 2
            });
        }
    }
}

