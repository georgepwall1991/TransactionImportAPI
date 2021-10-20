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
        private static TransactionService _transactionService;
        private const string TransactionIdentifier = "test";
        private const string UpdatedTransactionIdentifier = "testChanged";

        public UnitTest1()
        {
            var sampleOptions = new TransactionDatabaseConfiguration
            {
                ConnectionString = "mongodb://localhost:27017",
                TransactionCollectionName = "Transactions",
                DatabaseName = "Transaction"
            };
            var options = Options.Create(sampleOptions);
            _transactionService = new TransactionService(options);
        }

        private static Task ImportDefaultTransaction()
        {
            _transactionService.CreateAsync(new Transaction
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
            _transactionService.DeleteAsync(id);
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test3DigitISOCode()
        {
            var transactions = await _transactionService.GetAllTransactionsByCurrency("GBP");
            Assert.NotEmpty(transactions);
        }

        /* Logic is that if ISO Code isn't 3 digits long or contains a non alphabetic character, exception is thrown.
         In Logic bubbles up to controller and exception is caught and thrown a BadRequest(exp.Message) s*/
        [Fact]
        public async Task TestGreater3DigitISOCode()
        {
            await Assert.ThrowsAsync<Exception>(() => _transactionService.GetAllTransactionsByCurrency("GBPP"));
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            await ImportDefaultTransaction();
            await _transactionService.DeleteAsync(TransactionIdentifier).ConfigureAwait(false);
            var checkValuesExist = await _transactionService.GetByIdAsync(TransactionIdentifier).ConfigureAwait(false);
            Assert.NotNull(checkValuesExist);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            await ImportDefaultTransaction();
            await _transactionService.UpdateAsync(TransactionIdentifier, new Transaction
            {
                TransactionIdentifier = UpdatedTransactionIdentifier,
                TransactionAmount = 0,
                ISOCode = "GBP",
                TransactionDate = new DateTime(2021, 06, 30),
                TransactionStatus = "Approved"
            });
            var checkValueUpdated =
                await _transactionService.GetByIdAsync(UpdatedTransactionIdentifier).ConfigureAwait(false);
            Assert.Same(UpdatedTransactionIdentifier, checkValueUpdated.TransactionIdentifier);
            await DeleteValue(UpdatedTransactionIdentifier);
            Assert.NotNull(await _transactionService.GetByIdAsync(UpdatedTransactionIdentifier).ConfigureAwait(false));
        }
    }
}