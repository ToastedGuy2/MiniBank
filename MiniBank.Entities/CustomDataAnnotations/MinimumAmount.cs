using System;
using System.ComponentModel.DataAnnotations;

namespace MiniBank.Entities.CustomDataAnnotations
{
    public class MinimumAmount : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null)
                return true;
            double amount;
            if (Double.TryParse(value.ToString(), out amount))
            {
                return amount >= 5000;
            }

            return false;
        }
    }
}