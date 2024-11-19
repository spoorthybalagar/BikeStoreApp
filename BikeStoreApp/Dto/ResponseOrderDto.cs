namespace BikeStoreApp.Dto
{
    public class ResponseOrderDto
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; } // Optional, fetched via navigation property
        public byte OrderStatus { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly RequiredDate { get; set; }
        public DateOnly? ShippedDate { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; } // Optional, fetched via navigation property
        public int StaffId { get; set; }
        public string StaffName { get; set; } // Optional, fetched via navigation property
        public List<ResponseOrderItemDto> OrderItems { get; set; } = new List<ResponseOrderItemDto>();
    }

}
