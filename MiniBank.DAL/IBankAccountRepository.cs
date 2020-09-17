using System.Collections.Generic;
using MiniBank.Entities;

namespace MiniBank.DAL
{
    public interface IBankAccountRepository
    {
        void Add(BankAccount bankAccount);
        IEnumerable<BankAccount> GetByClientId(string clientId);
        BankAccount GetByAccountNumber(int accountNumber);
        IEnumerable<BankAccount> GetByBankAccountNumberOrName(string clientId, string searchText);
        IEnumerable<BankAccount> GetBankAccountsFromOtherClients(string clientId);
        void Update(BankAccount bankAccount);
        void Delete(int accountNumber);
    }
}