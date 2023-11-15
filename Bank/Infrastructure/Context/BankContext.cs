using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public class BankContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankContext(DbContextOptions<BankContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(transactions =>
            {
                transactions.ToTable("Transactions");
                transactions.HasKey(transaction => transaction.IdTransaction);
                transactions.Property(transaction => transaction.Date);
                transactions.Property(transaction => transaction.Value).IsRequired();
                transactions.Property(transaction => transaction.Type).IsRequired();

                transactions.HasOne(transaction => transaction.BankAccount)
                .WithMany(transaction => transaction.Transactions)
                .HasForeignKey(transaction => transaction.IdAccount);

            });



            modelBuilder.Entity<BankAccount>(accountBanks =>
            {
                accountBanks.ToTable("BankAccount");
                accountBanks.HasKey(accountBanks => accountBanks.IdAccount);
                accountBanks.Property(accountBank => accountBank.Owner).IsRequired().HasMaxLength(200);
                accountBanks.Property(accountBank=> accountBank.Balance).IsRequired();

            });

            
        }
    }
}
