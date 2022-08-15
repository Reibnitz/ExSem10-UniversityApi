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
                Name = "Curso1",
                Requirement = "1",
                Workload = 111,
                Cost = 111.11m
            },
            new Course()
            {
                Id = 2,
                Name = "Curso2",
                Requirement = "2",
                Workload = 222,
                Cost = 222.22m
            },
            new Course()
            {
                Id = 3,
                Name = "Curso3",
                Requirement = "3",
                Workload = 333,
                Cost = 333.33m
            },
        };
    }
}
