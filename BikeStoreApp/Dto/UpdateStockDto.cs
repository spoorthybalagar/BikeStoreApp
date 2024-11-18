using System.ComponentModel.DataAnnotations;

namespace BikeStoreApp.Models
{
    public class UpdateStockDto
    {
        [Required]
        public int StoreId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int? Quantity { get; set; }
    }
}

