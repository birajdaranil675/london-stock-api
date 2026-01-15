namespace LondonStockExchange.Application.DTOs
{
    public class StockPriceDto
    {
        public string TickerSymbol { get; set; } = null!;
        public decimal AveragePrice { get; set; }
    }
}
