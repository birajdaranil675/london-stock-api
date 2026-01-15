using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LondonStockExchange.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TickerSymbolValue",
                table: "Trades",
                newName: "TickerSymbol");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_TickerSymbolValue",
                table: "Trades",
                newName: "IX_Trades_TickerSymbol");

            migrationBuilder.RenameColumn(
                name: "TickerSymbolValue",
                table: "StockPriceSnapshots",
                newName: "TickerSymbol");

            migrationBuilder.RenameIndex(
                name: "IX_StockPriceSnapshots_TickerSymbolValue",
                table: "StockPriceSnapshots",
                newName: "IX_StockPriceSnapshots_TickerSymbol");

            migrationBuilder.AlterColumn<string>(
                name: "TickerSymbol",
                table: "Trades",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "TickerSymbol",
                table: "StockPriceSnapshots",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TickerSymbol",
                table: "Trades",
                newName: "TickerSymbolValue");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_TickerSymbol",
                table: "Trades",
                newName: "IX_Trades_TickerSymbolValue");

            migrationBuilder.RenameColumn(
                name: "TickerSymbol",
                table: "StockPriceSnapshots",
                newName: "TickerSymbolValue");

            migrationBuilder.RenameIndex(
                name: "IX_StockPriceSnapshots_TickerSymbol",
                table: "StockPriceSnapshots",
                newName: "IX_StockPriceSnapshots_TickerSymbolValue");

            migrationBuilder.AlterColumn<string>(
                name: "TickerSymbolValue",
                table: "Trades",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "TickerSymbolValue",
                table: "StockPriceSnapshots",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }
    }
}
