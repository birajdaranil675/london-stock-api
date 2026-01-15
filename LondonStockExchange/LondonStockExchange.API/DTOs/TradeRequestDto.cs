namespace LondonStockExchange.API.DTOs
{
    public class TradeRequestDto
    {
        public string TickerSymbol { get; set; }
        public decimal Price { get; set; }
        public decimal NumberOfShares { get; set; }
        public string BrokerId { get; set; }
    }
}
