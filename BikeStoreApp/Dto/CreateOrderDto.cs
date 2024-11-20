//using BikeStoreApp.Models;

//namespace BikeStoreApp.Dto
//{
    //public class CreateOrderDto
    //{
    //    public int? CustomerId { get; set; }
    //    public byte OrderStatus { get; set; }
    //    public DateOnly OrderDate { get; set; }
    //    public DateOnly RequiredDate { get; set; }
    //    public int StoreId { get; set; }
    //    public int StaffId { get; set; }
    //    public List<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();
    //}
    using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

    namespace BikeStoreApp.Dto
    {
        public class CreateOrderDto
        {
            [Required]
            public int CustomerId { get; set; }

            [Required]
            public byte OrderStatus { get; set; }


        [Required]
        [JsonPropertyName("orderDate")]
        public string OrderDateString
        {
            get => OrderDate.ToString("yyyy-MM-dd");
            set => OrderDate = DateOnly.Parse(value);
        }

        [JsonIgnore]
        public DateOnly OrderDate { get; private set; }

        [Required]
        [JsonPropertyName("requiredDate")]
        public string RequiredDateString
        {
            get => RequiredDate.ToString("yyyy-MM-dd");
            set => RequiredDate = DateOnly.Parse(value);
        }

        [JsonIgnore]
        public DateOnly RequiredDate { get; private set; }

        [Required]
            public int StoreId { get; set; }

            [Required]
            public int StaffId { get; set; }

            [Required]
            public List<CreateOrderItemDto> OrderItems { get; set; }
        }

        
    }

