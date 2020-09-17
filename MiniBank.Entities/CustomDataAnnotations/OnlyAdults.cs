using System;
using System.ComponentModel.DataAnnotations;

namespace MiniBank.Entities.CustomDataAnnotations
{
    public class OnlyAdults : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null)
                return true;
            var birthdate = (DateTime) value;
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - birthdate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}