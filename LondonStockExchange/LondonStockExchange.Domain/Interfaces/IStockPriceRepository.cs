using LondonStockExchange.Domain.Entities;
using LondonStockExchange.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Domain.Interfaces
{
    public interface IStockPriceRepository
    {
        Task<StockPriceSnapshot?> GetByTickerAsync(TickerSymbol tickerSymbol);
        Task AddAsync(StockPriceSnapshot snapshot);
        Task UpdateAsync(StockPriceSnapshot snapshot);
        Task<List<StockPriceSnapshot>> GetAllAsync();
        Task<List<StockPriceSnapshot>> GetByTickersAsync(IEnumerable<TickerSymbol> tickers);
    }
}
