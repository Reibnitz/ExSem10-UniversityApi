using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("Turma")]
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [Column("IdInstrutor")]
        [ForeignKey("Instructor")]
        public int IdInstructor { get; set; }

        [Required]
        [Column("IdCurso")]
        [ForeignKey("Course")]
        public int IdCourse { get; set; }

        [Column("DataInicio")]
        public DateTime? StartDate { get; set; }

        [Column("DataFinal")]
        public DateTime? EndDate { get; set; }

        [Column("CargaHoraria")]
        public int? Workload { get; set; }


        //Nome da propriedade precisa ser o mesmo do Data Annotation 'ForeigKey'
        //Propriedade precisa ser nullable '?'
        public Instructor? Instructor { get; set; }
        public Course? Course { get; set; }
    }
}
