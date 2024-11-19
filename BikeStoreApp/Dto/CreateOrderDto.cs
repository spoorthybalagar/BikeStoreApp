using BikeStoreApp.Models;

namespace BikeStoreApp.Dto
{
    public class CreateOrderDto
    {
        public int? CustomerId { get; set; }
        public byte OrderStatus { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly RequiredDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();
    }
}