using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Domain;
using TransactionImportAPI.Persistence;

namespace TransactionImportAPI.Configurations
{
    public static class ConfigurePersistence
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TransactionDatabaseConfiguration>(
                configuration.GetSection("TransactionDatabaseConfiguration"));
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped(c => c.GetService<IMongoClient>()?.StartSession());
            return services;
        }
    }
}