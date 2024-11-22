using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTagsAPI.Models
{
    public class Project
    {
        [Key]
        public Guid ProjectID { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal CutTime { get; set; }
    }
}
