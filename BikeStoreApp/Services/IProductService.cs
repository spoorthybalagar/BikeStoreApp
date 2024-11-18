using BikeStoreApp.Dto;

namespace BikeStoreApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductDto productDto);
        Task UpdateProductAsync(int id, ProductDto productDto);
        Task UpdateProductPartialAsync(int id, ProductDto productDto);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryNameAsync(string categoryName);
        Task<IEnumerable<ProductDto>> GetProductsByBrandNameAsync(string brandName);
        Task<IEnumerable<ProductDto>> GetProductsByModelYearAsync(short modelYear);
        Task<IEnumerable<ProductDto>> GetNumberOfProductsSoldByEachStoreAsync();
        Task<IEnumerable<ProductDto>> GetProductDetailsAsync();
        Task<IEnumerable<ProductDto>> GetProductsPurchasedByCustomerAsync(int customerId);
        Task<IEnumerable<ProductDto>> GetProductPurchasedByMaxCustomerAsync();
        Task<IEnumerable<ProductDto>> GetProductsWithMinimumStockAsync();
    }
}
