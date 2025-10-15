using System.Collections.Generic;
using AceKreme_v1.Dtos;

namespace AceKreme_v1.ViewModels
{
    /// <summary>
    /// ViewModel representing detailed information about a Product
    /// and related Orders or Customers who purchased it.
    /// </summary>
    public class ProductDetailsVM
    {
        /// <summary>
        /// The main product data.
        /// </summary>
        public ProductDto Product { get; set; } = new();

        /// <summary>
        /// List of orders that include this product (if tracked).
        /// </summary>
        public IEnumerable<OrderDto> RelatedOrders { get; set; } = new List<OrderDto>();

        /// <summary>
        /// Optional inventory indicator for the UI.
        /// </summary>
        public string StockStatus =>
            Product.Stock > 20 ? "In Stock" :
            Product.Stock > 0 ? "Low Stock" : "Out of Stock";

        /// <summary>
        /// Total units sold (if calculated from reports).
        /// </summary>
        public int UnitsSold { get; set; }

        /// <summary>
        /// Optional message for display in views.
        /// </summary>
        public string? Message { get; set; }
    }
}
