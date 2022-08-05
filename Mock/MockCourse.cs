using University.Models;

namespace University.Mock
{
    public class MockCourse
    {
        public static List<Course> Courses = new()
        {
            new Course()
            {
                Id = 1,
                IdDegree = 1,
                IdProfessor = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Workload = 111
            },
            new Course()
            {
                Id = 2,
                IdDegree = 2,
                IdProfessor = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Workload = 222
            },
            new Course()
            {
                Id = 3,
                IdDegree = 3,
                IdProfessor = 3,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Workload = 333
            },
        };
    }
}
