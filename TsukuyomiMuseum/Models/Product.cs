using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TsukuyomiMuseum.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string PhotoUrl { get; set; }

        [Required]
        [Column(TypeName = "Decimal(6,2)")]
        public double Price { get; set; }

        [Required]
        [Column(TypeName = "Int")]
        public int Quantity { get; set; }

        public int? Like { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Purchase>? Purchases { get; set; }

        public List<Supply>? Supplies { get; set; }

    }
}
