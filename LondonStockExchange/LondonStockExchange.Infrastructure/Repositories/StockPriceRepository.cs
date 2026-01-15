using LondonStockExchange.Domain.Entities;
using LondonStockExchange.Domain.Interfaces;
using LondonStockExchange.Domain.ValueObjects;
using LondonStockExchange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LondonStockExchange.Infrastructure.Repositories
{
    public class StockPriceRepository : IStockPriceRepository
    {
        private readonly LondonStockDbContext _dbContext;

        public StockPriceRepository(LondonStockDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(StockPriceSnapshot snapshot)
        {
            await _dbContext.StockPriceSnapshots.AddAsync(snapshot);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<StockPriceSnapshot>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.StockPriceSnapshots.ToList());
        }

        public async Task<StockPriceSnapshot?> GetByTickerAsync(TickerSymbol tickerSymbol)
        {
            // Compare the scalar Value so EF can translate the expression to SQL
            return await _dbContext.StockPriceSnapshots
                .FirstOrDefaultAsync(s => s.TickerSymbol.Value == tickerSymbol.Value);
        }

        public async Task<List<StockPriceSnapshot>> GetByTickersAsync(IEnumerable<TickerSymbol> tickers)
        {
            var values = tickers.Select(t => t.Value).ToList();
            return await _dbContext.StockPriceSnapshots
                .Where(s => values.Contains(s.TickerSymbol.Value))
                .ToListAsync();
        }

        public async Task UpdateAsync(StockPriceSnapshot snapshot)
        {
            _dbContext.StockPriceSnapshots.Update(snapshot);
            await _dbContext.SaveChangesAsync();
        }
    }
}