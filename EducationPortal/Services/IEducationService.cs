using EducationPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Services
{
    public interface IEducationService
    {
        Task<IEnumerable<Education>> GetAllEducationsAsync();
        Task<Education> GetEducationByIdAsync(int id);
        Task CreateEducationAsync(Education education);
        Task UpdateEducationAsync(Education education);
        Task DeleteEducationAsync(int id);
    }
}
