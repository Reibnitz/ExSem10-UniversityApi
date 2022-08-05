using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("Instrutor")]
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Column("Telefone")]
        public string Phone { get; set; }

        [Column("ValorHora")]
        public double HourlyPay { get; set; }

        [Column("Certificados")]
        public string Certifications { get; set; }
    }
}
