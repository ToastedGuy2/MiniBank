using System.Collections.Generic;
using MiniBank.Entities;

namespace WebUI.Models.ViewModels
{
    public class SearchResultViewModel
    {
        public IEnumerable<BankAccount> Results { get; set; }
        public string SearchText { get; set; }
        public int NumberOfResults { get; set; }
    }
}