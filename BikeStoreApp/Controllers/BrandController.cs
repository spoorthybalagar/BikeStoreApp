using BikeStoreApp.Dto;
using BikeStoreApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreApp.Controllers
{
    [ApiController]
    [Route("api/brand")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] BrandDto brandDto)
        {
            await _brandService.AddBrandAsync(brandDto);
            return Ok("Record Added Successfully!!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            return Ok(await _brandService.GetAllBrandsAsync());
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] BrandDto brandDto)
        {
            await _brandService.UpdateBrandAsync(id, brandDto);
            return NoContent();
        }
    }
}
