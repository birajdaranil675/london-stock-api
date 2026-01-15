using LondonStockExchange.Application.Interfaces;
using LondonStockExchange.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LondonStockExchange.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection ApplicationServicesCollection(this IServiceCollection services)
        {

            //Infra services
            services.AddScoped<IStockPriceService, StockPriceService>();
            services.AddScoped<ITradeService, TradeService>();

            return services;
        }
    }
}
