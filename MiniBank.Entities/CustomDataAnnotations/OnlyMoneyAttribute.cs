using System;
using System.ComponentModel.DataAnnotations;

namespace MiniBank.Entities.CustomDataAnnotations
{
    public class OnlyMoneyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null)
                return true;
            double amount = 0;
            return Double.TryParse(value.ToString(),out amount);
        }
    }
}