using LondonStockExchange.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Application.Interfaces
{
    public interface ITradeService
    {
        Task<TradeResponseDto> CreateTradeAsync(TradeRequestDto tradeRequest);
    }
}
