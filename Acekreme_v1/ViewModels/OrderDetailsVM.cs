using System.Collections.Generic;
using AceKreme_v1.Dtos;

namespace AceKreme_v1.ViewModels
{
    /// <summary>
    /// ViewModel representing an Order and all related entities.
    /// </summary>
    public class OrderDetailsVM
    {
        /// <summary>
        /// The main order details.
        /// </summary>
        public OrderDto Order { get; set; } = new();

        /// <summary>
        /// The customer who placed this order.
        /// </summary>
        public CustomerDto? Customer { get; set; }

        /// <summary>
        /// List of products associated with this order.
        /// </summary>
        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();

        /// <summary>
        /// Optional calculated subtotal (sum of product prices).
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Any discounts applied to the order.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Grand total after discounts.
        /// </summary>
        public decimal Total => Subtotal - Discount;

        /// <summary>
        /// Optional order status message for the view.
        /// </summary>
        public string? Message { get; set; }
    }
}
