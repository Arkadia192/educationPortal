using EducationPortal.Models;
using EducationPortal.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEducations()
        {
            var educations = await _educationService.GetAllEducationsAsync();
            return Ok(educations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducation(int id)
        {
            var education = await _educationService.GetEducationByIdAsync(id);
            if (education == null) return NotFound();
            return Ok(education);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEducation([FromBody] Education education)
        {
            if (education == null) return BadRequest();
            await _educationService.CreateEducationAsync(education);
            return CreatedAtAction(nameof(GetEducation), new { id = education.Id }, education);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEducation(int id, [FromBody] Education education)
        {
            if (id != education.Id) return BadRequest();
            await _educationService.UpdateEducationAsync(education);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            await _educationService.DeleteEducationAsync(id);
            return NoContent();
        }
    }
}
