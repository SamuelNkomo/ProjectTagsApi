using Microsoft.AspNetCore.Mvc;
using ProjectTagsAPI.Data;
using ProjectTagsAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTagsAPI.Controllers
{
    [Route("api/projects/{projectId}/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ProjectTagsContext _context;

        public TagController(ProjectTagsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddTag(Guid projectId, [FromBody] Tag tag)
        {
            tag.ProjectID = projectId;
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Tag added successfully!", TagID = tag.TagID });
        }

        [HttpGet]
        public IActionResult GetTags(Guid projectId)
        {
            var tags = _context.Tags.Where(t => t.ProjectID == projectId).ToList();
            return Ok(tags);
        }
    }
}
