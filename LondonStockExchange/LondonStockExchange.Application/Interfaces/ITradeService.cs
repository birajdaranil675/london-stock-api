using LondonStockExchange.Application.DTOs;

namespace LondonStockExchange.Application.Interfaces
{
    public interface ITradeService
    {
        Task<TradeResponseDto> CreateTradeAsync(TradeRequestDto tradeRequest);
    }
}
