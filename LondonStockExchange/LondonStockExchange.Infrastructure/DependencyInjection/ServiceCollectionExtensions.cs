using LondonStockExchange.Domain.Interfaces;
using LondonStockExchange.Infrastructure.Persistence;
using LondonStockExchange.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LondonStockExchange.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection InfraServicesCollection(this IServiceCollection services, IConfiguration configuration)
        {
            //Db context
            services.AddDbContext<LondonStockDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            //Infra services
            services.AddScoped<IStockPriceRepository, StockPriceRepository>();
            services.AddScoped<ITradeRepository, TradeRepository>();

            return services;
        }
    }
}
