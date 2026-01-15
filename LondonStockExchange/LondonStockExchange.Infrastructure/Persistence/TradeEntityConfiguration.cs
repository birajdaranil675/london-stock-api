

using LondonStockExchange.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LondonStockExchange.Infrastructure.Persistence
{
    public class TradeEntityConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.ToTable("Trades");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Price)
                   .HasPrecision(18, 4)
                   .IsRequired();

            builder.Property(t => t.Quantity)
                   .HasPrecision(18, 4)
                   .IsRequired();

            builder.Property(t => t.BrokerId)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .IsRequired();

            // Mapping Value Object -> column
            builder.OwnsOne(
            t => t.TickerSymbol,
            owned =>
            {
                owned.WithOwner();

                // Use the same column name used for StockPriceSnapshot to be consistent
                // and avoid property/name collisions.
                owned.Property(ts => ts.Value)
                     .HasColumnName("TickerSymbolValue")
                     .HasMaxLength(10)
                     .IsRequired();

                // Index on owned property
                owned.HasIndex(p => p.Value);

                // No separate key for owned value object; it shares the owner's key.
            });
        }
    }
}