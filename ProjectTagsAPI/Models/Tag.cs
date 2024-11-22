using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTagsAPI.Models
{
    public class Tag
    {
        [Key]
        public Guid TagID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ProjectID { get; set; }

        [Required]
        [MaxLength(255)]
        public required string TagName { get; set; }
    }
}
