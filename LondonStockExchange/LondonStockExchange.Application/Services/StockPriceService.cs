
using LondonStockExchange.Application.DTOs;
using LondonStockExchange.Application.Interfaces;
using LondonStockExchange.Domain.Interfaces;
using LondonStockExchange.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Application.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IStockPriceRepository _stockPriceRepository;

        public StockPriceService(IStockPriceRepository stockPriceRepository)
        {
            _stockPriceRepository = stockPriceRepository;
        }

        public async Task<List<StockPriceDto>> GetAllAsync()
        {
            var snapshots = await _stockPriceRepository.GetAllAsync();

            var dtos = snapshots.Select(snapshot => new StockPriceDto
            {
                TickerSymbol = snapshot.TickerSymbol.ToString(),
                AveragePrice = snapshot.AveragePrice
            }).ToList();

            return dtos;
        }

        public async Task<StockPriceDto?> GetByTickerAsync(string tickerSymbol)
        {
            var ticker = new TickerSymbol(tickerSymbol);

            var snapshot = await _stockPriceRepository.GetByTickerAsync(ticker);

            if (snapshot == null)
            {
                return null;
            }

            return new StockPriceDto
            {
                TickerSymbol = snapshot.TickerSymbol.ToString(),
                AveragePrice = snapshot.AveragePrice
            };
        }

        public async Task<List<StockPriceDto>> GetByTickersAsync(List<string> tickerSymbols)
        {
            var tickers = tickerSymbols.Select(ts => new TickerSymbol(ts)).ToList();

            var snapshots = await _stockPriceRepository.GetByTickersAsync(tickers);
            return snapshots.Select(snapshot => new StockPriceDto
            {
                TickerSymbol = snapshot.TickerSymbol.ToString(),
                AveragePrice = snapshot.AveragePrice
            }).ToList();
        }
    }
}
