using System;
using System.ComponentModel.DataAnnotations;
using MiniBank.Entities.CustomDataAnnotations;

namespace MiniBank.Entities
{
    public class BankAccount
    {
        public int AccountNumber { get; set; } //This will be the primary key and It should be identity
        [Required] public string Name { get; set; }

        [Required]
        [OnlyMoney(ErrorMessage = "Invalid amount of money")]
        [MinimumAmount(ErrorMessage = "₡5000 is the minimum amount to create a bank account")]
        public double? Money { get; set; }

        public Client Client { get; set; }
    }
}