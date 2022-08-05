using University.Models;

namespace University.Mock
{
    public class MockProfessor
    {
        public static List<Professor> Professors = new()
        {
            new Professor()
            {
                Id = 1,
                Name = "Professor1",
                Email = "professor1@email.com",
                Phone = "(11) 1111-1111",
                HourlyPay = 111.11,
                Certifications = "Certifications1"
            },
            new Professor()
            {
                Id = 2,
                Name = "Professor2",
                Email = "professor2@email.com",
                Phone = "(22) 2222-2222",
                HourlyPay = 222.22,
                Certifications = "Certifications2"
            },
            new Professor()
            {
                Id = 3,
                Name = "Professor3",
                Email = "professor3@email.com",
                Phone = "(33) 3333-3333",
                HourlyPay = 333.33,
                Certifications = "Certifications3"
            }
        };
    }
}
