namespace BikeStoreApp.Dto
{
    public class UpdateOrderDto
    {
        public byte? OrderStatus { get; set; }
        public DateOnly? RequiredDate { get; set; }
        public DateOnly? ShippedDate { get; set; }
        public int? StoreId { get; set; }
        public int? StaffId { get; set; }
        public List<UpdateOrderItemDto> OrderItems { get; set; } = new List<UpdateOrderItemDto>();
    }

}
