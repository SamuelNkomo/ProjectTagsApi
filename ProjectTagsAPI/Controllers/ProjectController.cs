using Microsoft.AspNetCore.Mvc;
using ProjectTagsAPI.Data;
using ProjectTagsAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTagsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectTagsContext _context;

        public ProjectController(ProjectTagsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Project added successfully!", ProjectID = project.ProjectID });
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(_context.Projects.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(Guid id)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return NotFound();

            return Ok(project);
        }
    }
}
