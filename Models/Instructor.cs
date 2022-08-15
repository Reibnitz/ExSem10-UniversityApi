using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace University.Models
{
    [Table("Instrutor")]
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Column("Telefone")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Column("ValorHora")]
        [AllowNull]
        public decimal? HourlyPay { get; set; }

        [Column("Certificados")]
        [StringLength(250)]
        [AllowNull]
        public string? Certifications { get; set; }
    }
}
