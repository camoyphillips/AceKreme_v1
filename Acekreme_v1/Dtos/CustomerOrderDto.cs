namespace AceKreme_v1.Dtos
{
    public class CustomerOrderDto
    {
        public int CustomerOrderId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
    }
}
