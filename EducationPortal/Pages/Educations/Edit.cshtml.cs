using EducationPortal.Data;
using EducationPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Pages.Educations
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Education Education { get; set; }
        public List<Category> Categories { get; set; }
        public List<Trainer> Trainers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the Education object along with its related data
            Education = await _context.Educations
                .Include(e => e.Category)
                .Include(e => e.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Education == null)
            {
                return NotFound();
            }

            // Populate categories and trainers for dropdowns
            Categories = await _context.Categories.ToListAsync();
            Trainers = await _context.Trainers.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, repopulate categories and trainers
                Categories = await _context.Categories.ToListAsync();
                Trainers = await _context.Trainers.ToListAsync();
                return Page();
            }

            // Use the ID to retrieve the existing Education entity
            var existingEducation = await _context.Educations.FindAsync(Education.Id);
            if (existingEducation == null)
            {
                return NotFound();
            }

            // Update the properties
            existingEducation.Name = Education.Name;
            existingEducation.CategoryId = Education.CategoryId;
            existingEducation.TrainerId = Education.TrainerId;
            existingEducation.Quota = Education.Quota;
            existingEducation.Cost = Education.Cost;
            existingEducation.DurationDays = Education.DurationDays;

            // Mark the existing entity as modified
            _context.Educations.Update(existingEducation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
