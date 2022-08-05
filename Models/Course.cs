using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("Disciplina")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("IdInstrutor")]
        public int IdProfessor { get; set; }

        [Required]
        [Column("IdCurso")]
        public int IdDegree { get; set; }

        [Column("DataInicio")]
        public DateTime StartDate { get; set; }

        [Column("DataFinal")]
        public DateTime EndDate { get; set; }

        [Column("CargaHoraria")]
        public int Workload { get; set; }
    }
}
