using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Persistence;
using Xunit;

namespace TransactionImportAPI.AutomatedTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test3DigitISOCode()
        {
            var sampleOptions = new TransactionDatabaseConfiguration
            {
                ConnectionString = "mongodb://localhost:27017",
                TransactionCollectionName = "Transactions",
                DatabaseName = "Transaction"
            };
            var options = Options.Create(sampleOptions);
            var service = new TransactionService(options);
            var transactions = await service.GetAllTransactionsByCurrency("GBP");
            Assert.NotEmpty(transactions);
        }
        
        [Fact]
        public async Task TestGreater3DigitISOCode()
        {
            var sampleOptions = new TransactionDatabaseConfiguration
            {
                ConnectionString = "mongodb://localhost:27017",
                TransactionCollectionName = "Transactions",
                DatabaseName = "Transaction"
            };
            var options = Options.Create(sampleOptions);
            var service = new TransactionService(options);
            await Assert.ThrowsAsync<Exception>(() => service.GetAllTransactionsByCurrency("GBPP"));
        }
    }
}