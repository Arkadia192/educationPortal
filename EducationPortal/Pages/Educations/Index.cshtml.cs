using EducationPortal.Data;
using EducationPortal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Pages.Educations
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Education> Educations { get; set; }

        public async Task OnGetAsync()
        {
            // Fetch all Education records along with their related Category and Trainer
            Educations = await _context.Educations
                .Include(e => e.Category)
                .Include(e => e.Trainer)
                .ToListAsync();
        }
    }
}
