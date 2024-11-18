namespace BikeStoreApp.Dto
{
    public class StockDto
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
    }
}
