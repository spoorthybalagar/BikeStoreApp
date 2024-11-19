using System;

namespace BikeStoreApp.DTOs
{
    public class StaffDto
    {
        public int StaffId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public bool Active { get; set; }

        public int StoreId { get; set; }

        public int? ManagerId { get; set; }

        public string? ManagerName { get; set; } // Optional: Combine Manager's first and last name

        public string StoreName { get; set; } = null!; // Assuming Store name is important

        // You can include additional fields as needed, or flatten nested objects for ease of use.
    }
}
