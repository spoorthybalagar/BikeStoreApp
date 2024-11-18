using BikeStoreApp.Dto;
using BikeStoreApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreApp.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto categoryDto)
        {
            await _categoryService.AddCategoryAsync(categoryDto);
            return Ok("Category Added Successfully!");
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // PUT: api/category/edit/{id}
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(id, categoryDto);
            return NoContent();
        }

        // GET: api/category/categoryname/{categoryname}
        [HttpGet("categoryname/{categoryname}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByName(string categoryname)
        {
            var category = await _categoryService.GetCategoryByNameAsync(categoryname);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }
    }
}
