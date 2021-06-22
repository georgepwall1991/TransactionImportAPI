using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Domain;
using TransactionImportAPI.Model;

namespace TransactionImportAPI.Persistence
{
    public class UploadTransactionService : IUploadTransactionService
    {
        private readonly TransactionDbContext _transactionDbContext;

        public UploadTransactionService(TransactionDbContext transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
        }

        public async Task<bool> UploadTransaction(Transaction transaction)
        {
            await _transactionDbContext.Transactions.AddAsync(new Transaction
            {
                ISOCode = transaction.ISOCode,
                TransactionAmount = transaction.TransactionAmount,
                TransactionDate = transaction.TransactionDate,
                TransactionStatus = transaction.TransactionStatus,
                TransactionIdentifier = transaction.TransactionIdentifier
            });

            var changesSaved = await _transactionDbContext.SaveChangesAsync();
            return changesSaved > 0;
        }
    }
}
