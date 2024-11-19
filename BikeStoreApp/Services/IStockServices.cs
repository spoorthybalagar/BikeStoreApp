using BikeStoreApp.Models;

namespace BikeStoreApp.Services
{
    public interface IStockServices
    {
        // Retrieve all stocks
        Task<IEnumerable<ResponseStockDto>> GetAllStocksAsync();
        Task<ResponseStockDto> GetStockByIdAsync(int storeId, int productId);
        Task<bool> AddStockAsync(CreateStockDto createStockDto);
        Task<bool> UpdateStockAsync(UpdateStockDto updateStockDto);
        Task<bool> DeleteStockAsync(int storeId, int productId);
    }
}

