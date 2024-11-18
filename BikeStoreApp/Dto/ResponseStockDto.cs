namespace BikeStoreApp.Models
{
    public class ResponseStockDto
    {
        public int StoreId { get; set; }

        public int ProductId { get; set; }

        public int? Quantity { get; set; }

        public string StoreName { get; set; } = null!; // Included for better readability in responses

        public string ProductName { get; set; } = null!; // Included for better readability in responses
    }
}

