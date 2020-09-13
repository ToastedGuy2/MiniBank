using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.ViewModels
{
    public class SignInViewModel
    {
        [Display(Name = "Id")] [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Display(Name = "Remember me")] public bool ShouldIRememberYou { get; set; }
    }
}