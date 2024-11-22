using Microsoft.EntityFrameworkCore;
using ProjectTagsAPI.Models;

namespace ProjectTagsAPI.Data
{
    public class ProjectTagsContext : DbContext
    {
        public ProjectTagsContext(DbContextOptions<ProjectTagsContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure precision and scale for CutTime
            modelBuilder.Entity<Project>()
                .Property(p => p.CutTime)
                .HasPrecision(10, 2); // Precision: 10, Scale: 2
        }
    }
}
