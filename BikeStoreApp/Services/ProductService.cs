using BikeStoreApp.Dto;
using BikeStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStoreApp.Services
{
    public class ProductService : IProductService
    {
        private readonly BikeStoreAppContext _context;

        public ProductService(BikeStoreAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    ModelYear = p.ModelYear,
                    ListPrice = p.ListPrice
                })
                .ToListAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product != null ? new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelYear = product.ModelYear,
                ListPrice = product.ListPrice
            } : null;
        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                ModelYear = productDto.ModelYear,
                ListPrice = productDto.ListPrice
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.ProductName = productDto.ProductName;
                product.BrandId = productDto.BrandId;
                product.CategoryId = productDto.CategoryId;
                product.ModelYear = productDto.ModelYear;
                product.ListPrice = productDto.ListPrice;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProductPartialAsync(int id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(productDto.ProductName))
                    product.ProductName = productDto.ProductName;

                if (productDto.BrandId > 0)
                    product.BrandId = productDto.BrandId;

                if (productDto.CategoryId > 0)
                    product.CategoryId = productDto.CategoryId;

                if (productDto.ModelYear > 0)
                    product.ModelYear = productDto.ModelYear;

                if (productDto.ListPrice >= 0)
                    product.ListPrice = productDto.ListPrice;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryNameAsync(string categoryName)
        {
            return await _context.Products
                .Where(p => p.Category.CategoryName == categoryName)
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    ModelYear = p.ModelYear,
                    ListPrice = p.ListPrice
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByBrandNameAsync(string brandName)
        {
            return await _context.Products
                .Where(p => p.Brand.BrandName == brandName)
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    ModelYear = p.ModelYear,
                    ListPrice = p.ListPrice
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByModelYearAsync(short modelYear)
        {
            return await _context.Products
                .Where(p => p.ModelYear == modelYear)
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    ModelYear = p.ModelYear,
                    ListPrice = p.ListPrice
                })
                .ToListAsync();
        }

       public async Task<IEnumerable<ProductDto>> GetNumberOfProductsSoldByEachStoreAsync()
{
    // Assuming Order has a StoreId property and OrderItems has a ProductId and Quantity property
    return await _context.Orders
        .Include(o => o.OrderItems) // Ensure that OrderItems are included
        .GroupBy(o => o.StoreId) // Grouping by StoreId
        .Select(g => new ProductDto
        {
            ProductId = g.Key, // StoreId
            ProductName = _context.Stores.FirstOrDefault(s => s.StoreId == g.Key)?.StoreName, // Get StoreName from Stores
            ListPrice = g.Sum(o => o.OrderItems.Sum(oi => oi.Quantity)) // Summing the quantities sold for all products in the store
        })
        .ToListAsync();
}
        public async Task<IEnumerable<ProductDto>> GetProductDetailsAsync()
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    ModelYear = p.ModelYear,
                    ListPrice = p.ListPrice,
                    // Add any additional details you want to include
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsPurchasedByCustomerAsync(int customerId)
        {
            return await _context.OrderDetails
                .Where(od => od.CustomerId == customerId) // Assuming OrderDetails has a CustomerId property
                .Select(od => new ProductDto
                {
                    ProductId = od.ProductId,
                    ProductName = _context.Products.FirstOrDefault(p => p.ProductId == od.ProductId)?.ProductName,
                    BrandId = _context.Products.FirstOrDefault(p => p.ProductId == od.ProductId)?.BrandId,
                    CategoryId = _context.Products.FirstOrDefault(p => p.ProductId == od.ProductId)?.CategoryId,
                    ModelYear = _context.Products.FirstOrDefault(p => p.ProductId == od.ProductId)?.ModelYear,
                    ListPrice = _context.Products.FirstOrDefault(p => p.ProductId == od.ProductId)?.ListPrice
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductPurchasedByMaxCustomerAsync()
        {
            var productSales = await _context.OrderDetails
                .GroupBy(od => od.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    CustomerCount = g.Select(od => od.CustomerId).Distinct().Count() // Count distinct customers
                })
                .ToListAsync();

            var maxCustomerCount = productSales.Max(ps => ps.CustomerCount);

            return await _context.Products
                .Where(p => productSales.Any(ps => ps.ProductId == p.ProductId && ps.CustomerCount == maxCustomerCount))
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    ModelYear = p.ModelYear,
                    ListPrice = p.ListPrice
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsWithMinimumStockAsync()
        {
            return await _context.Products
                .Where(p => p.StockQuantity < 10) // Assuming StockQuantity is a property that indicates the stock level
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    ModelYear = p.ModelYear,
                    ListPrice = p.ListPrice
                })
                .ToListAsync();
        }
    }
}