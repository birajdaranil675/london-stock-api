
using LondonStockExchange.Application.DTOs;
using LondonStockExchange.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class StocksController : Controller
    {
        private readonly IStockPriceService _stockPriceService;

        public StocksController(IStockPriceService stockPriceService)
        {
            _stockPriceService = stockPriceService;
        }


        [HttpGet("{tickerSymbol}/price")]
        public async Task<ActionResult<StockPriceDto>> GetStockPrice([FromRoute] string tickerSymbol)
        {
            var stockPrice = await _stockPriceService.GetByTickerAsync(tickerSymbol);

            if (stockPrice == null)
            {
                return NotFound();
            }

            return Ok(stockPrice);
        }

        [HttpGet("prices")]
        public async Task<ActionResult<List<StockPriceDto>>> GetAllStockPrices()
        {
            var result = await _stockPriceService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost("prices")]
        public async Task<ActionResult<List<StockPriceDto>>> GetAllStockPricesForSelectedStocks([FromBody] List<string> stockList)
        {
            var result = await _stockPriceService.GetByTickersAsync(stockList);

            return Ok(result);
        }
    }
}
