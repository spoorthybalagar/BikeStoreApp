using BikeStoreApp.Models;

namespace BikeStoreApp.Services
{
    public interface IStockServices
    {
        // Retrieve all stocks
        Task<IEnumerable<ResponseStockDto>> GetAllStocksAsync();

        // Retrieve stock by StoreId and ProductId
        Task<ResponseStockDto?> GetStockByIdAsync(int storeId, int productId);

        // Add new stock
        Task<bool> AddStockAsync(CreateStockDto dto);

        // Update stock
        Task<bool> UpdateStockAsync(UpdateStockDto dto);

        // Delete stock
        Task<bool> DeleteStockAsync(int storeId, int productId);
    }
}

