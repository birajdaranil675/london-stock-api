using LondonStockExchange.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Domain.ValueObjects
{
    public sealed class TickerSymbol
    {
        public string Value { get; }

        public TickerSymbol(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidTradeException("Ticker symbol cannot be empty");

            Value = value.Trim().ToUpperInvariant();
        }

        public override string ToString() => Value;

        public override bool Equals(object? obj)
        {
            if (obj is not TickerSymbol other)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}
