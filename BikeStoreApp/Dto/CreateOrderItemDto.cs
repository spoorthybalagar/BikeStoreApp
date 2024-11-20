using System.ComponentModel.DataAnnotations;

namespace BikeStoreApp.Dto
{
    //public class CreateOrderItemDto
    //{
    //    public int ProductId { get; set; }
    //    public int Quantity { get; set; }
    //    public decimal ListPrice { get; set; }
    //    public decimal Discount { get; set; }
    //}
    public class CreateOrderItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal ListPrice { get; set; }

        [Required]
        public float Discount { get; set; }
    }
}
