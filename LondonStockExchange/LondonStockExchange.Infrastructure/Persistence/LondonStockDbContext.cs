using LondonStockExchange.Domain.Entities;
using LondonStockExchange.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LondonStockExchange.Infrastructure.Persistence
{
    public class LondonStockDbContext : DbContext
    {
        public LondonStockDbContext(DbContextOptions<LondonStockDbContext> options) : base(options)
        {
            
        }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<StockPriceSnapshot> StockPriceSnapshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LondonStockDbContext).Assembly);

            // Map TickerSymbol value object as an owned type (flatten into parent table)
            modelBuilder.Entity<StockPriceSnapshot>(b =>
            {
                b.OwnsOne(s => s.TickerSymbol, ts =>
                {
                    ts.Property(t => t.Value)
                      .HasColumnName("TickerSymbol")
                      .HasMaxLength(20)
                      .IsRequired();
                });
            });

            // Also map Trade.TickerSymbol to avoid EF creating shadow FK for the owned type
            modelBuilder.Entity<Trade>(b =>
            {
                b.OwnsOne(t => t.TickerSymbol, ts =>
                {
                    ts.Property(tk => tk.Value)
                      .HasColumnName("TickerSymbol")
                      .HasMaxLength(20)
                      .IsRequired();
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}