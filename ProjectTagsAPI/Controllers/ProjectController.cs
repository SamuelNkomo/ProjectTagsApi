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
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectTagsContext _context;

        public ProjectsController(ProjectTagsContext context)
        {
            _context = context;
        }

        // GET api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectData>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET api/projects/{projectName}
        [HttpGet("{projectName}")]
        public async Task<ActionResult<ProjectData>> GetProjectByName(string projectName)
        {
            var project = await _context.Projects.FindAsync(projectName);
            if (project == null)
            {
                return NotFound($"Project with name '{projectName}' not found.");
            }
            return project;
        }

        // POST api/projects
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateProject(ProjectData project)
        {
            if (project == null || string.IsNullOrWhiteSpace(project.ProjectName))
            {
                return BadRequest("ProjectName is required.");
            }

            var existingProject = await _context.Projects.FindAsync(project.ProjectName);
            if (existingProject != null)
            {
                // Update existing project (No additional fields to update here)
            }
            else
            {
                // Add new project
                _context.Projects.Add(project);
            }

            await _context.SaveChangesAsync();
            return Ok(project);
        }
    }
}