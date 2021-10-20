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
        private const string TransactionIdentifier = "test";
        private const string UpdatedTransactionIdentifier = "testChanged";

        private static Task ImportDefaultTransaction()
        {
            var sampleOptions = new TransactionDatabaseConfiguration
            {
                ConnectionString = "mongodb://localhost:27017",
                TransactionCollectionName = "Transactions",
                DatabaseName = "Transaction"
            };
            var options = Options.Create(sampleOptions);
            var service = new TransactionService(options);

            service.CreateAsync(new Transaction
            {
                TransactionIdentifier = TransactionIdentifier,
                TransactionAmount = 0,
                ISOCode = "GBP",
                TransactionDate = new DateTime(2021, 06, 30),
                TransactionStatus = "Approved"
            });

            return Task.CompletedTask;
        }

        private static Task DeleteValue(string id)
        {
            var sampleOptions = new TransactionDatabaseConfiguration
            {
                ConnectionString = "mongodb://localhost:27017",
                TransactionCollectionName = "Transactions",
                DatabaseName = "Transaction"
            };
            var options = Options.Create(sampleOptions);
            var service = new TransactionService(options);
            service.DeleteAsync(id);
            return Task.CompletedTask;
        }

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

        [Fact]
        public async Task DeleteAsyncTest()
        {
            await ImportDefaultTransaction();
            var sampleOptions = new TransactionDatabaseConfiguration
            {
                ConnectionString = "mongodb://localhost:27017",
                TransactionCollectionName = "Transactions",
                DatabaseName = "Transaction"
            };
            var options = Options.Create(sampleOptions);
            var service = new TransactionService(options);
            await service.DeleteAsync(TransactionIdentifier).ConfigureAwait(false);
            var checkValuesExist = await service.GetByIdAsync(TransactionIdentifier).ConfigureAwait(false);
            Assert.Null(checkValuesExist);
        }
        
        [Fact]
        public async Task UpdateAsyncTest()
        {
            await ImportDefaultTransaction();
            var sampleOptions = new TransactionDatabaseConfiguration
            {
                ConnectionString = "mongodb://localhost:27017",
                TransactionCollectionName = "Transactions",
                DatabaseName = "Transaction"
            };
            var options = Options.Create(sampleOptions);
            var service = new TransactionService(options);
            await service.UpdateAsync(TransactionIdentifier, new Transaction
            {
                TransactionIdentifier = UpdatedTransactionIdentifier,
                TransactionAmount = 0,
                ISOCode = "GBP",
                TransactionDate = new DateTime(2021, 06, 30),
                TransactionStatus = "Approved"
            });
            var checkValueUpdated = await service.GetByIdAsync(UpdatedTransactionIdentifier).ConfigureAwait(false);
            Assert.Same(UpdatedTransactionIdentifier, checkValueUpdated.TransactionIdentifier);
            await DeleteValue(UpdatedTransactionIdentifier);
            Assert.Null(await service.GetByIdAsync(UpdatedTransactionIdentifier).ConfigureAwait(false));
        }
    }
}