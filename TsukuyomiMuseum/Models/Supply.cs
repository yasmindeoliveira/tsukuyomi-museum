using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TsukuyomiMuseum.Models
{
    public class Supply
    {
        [Key]
        public int SupplyId { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Day { get; set; }

        [Required]
        [Column(TypeName = "Int")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Supplier { get; set; }

        [Required]
        [Column(TypeName = "Decimal(6,2)")]
        public double Total { get; set; }

        public Product Product { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

    }
}
