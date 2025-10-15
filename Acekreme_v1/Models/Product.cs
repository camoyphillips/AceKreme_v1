using System.ComponentModel.DataAnnotations;

namespace AceKreme_v1.Models
{
    /// <summary>Represents a product for sale (e.g., bed, mattress).</summary>
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int Stock { get; set; }

        public string? ProductImagePath { get; set; }
    }
}
