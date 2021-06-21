using System;
using System.Linq;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Model;

namespace TransactionImportAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TransactionDbContext context)
        {
            if (context.Transactions.Any()) return; // db has been seeded

            var countries = new[]
            {
                new Country {CountryName = "Great Britain", ISOCode = "GBP", ISOCodeID = 1},
                new Country {CountryName = "Japan", ISOCode = "JPY", ISOCodeID = 2},
                new Country {CountryName = "United States Of America", ISOCode = "USD", ISOCodeID = 3}
            };

            context.Countries.AddRangeAsync(countries);
            context.SaveChangesAsync();

            var transactionStatus = new[]
            {
                new TransactionStatus
                {
                    TransactionStatusId = 1,
                    TransactionStatusType = "Approved"
                },
                new TransactionStatus
                {
                    TransactionStatusId = 2,
                    TransactionStatusType = "Rejected"
                },
                new TransactionStatus
                {
                    TransactionStatusId = 3,
                    TransactionStatusType = "Done"
                }
            };

            context.TransactionStatuses.AddRangeAsync(transactionStatus);
            context.SaveChangesAsync();
            
        }
    }
}