using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Entities;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Client> _signInManager;
        private readonly UserManager<Client> _userManager;

        public AccountController(UserManager<Client> userManager, SignInManager<Client> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new Client
                {
                    UserName = viewModel.Username, FullName = viewModel.FullName, BirthDate = viewModel.BirthDate.Value,
                    Email = viewModel.Email
                };
                var result = await _userManager.CreateAsync(client, viewModel.Password);
                if (result.Succeeded)
                {
                    TempData["DidHeJustSignUp"] = true;
                    return RedirectToAction("SignIn");
                }

                foreach (var error in result.Errors)
                {
                    if (error.Code.Contains("User"))
                        ViewData["UserError"] = "The Id is already taken";
                    if (error.Code.Contains("Email"))
                        ViewData["EmailError"] = "The email is already taken";
                    if (error.Code.Contains("Password"))
                        ViewData["PasswordError"] =
                            "Your password must be at least 6 characters, and it must contains one uppercase letter, one lowercase letter and one non alphanumerical character";
                    // ModelState.AddModelError("",error.Description);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,
                    model.ShouldIRememberYou, false);
                if (result.Succeeded) return RedirectToAction("Index", "BankAccount");

                ViewData["SignInError"] = true;
            }

            return View();
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}