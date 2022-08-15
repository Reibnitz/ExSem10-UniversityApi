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
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TermGrade> TermGrades { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
