using Microsoft.EntityFrameworkCore;
using EducationPortal.Models;
using System.Collections.Generic;

namespace EducationPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
    }
}
