using LondonStockExchange.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.API.Controllers
{
    [Route("api/{controller}")]
    public class StocksController : Controller
    {
        [HttpGet]
        [Route("/{tickerSymbol}/price")]
        public async Task<StockPriceDto> GetStockPrice([FromRoute] string tickerSymbol)
        {
            return new StockPriceDto() { };
        }

        [HttpGet]
        [Route("/prices")]
        public async Task<List<StockPriceDto>> GetAllStockPrices()
        {
            return new List<StockPriceDto>();
        }

        [HttpPost]
        [Route("/prices")]
        public async Task<List<StockPriceDto>> GetAllStockPricesForSelectedStocks([FromBody] List<string> stockList)
        {
            return new List<StockPriceDto>();
        }
    }
}
