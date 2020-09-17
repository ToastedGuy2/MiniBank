using System;
using System.ComponentModel.DataAnnotations;
using MiniBank.Entities.CustomDataAnnotations;

namespace WebUI.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Id")]
        [Required]
        [RegularExpression(@"^[1-9][0-9]*$",
            ErrorMessage = "Your Id must contain numerical characters, also it has to be bigger than 0")]
        public string Username { get; set; } //Cannot generate the Id automatically

        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Birth Date")]
        [Required]
        [OnlyAdults(ErrorMessage = "Your age must be least 18 to register")]
        public DateTime? BirthDate { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Required] public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required]
        [Compare("Password", ErrorMessage = "Your confirm password doesn't match the original password")]
        public string ConfirmPassword { get; set; } // This is not a property on a table

        public string UsernameError { get; set; }
        public string EmailError { get; set; }
        public string PasswordError { get; set; }
    }
}