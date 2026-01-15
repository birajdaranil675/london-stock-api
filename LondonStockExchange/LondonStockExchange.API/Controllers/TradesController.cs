using LondonStockExchange.Application.DTOs;
using LondonStockExchange.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradesController : Controller
    {
        private readonly ITradeService _tradeService;

        public TradesController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpPost]
        public async Task<TradeResponseDto> CreateTrade([FromBody] TradeRequestDto tradeRequest)
        {
            var result = await _tradeService.CreateTradeAsync(tradeRequest);

            return  result;
        }
    }
}
