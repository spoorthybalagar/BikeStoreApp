using BikeStoreApp.Dto;

namespace BikeStoreApp.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<BrandDto> GetBrandByIdAsync(int id);
        Task AddBrandAsync(BrandDto brandDto);
        Task UpdateBrandAsync(int id, BrandDto brandDto);
    }
}
