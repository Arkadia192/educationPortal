// Controllers/EducationController.cs
using EducationPortal.Data;
using EducationPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EducationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetAll()
        {
            return await _context.Educations.Include(e => e.Category).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Education>> CreateEducation(Education education)
        {
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = education.Id }, education);
        }
    }
}
