using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Data.DTO.Requests;

namespace TransactionImportAPI.Domain
{
    public interface ITransactionService
    {
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, Transaction transaction);
        Task<Transaction> CreateAsync(Transaction transaction);
        Task<Transaction> GetByIdAsync(string id);
        Task<List<Transaction>> GetAllAsync();
        Task<List<Transaction>> GetAllTransactionsByDateRange(DateTime startDate, DateTime endDate);
        Task<List<Transaction>> GetAllTransactionsByCurrency(string isoCode);
    }
}