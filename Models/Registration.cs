using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("Matricula")]
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        [Column("IdTurma")]
        [ForeignKey("Team")]
        public int IdTeam { get; set; }

        [Required]
        [Column("IdAluno")]
        [ForeignKey("Student")]
        public int IdStudent { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public Team? Team { get; set; }
        public Student? Student { get; set; }
    }
}
