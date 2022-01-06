using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace TransactionImportAPI.Data.DTO;

public class Transaction
{
    [BsonId] public string TransactionIdentifier { get; set; }

    [Required(ErrorMessage = "Transaction Amount is required")]
    public decimal TransactionAmount { get; set; }

    [Required(ErrorMessage = "ISO code is required")]
    public string ISOCode { get; set; }

    [Required(ErrorMessage = "Transaction Date is required")]
    public DateTime TransactionDate { get; set; }

    [Required(ErrorMessage = "Transaction Status is required")]
    public string TransactionStatus { get; set; }
}