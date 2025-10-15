using System.Collections.Generic;
using AceKreme_v1.Dtos;

namespace AceKreme_v1.ViewModels
{
    /// <summary>
    /// ViewModel representing a Customer and their related Orders.
    /// Used for detailed customer pages or profile views.
    /// </summary>
    public class CustomerDetailsVM
    {
        /// <summary>
        /// The main customer information.
        /// </summary>
        public CustomerDto Customer { get; set; } = new();

        /// <summary>
        /// All orders placed by this customer.
        /// </summary>
        public IEnumerable<OrderDto> Orders { get; set; } = new List<OrderDto>();

        /// <summary>
        /// Optional calculated field showing total money spent by the customer.
        /// </summary>
        public decimal TotalSpent { get; set; }

        /// <summary>
        /// Optional message for user feedback (e.g., update success/failure).
        /// </summary>
        public string? Message { get; set; }
    }
}
