using EducationPortal.Data;
using EducationPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EducationPortal.Pages.Educations
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Education Education { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Education = await _context.Educations
                .Include(e => e.Category)
                .Include(e => e.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Education == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Education = await _context.Educations.FindAsync(id);

            if (Education != null)
            {
                _context.Educations.Remove(Education);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
