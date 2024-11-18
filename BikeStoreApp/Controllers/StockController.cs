using BikeStoreApp.Models;
using BikeStoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockServices _stockServices;

        public StockController(IStockServices stockServices)
        {
            _stockServices = stockServices;
        }

        // GET: api/stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseStockDto>>> GetAllStocks()
        {
            var stocks = await _stockServices.GetAllStocksAsync();
            return Ok(stocks);
        }

        // GET: api/stock/{storeId}/{productId}
        [HttpGet("{storeId}/{productId}")]
        public async Task<ActionResult<ResponseStockDto>> GetStockById(int storeId, int productId)
        {
            var stock = await _stockServices.GetStockByIdAsync(storeId, productId);
            if (stock == null)
            {
                return NotFound(new { message = "Stock not found" });
            }
            return Ok(stock);
        }

        // POST: api/stock
        [HttpPost]
        public async Task<ActionResult> CreateStock([FromBody] CreateStockDto createStockDto)
        {
            var result = await _stockServices.AddStockAsync(createStockDto);
            if (result)
            {
                return CreatedAtAction(nameof(GetStockById), new { storeId = createStockDto.StoreId, productId = createStockDto.ProductId }, createStockDto);
            }
            return BadRequest(new { message = "Unable to add stock" });
        }

        // PUT: api/stock
        [HttpPut]
        public async Task<ActionResult> UpdateStock([FromBody] UpdateStockDto updateStockDto)
        {
            var result = await _stockServices.UpdateStockAsync(updateStockDto);
            if (result)
            {
                return NoContent(); // 204 No Content (indicating success without a body)
            }
            return NotFound(new { message = "Stock not found" });
        }

        // DELETE: api/stock/{storeId}/{productId}
        [HttpDelete("{storeId}/{productId}")]
        public async Task<ActionResult> DeleteStock(int storeId, int productId)
        {
            var result = await _stockServices.DeleteStockAsync(storeId, productId);
            if (result)
            {
                return NoContent(); // 204 No Content (indicating success without a body)
            }
            return NotFound(new { message = "Stock not found" });
        }
    }
}
