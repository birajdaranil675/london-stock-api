

using LondonStockExchange.Domain.Entities;
using LondonStockExchange.Domain.Interfaces;
using LondonStockExchange.Infrastructure.Persistence;

namespace LondonStockExchange.Infrastructure.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly LondonStockDbContext _dbContext;

        public TradeRepository(LondonStockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Trade trade)
        {
            _dbContext.Trades.Add(trade);
            await _dbContext.SaveChangesAsync();
        }
    }
}