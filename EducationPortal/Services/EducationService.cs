using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.Data;
using EducationPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.Services
{
    public class EducationService : IEducationService
    {
        private readonly AppDbContext _context;

        public EducationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Education>> GetAllEducationsAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education> GetEducationByIdAsync(int id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task CreateEducationAsync(Education education)
        {
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEducationAsync(Education education)
        {
            _context.Educations.Update(education);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEducationAsync(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
                await _context.SaveChangesAsync();
            }
        }
    }
}
