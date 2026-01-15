using LondonStockExchange.API.DTOs;
using LondonStockExchange.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Application.Services
{
    public class StockPriceService : IStockPriceService
    {
        public Task<List<StockPriceDto>> GetAllStockPricesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<StockPriceDto>> GetAllStockPricesForSelectedStocksAsync(List<string> stockList)
        {
            throw new NotImplementedException();
        }

        public Task<StockPriceDto> GetStockPricesAsync(string tickerSymbol)
        {
            throw new NotImplementedException();
        }
    }
}
