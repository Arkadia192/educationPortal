using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EducationPortal.Data;
using EducationPortal.Models;
using System.Collections.Generic;
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
            Educations = await _context.Educations.Include(e => e.Category).ToListAsync();
        }
    }
}
