using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Acekreme_v1.Models;

namespace AceKreme_v1.Models
{
    /// <summary>Represents a registered customer in the AceKreme system.</summary>
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();
    }
}
