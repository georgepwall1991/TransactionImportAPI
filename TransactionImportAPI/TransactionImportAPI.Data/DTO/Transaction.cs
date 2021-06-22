using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionImportAPI.Data.DTO
{
    public class Transaction
    {
        [Key]
        [Column(Order = 1)]
        public string TransactionIdentifier { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TransactionAmount { get; set; }

        [Column(Order = 3)]
        public string ISOCode { get; set; }

        [Column(Order = 4)]
        public DateTime TransactionDate { get; set; }

        [Column(Order = 5)]
        public string TransactionStatus { get; set; }
    }
}