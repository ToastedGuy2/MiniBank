using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MiniBank.Entities
{
    public class Client : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}