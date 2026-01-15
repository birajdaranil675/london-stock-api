using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Domain.Exceptions
{
    public class InvalidTradeException : Exception
    {
        public InvalidTradeException(string message) : base(message)
        {
            
        }
    }
}
