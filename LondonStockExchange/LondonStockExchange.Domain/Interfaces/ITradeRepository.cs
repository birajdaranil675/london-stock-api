using LondonStockExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Domain.Interfaces
{
    public interface ITradeRepository
    {
        Task AddAsync(Trade trade);
    }
}
