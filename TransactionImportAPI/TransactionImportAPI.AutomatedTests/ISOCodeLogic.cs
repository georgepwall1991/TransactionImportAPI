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

        /* Logic is that if ISO Code isn't 3 digits long or contains a non alphabetic character, exception is thrown.
         In Logic bubbles up to controller and exception is caught and thrown a BadRequest(exp.Message) s*/
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