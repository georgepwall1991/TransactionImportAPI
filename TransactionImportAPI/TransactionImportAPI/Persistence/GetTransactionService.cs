using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Domain;
using TransactionImportAPI.Model;

namespace TransactionImportAPI.Persistence
{
    public class GetTransactionService : IGetTransactionService
    {
        private readonly TransactionDbContext _transactionDbContext;

        public GetTransactionService(TransactionDbContext transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await this._transactionDbContext.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsByCurrency(string ISOCode)
        {
            // Validation to be done upfront on the front end 
            return await this._transactionDbContext.Transactions
                .Where(o => o.ISOCode.Select(country => country.ISOCode).Contains(ISOCode))
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            return await this._transactionDbContext.Transactions
                .Where(o => o.TransactionDate >= startDate && o.TransactionDate <= endDate)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsByTransactionStatus(string transactionStatus)
        {
            return await this._transactionDbContext.Transactions
                .Where(o => o.TransactionStatus.Select(status => status.TransactionStatusType).Contains(transactionStatus))
                .ToListAsync();
        }
    }
}
