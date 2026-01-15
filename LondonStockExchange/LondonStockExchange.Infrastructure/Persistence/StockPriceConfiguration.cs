

using LondonStockExchange.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LondonStockExchange.Infrastructure.Persistence
{
    public class StockPriceConfiguration : IEntityTypeConfiguration<StockPriceSnapshot>
    {
        public void Configure(EntityTypeBuilder<StockPriceSnapshot> builder)
        {
            builder.ToTable("StockPriceSnapshots");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.AveragePrice)
                   .HasPrecision(18, 4)
                   .IsRequired();

            builder.Property(s => s.TradeCount)
                   .IsRequired();

            builder.OwnsOne(
            s => s.TickerSymbol,
            owned =>
            {
                owned.WithOwner();

                // Map the value object to a dedicated column name to avoid
                // colliding with the navigation/property name on the owner.
                owned.Property(t => t.Value)
                     .HasColumnName("TickerSymbolValue")
                     .HasMaxLength(10)
                     .IsRequired();

                // Create an index on the owned property's CLR member. This avoids
                // creating a shadow property on the owner and lets EF map the
                // index to the concrete column name specified above.
                owned.HasIndex(p => p.Value).IsUnique();

                // No separate key for owned value object; it shares the owner's key.
            });
        }
    }
}