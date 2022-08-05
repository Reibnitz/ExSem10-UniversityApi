using University.Models;

namespace University.Mock
{
    public class MockStudent
    {
        public static List<Student> Students = new()
        {
            new Student
            {
                Id = 1,
                Birthday = DateTime.Now,
                CPF = "111.222.333-44",
                Email = "student1@email.com",
                Name = "Aluno1",
                Phone = "(11) 1111-1111"
            },
            new Student
            {
                Id = 2,
                Birthday = DateTime.Now,
                CPF = "222.333.444-55",
                Email = "student2@email.com",
                Name = "Aluno2",
                Phone = "(22) 2222-2222"
            },
            new Student
            {
                Id = 3,
                Birthday = DateTime.Now,
                CPF = "333.444.555-66",
                Email = "student3@email.com",
                Name = "Aluno3",
                Phone = "(33) 3333-3333"
            }
        };
    }
}
