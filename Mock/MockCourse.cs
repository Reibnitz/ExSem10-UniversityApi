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
                Requisite = "1",
                Workload = 111,
                Cost = 111.11
            },
            new Course()
            {
                Id = 2,
                Name = "Curso2",
                Requisite = "2",
                Workload = 222,
                Cost = 222.22
            },
            new Course()
            {
                Id = 3,
                Name = "Curso3",
                Requisite = "3",
                Workload = 333,
                Cost = 333.33
            },
        };
    }
}
