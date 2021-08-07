using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Domain;

namespace TransactionImportAPI.Persistence
{
    public class TransactionService : ITransactionService
    {
        private readonly IMongoCollection<Transaction> _transaction;

        public TransactionService(IOptions<TransactionDatabaseConfiguration> settings)
        {
            var settingsValue = settings.Value;
            var client = new MongoClient(settingsValue.ConnectionString);
            var database = client.GetDatabase(settingsValue.DatabaseName);
            _transaction = database.GetCollection<Transaction>(settingsValue.TransactionCollectionName);
        }

        public async Task DeleteAsync(string id)
        {
            await _transaction
                .DeleteOneAsync(c => c.TransactionIdentifier == id);
        }

        public async Task UpdateAsync(string id, Transaction transaction)
        {
            await _transaction
                .ReplaceOneAsync(c => c.TransactionIdentifier == id, transaction);
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            await _transaction.InsertOneAsync(transaction);
            return transaction;
        }

        public async Task<Transaction> GetByIdAsync(string id)
        {
            return await _transaction
                .Find(c => c.TransactionIdentifier == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _transaction
                .Find(c => true)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _transaction
                .Find(c => c.TransactionDate >= startDate && c.TransactionDate <= endDate)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsByCurrency(string isoCode)
        {
            if (isoCode.Length != 3 || !Regex.IsMatch(isoCode, "[a-zA-Z]"))
                throw new Exception(
                    $"Incorrect ISO Code - {isoCode} either isn't 3 digits in length or has non Alphabetical characters");

            return await _transaction
                .Find(c => c.ISOCode.Equals(isoCode))
                .ToListAsync();
        }
    }
}