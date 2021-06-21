using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImportAPI.Data.DTO
{
    public class TransactionStatus
    {
        [Key]
        [Column(Order = 1)]
        public int TransactionStatusId { get; set; }
        [Column(Order = 2)]
        public string TransactionStatusType { get; set; }
    }
}
