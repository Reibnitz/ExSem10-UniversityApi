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
        [StringLength(50)]
        public string Name {get; set;}

        [Required]
        [StringLength(18)]
        public string CPF {get; set;}

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("Telefone")]
        [Required]
        [StringLength(15)]
        public string Phone {get; set;}

        [Column("DataNascimento")]
        public DateTime? Birthday {get; set;}
    }
}
