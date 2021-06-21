using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImportAPI.Data.DTO.Requests
{
    public class GetTransactionsRequestDate
    {
        public GetTransactionsRequestDate(DateTime transactionStartDate, DateTime transactionEndDate)
        {
            TransactionStartDate = transactionStartDate.ToString("dd/MM/yyyy");
            TransactionEndDate = transactionEndDate.ToString("dd/MM/yyyy");
        }

        public string TransactionStartDate { get; set; }
        public string TransactionEndDate { get; set; }

    }
}
