using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTagsAPI.Models
{
    public class ProjectData
    {
        public required string ProjectName { get; set; } // Unique Identifier
    }
}
