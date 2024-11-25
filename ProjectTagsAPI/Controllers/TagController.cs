using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTagsAPI.Data;
using ProjectTagsAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTagsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ProjectTagsContext _context;

        public TagsController(ProjectTagsContext context)
        {
            _context = context;
        }

        // GET api/tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagData>>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        // GET api/tags/{tagName}
        [HttpGet("{tagName}")]
        public async Task<ActionResult<TagData>> GetTagByName(string tagName)
        {
            var tag = await _context.Tags.FindAsync(tagName);
            if (tag == null)
            {
                return NotFound($"Tag with name '{tagName}' not found.");
            }
            return tag;
        }

        // POST api/tags
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateTag(TagData tag)
        {
            if (tag == null || string.IsNullOrWhiteSpace(tag.TagName))
            {
                return BadRequest("TagName is required.");
            }

            var existingTag = await _context.Tags.FindAsync(tag.TagName);
            if (existingTag != null)
            {
                // Update existing tag
                existingTag.CuttingTime = tag.CuttingTime;
            }
            else
            {
                // Add new tag
                _context.Tags.Add(tag);
            }

            await _context.SaveChangesAsync();
            return Ok(tag);
        }
    }
}