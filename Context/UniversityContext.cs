using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Context
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
        {

        }

        public UniversityContext(DbContextOptions<UniversityContext> opts) : base(opts)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
