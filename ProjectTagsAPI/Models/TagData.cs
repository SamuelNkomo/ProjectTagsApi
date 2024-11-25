using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectTagsAPI.Models
{
    public class TagData
    {
        public required string TagName { get; set; } // Unique Identifier
        public decimal CuttingTime { get; set; }
    }
}