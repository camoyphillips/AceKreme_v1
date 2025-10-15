using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AceKreme_v1.Models;

namespace AceKreme_v1.Models
{
    /// <summary>Represents a customer's order transaction.</summary>
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal TotalAmount { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; } = "Pending";

        public ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();
    }
}
