using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TsukuyomiMuseum.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string PhotoUrl { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Day { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        [Column(TypeName = "Decimal(6,2)")]
        public double Price { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Responsable { get; set; }
    }
}
