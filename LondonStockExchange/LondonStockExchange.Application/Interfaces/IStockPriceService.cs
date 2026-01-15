using LondonStockExchange.Application.DTOs;

namespace LondonStockExchange.Application.Interfaces
{
    public interface IStockPriceService
    {
        Task<StockPriceDto?> GetByTickerAsync(string tickerSymbol);
        Task<List<StockPriceDto>> GetAllAsync();
        Task<List<StockPriceDto>> GetByTickersAsync(List<string> tickerSymbols);
    }
}
