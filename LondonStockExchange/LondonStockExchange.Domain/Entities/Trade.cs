using LondonStockExchange.Domain.Exceptions;
using LondonStockExchange.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Domain.Entities
{
    public class Trade
    {
        public Guid Id { get; private set; }
        public TickerSymbol TickerSymbol { get; private set; }
        public decimal Price { get; private set; }
        public decimal Quantity { get; private set; }
        public string BrokerId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // EF Core requirement
        private Trade() { }

        public Trade(TickerSymbol tickerSymbol, decimal price, decimal quantity, string brokerId)
        {
            if (price <= 0)
                throw new InvalidTradeException("Price must be greater than zero");

            if (quantity <= 0)
                throw new InvalidTradeException("Quantity must be greater than zero");

            if (string.IsNullOrWhiteSpace(brokerId))
                throw new InvalidTradeException("BrokerId is required");

            Id = Guid.NewGuid();
            TickerSymbol = tickerSymbol;
            Price = price;
            Quantity = quantity;
            BrokerId = brokerId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
