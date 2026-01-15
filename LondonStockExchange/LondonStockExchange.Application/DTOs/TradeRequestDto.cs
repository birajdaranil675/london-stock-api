namespace LondonStockExchange.Application.DTOs
{
    public class TradeRequestDto
    {
        public string TickerSymbol { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string BrokerId { get; set; }
    }
}
