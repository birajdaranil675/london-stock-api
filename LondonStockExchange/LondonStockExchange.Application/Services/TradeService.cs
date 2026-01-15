using LondonStockExchange.Application.DTOs;
using LondonStockExchange.Application.Interfaces;
using LondonStockExchange.Domain.Entities;
using LondonStockExchange.Domain.Interfaces;
using LondonStockExchange.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Application.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IStockPriceRepository _stockPriceRepository;

        public TradeService(
            ITradeRepository tradeRepository,
            IStockPriceRepository stockPriceRepository)
        {
            _tradeRepository = tradeRepository;
            _stockPriceRepository = stockPriceRepository;
        }

        public async Task<TradeResponseDto> CreateTradeAsync(TradeRequestDto request)
        {
            // Convert input to domain value object
            var ticker = new TickerSymbol(request.TickerSymbol);

            // 2️⃣ Create Trade domain entity
            var trade = new Trade(
                ticker,
                request.Price,
                request.Quantity,
                request.BrokerId);

            // Persist trade (append-only)
            await _tradeRepository.AddAsync(trade);

            // Update or create StockPriceSnapshot
            var snapshot = await _stockPriceRepository.GetByTickerAsync(ticker);

            if (snapshot == null)
            {
                snapshot = new StockPriceSnapshot(ticker, trade.Price);
                await _stockPriceRepository.AddAsync(snapshot);
            }
            else
            {
                snapshot.ApplyNewTrade(trade.Price);
                await _stockPriceRepository.UpdateAsync(snapshot);
            }

            // Return identifier
            return new TradeResponseDto { TradeId = trade.Id.ToString()};
        }
    }
}
