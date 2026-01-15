using LondonStockExchange.API.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LondonStockExchange.Application.Interfaces
{
    public interface IStockPriceService
    {
        Task<StockPriceDto> GetStockPricesAsync(string tickerSymbol);
        Task<List<StockPriceDto>> GetAllStockPricesAsync();
        Task<List<StockPriceDto>> GetAllStockPricesForSelectedStocksAsync(List<string> stockList);
    }
}
