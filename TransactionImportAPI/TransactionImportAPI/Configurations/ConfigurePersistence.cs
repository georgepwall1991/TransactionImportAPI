using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionImportAPI.Domain;
using TransactionImportAPI.Model;
using TransactionImportAPI.Persistence;

namespace TransactionImportAPI.Configurations
{
    public static class ConfigurePersistence
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TransactionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TransactionDB")));

            services.AddScoped<IUploadTransactionService, UploadTransactionService>();
            services.AddScoped<IGetTransactionService, GetTransactionService>();
            return services;
        }
    }
}
