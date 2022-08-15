using University.Models;

namespace University.Mock
{
    public class MockProfessor
    {
        public static List<Instructor> Professors = new()
        {
            new Instructor()
            {
                Id = 1,
                Name = "Professor1",
                Email = "professor1@email.com",
                Phone = "(11) 1111-1111",
                HourlyPay = 111.11m,
                Certifications = "Certifications1"
            },
            new Instructor()
            {
                Id = 2,
                Name = "Professor2",
                Email = "professor2@email.com",
                Phone = "(22) 2222-2222",
                HourlyPay = 222.22m,
                Certifications = "Certifications2"
            },
            new Instructor()
            {
                Id = 3,
                Name = "Professor3",
                Email = "professor3@email.com",
                Phone = "(33) 3333-3333",
                HourlyPay = 333.33m,
                Certifications = "Certifications3"
            }
        };
    }
}
