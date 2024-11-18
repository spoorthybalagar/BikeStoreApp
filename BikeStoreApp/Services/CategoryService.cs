using BikeStoreApp.Dto;
using BikeStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStoreApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BikeStoreAppContext _context;

        public CategoryService(BikeStoreAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDto { CategoryId = c.CategoryId, CategoryName = c.CategoryName })
                .ToListAsync();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category != null ? new CategoryDto { CategoryId = category.CategoryId, CategoryName = category.CategoryName } : null;
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category { CategoryName = categoryDto.CategoryName };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                category.CategoryName = categoryDto.CategoryName;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CategoryDto> GetCategoryByNameAsync(string categoryName)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            return category != null ? new CategoryDto { CategoryId = category.CategoryId, CategoryName = category.CategoryName } : null;
        }
    }
}

