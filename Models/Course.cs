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
        [Column("Nome")]
        public string Name { get; set; }

        [Column("Requisito")]
        public string Requisite { get; set; }

        [Column("CargaHoraria")]
        public int Workload { get; set; }

        [Required]
        [Column("Valor")]
        public double Cost { get; set; }
    }
}
