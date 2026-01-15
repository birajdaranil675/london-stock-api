using LondonStockExchange.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.API.Controllers
{
    [Route("api/{controller}")]
    public class TradesController : Controller
    {
        [HttpPost]
        public async Task<TradeResponseDto> CreateTrade([FromBody] TradeRequestDto tradeRequest)
        {
            return await Task.Run(() =>
            {
                var tradeResponse = new TradeResponseDto
                {
                    TradeId = "TRADE123"
                };
                return tradeResponse;
            });
        }
    }
}
