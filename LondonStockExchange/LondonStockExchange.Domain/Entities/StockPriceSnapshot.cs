using LondonStockExchange.Domain.Exceptions;
using LondonStockExchange.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Domain.Entities
{
    public class StockPriceSnapshot
    {
        public Guid Id { get; private set; }
        public TickerSymbol TickerSymbol { get; private set; }
        public decimal AveragePrice { get; private set; }
        public long TradeCount { get; private set; }

        // EF Core
        private StockPriceSnapshot() { }

        public StockPriceSnapshot(TickerSymbol tickerSymbol, decimal firstPrice)
        {
            Id = Guid.NewGuid();
            TickerSymbol = tickerSymbol;
            AveragePrice = firstPrice;
            TradeCount = 1;
        }

        public void ApplyNewTrade(decimal tradePrice)
        {
            if (tradePrice <= 0)
                throw new InvalidTradeException("Trade price must be greater than zero");

            AveragePrice =
                ((AveragePrice * TradeCount) + tradePrice) / (TradeCount + 1);

            TradeCount++;
        }
    }
}
