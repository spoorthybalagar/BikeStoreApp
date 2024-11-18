namespace BikeStoreApp.Dto
{
    public class ResponseOrderItemDto
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty; // Assuming Product has a Name property
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice => Quantity * (ListPrice - Discount);
    }

}
