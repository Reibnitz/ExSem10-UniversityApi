using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("Aluno")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        public string Name {get; set;}

        [Required]
        public string CPF {get; set;}

        [Required]
        public string Email { get; set; }

        [Column("Telefone")]
        [Required]
        public string Phone {get; set;}

        [Column("DataNascimento")]
        public DateTime? Birthday {get; set;}
    }
}
