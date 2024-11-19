using BikeStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStoreApp.Services
{
    public class StockServices:IStockServices
    {
        private readonly BikeStoreAppContext _context;

        public StockServices(BikeStoreAppContext context)
        {
            _context = context;
        }

        // Retrieve all stocks
        public async Task<IEnumerable<ResponseStockDto>> GetAllStocksAsync()
        {
            return await _context.Stocks
                .Include(s => s.Store)
                .Include(s => s.Product)
                .Select(s => new ResponseStockDto
                {
                    StoreId = s.StoreId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    StoreName = s.Store.StoreName,
                    ProductName = s.Product.ProductName
                })
                .ToListAsync();
        }

        // Retrieve stock by StoreId and ProductId
        public async Task<ResponseStockDto?> GetStockByIdAsync(int storeId, int productId)
        {
            var stock = await _context.Stocks
                .Include(s => s.Store)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.StoreId == storeId && s.ProductId == productId);

            if (stock == null)
                return null;

            return new ResponseStockDto
            {
                StoreId = stock.StoreId,
                ProductId = stock.ProductId,
                Quantity = stock.Quantity,
                StoreName = stock.Store.StoreName,
                ProductName = stock.Product.ProductName
            };
        }

        // Add new stock
        public async Task<bool> AddStockAsync(CreateStockDto dto)
        {
            var stock = new Stock
            {
                StoreId = dto.StoreId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return true;
        }

        // Update stock
        public async Task<bool> UpdateStockAsync(UpdateStockDto dto)
        {
            var stock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.StoreId == dto.StoreId && s.ProductId == dto.ProductId);

            if (stock == null)
                return false;

            stock.Quantity = dto.Quantity;
            await _context.SaveChangesAsync();

            return true;
        }

        // Delete stock
        public async Task<bool> DeleteStockAsync(int storeId, int productId)
        {
            var stock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.StoreId == storeId && s.ProductId == productId);

            if (stock == null)
                return false;

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
