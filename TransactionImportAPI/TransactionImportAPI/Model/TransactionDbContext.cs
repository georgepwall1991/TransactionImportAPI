using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionImportAPI.Data.DTO;

namespace TransactionImportAPI.Model
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<TransactionStatus> TransactionStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<TransactionStatus>().ToTable("TransactionStatus");


            modelBuilder.Entity<Country>()
                .HasData(
                    new Country
                    {
                        CountryName = "Great Britain",
                        ISOCode = "GBP",
                        ISOCodeID = 1
                    },
                    new Country
                    {
                        CountryName = "Japan",
                        ISOCode = "JPY",
                        ISOCodeID = 2
                    },
                    new Country
                    {
                        CountryName = "United States Of America",
                        ISOCode = "USD",
                        ISOCodeID = 3
                    });


            modelBuilder.Entity<TransactionStatus>()
                .HasData(
                    new TransactionStatus
                    {
                        TransactionStatusId = 1,
                        TransactionStatusType = "Approved"
                    },
                    new TransactionStatus
                    {
                        TransactionStatusId = 2,
                        TransactionStatusType = "Rejected"
                    },
                    new TransactionStatus
                    {
                        TransactionStatusId = 3,
                        TransactionStatusType = "Done"
                    });
        }

    }
}

