using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceKreme_v1.Models
{
    /// <summary>Join table between Customer and Order.</summary>
    public class CustomerOrder
    {
        [Key]
        public int CustomerOrderId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [StringLength(50)]
        public string? PaymentMethod { get; set; }

        [StringLength(100)]
        public string? TransactionId { get; set; }
    }
}
