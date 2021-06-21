using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionImportAPI.Data.DTO;

namespace TransactionImportAPI.Domain
{
    public interface IUploadTransactionService
    {
        public Task<bool> UploadTransaction(Data.DTO.Transaction transaction);
    }
}
