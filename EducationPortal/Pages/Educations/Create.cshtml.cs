using EducationPortal.Data;
using EducationPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Pages.Educations
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Education Education { get; set; }

        public List<Category> Categories { get; set; }
        public List<Trainer> Trainers { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();
            Trainers = await _context.Trainers.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the categories and trainers for the dropdowns
                Categories = await _context.Categories.ToListAsync();
                Trainers = await _context.Trainers.ToListAsync();

                // Log the ModelState errors for debugging
                foreach (var entry in ModelState)
                {
                    if (entry.Value.Errors.Count > 0)
                    {
                        foreach (var error in entry.Value.Errors)
                        {
                            System.Diagnostics.Debug.WriteLine($"Key: {entry.Key} Error: {error.ErrorMessage}");
                        }
                    }
                }

                return Page();
            }

            // Only setting foreign key properties from model binding
            // These properties must be set, but the navigation properties will be resolved by EF
            _context.Educations.Add(Education);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
