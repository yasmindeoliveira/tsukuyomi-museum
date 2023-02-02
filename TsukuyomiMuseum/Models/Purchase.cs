using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TsukuyomiMuseum.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [Required]
        [Column(TypeName = "Int")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "Decimal(6,2)")]
        public int Total { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}
