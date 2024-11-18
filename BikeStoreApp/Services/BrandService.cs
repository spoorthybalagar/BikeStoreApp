using BikeStoreApp.Dto;
using BikeStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStoreApp.Services
{
    public class BrandService : IBrandService
    {
        private readonly BikeStoreAppContext _context;

        public BrandService(BikeStoreAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            return await _context.Brands
                .Select(b => new BrandDto { BrandId = b.BrandId, BrandName = b.BrandName })
                .ToListAsync();
        }

        public async Task<BrandDto> GetBrandByIdAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            return brand != null ? new BrandDto { BrandId = brand.BrandId, BrandName = brand.BrandName } : null;
        }

        public async Task AddBrandAsync(BrandDto brandDto)
        {
            var brand = new Brand { BrandName = brandDto.BrandName };
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBrandAsync(int id, BrandDto brandDto)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                brand.BrandName = brandDto.BrandName;
                await _context.SaveChangesAsync();
            }
        }
    }
}
