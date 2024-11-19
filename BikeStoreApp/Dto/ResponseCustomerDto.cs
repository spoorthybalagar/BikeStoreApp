using BikeStoreApp.Models;
using System.ComponentModel.DataAnnotations;

namespace BikeStoreApp.Dto
{
    public class ResponseCustomerDto
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? ZipCode { get; set; }
    }
}
