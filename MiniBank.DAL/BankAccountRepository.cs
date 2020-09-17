using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MiniBank.Entities;

namespace MiniBank.DAL
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly MiniBankDbContext dbContext;

        public BankAccountRepository(MiniBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(BankAccount bankAccount) //My caller needs to bring the full bankAccount model or entity
        {
            dbContext.Add(bankAccount);
            dbContext.SaveChanges();
        }

        public IEnumerable<BankAccount> GetByClientId(string clientId)
        {
            return dbContext.BankAccounts.Include(b => b.Client).Where(b => b.Client.Id == clientId);
        }

        public BankAccount GetByAccountNumber(int accountNumber)
        {
            return dbContext.BankAccounts.Find(accountNumber);
        }

        public IEnumerable<BankAccount> GetByBankAccountNumberOrName(string clientId,string searchText)
        {
            return GetByClientId(clientId).Where(b => b.Name.Contains(searchText) || b.AccountNumber.ToString().Contains(searchText));
        }

        public IEnumerable<BankAccount> GetBankAccountsFromOtherClients(string clientId)
        {
            return dbContext.BankAccounts.Include(b => b.Client).Where(b => b.Client.Id != clientId);
        }

        public void Update(BankAccount bankAccount)
        {
            dbContext.Update(bankAccount);
            dbContext.SaveChanges();
        }

        public void Delete(int accountNumber)
        {
            var bankAccount = dbContext.BankAccounts.Find(accountNumber);
            dbContext.Remove(bankAccount);
            dbContext.SaveChanges();
        }
    }
}