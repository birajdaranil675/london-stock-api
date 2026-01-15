using LondonStockExchange.API.DTOs;
using LondonStockExchange.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Application.Services
{
    public class TradeService : ITradeService
    {
        public Task<TradeResponseDto> CreateTradeAsync(TradeRequestDto tradeRequest)
        {
            throw new NotImplementedException();
        }
    }
}
