using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace University.Models
{
    [Table("Disciplina")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("Requisito")]
        [StringLength(150)]
        [AllowNull]
        public string? Requirement { get; set; }

        [Column("CargaHoraria")]
        [AllowNull]
        public int? Workload { get; set; }

        [Required]
        [Column("Valor")]
        public decimal Cost { get; set; }
    }
}
