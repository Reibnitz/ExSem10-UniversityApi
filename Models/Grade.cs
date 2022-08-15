using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("Nota")]
    public class Grade
    {
        public int Id { get; set; }

        [Required]
        [Column("Nota")]
        public decimal Value { get; set; }

        [Required]
        [Column("IdMatricula")]
        [ForeignKey("Registration")]
        public int IdRegistration { get; set; }

        //[Required]
        //[Column("IdAluno")]
        //[ForeignKey("Student")]
        //public int IdStudent { get; set; }

        [Required]
        [Column("IdNotaPeriodo")]
        [ForeignKey("TermGrade")]
        public int IdTermGrade { get; set; }

        public Registration? Registration { get; set; }
        //public Student? Student { get; set; }
        public TermGrade? TermGrade { get; set; }
    }
}
