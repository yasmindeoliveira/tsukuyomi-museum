using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TsukuyomiMuseum.Models
{
    public class Publication
    {
        [Key]
        public int PublicationId { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string PhotoUrl { get; set; }

        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Description { get; set; }
    }
}
