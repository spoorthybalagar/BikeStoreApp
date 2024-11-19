using BikeStoreApp.Dto;

namespace BikeStoreApp.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<ResponseCustomerDto>> GetAllCustomers();
        Task<ResponseCustomerDto?> GetCustomerById(int customerId);
        Task<ResponseCustomerDto> CreateCustomer(CreateCustomerDto createCustomerDto);
        Task<ResponseCustomerDto?> UpdateCustomer(int customerId, UpdateCustomerDto updateCustomerDto);
        Task<IEnumerable<ResponseCustomerDto>> GetCustomersByCity(string city);
        Task<IEnumerable<ResponseCustomerDto>> GetCustomersByOrderDate(DateTime orderDate);
        Task<ResponseCustomerDto?> UpdateCustomerStreet(int customerId, string street);
        Task<IEnumerable<ResponseCustomerDto>> GetCustomersByZipCode(string zipCode);
        Task<ResponseCustomerDto?> GetCustomerWithHighestOrders();
    }
}

