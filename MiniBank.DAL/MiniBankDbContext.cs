using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniBank.Entities;

namespace MiniBank.DAL
{
    public class MiniBankDbContext : IdentityDbContext<Client>
    {
        public MiniBankDbContext(DbContextOptions<MiniBankDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<BankAccount>().ToTable("BankAccount");
            // modelBuilder.Entity<Client>().Ignore(c => c.ConfirmPassword);
            modelBuilder.Entity<BankAccount>().HasKey(b => b.AccountNumber);
            modelBuilder.Entity<BankAccount>().Property(b => b.AccountNumber).UseIdentityColumn();
        }
    }
}