using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionImportAPI.Data.DTO
{
    public class Country
    {
        [Key] [Column(Order = 1)] 
        public int ISOCodeID { get; set; }

        [Column(Order = 2)] 
        public string ISOCode { get; set; }

        [Column(Order = 3)] 
        public string CountryName { get; set; }
    }
}