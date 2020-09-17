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
            return View(new SignUpViewModel());
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
                        viewModel.UsernameError = "The Id is already taken";
                    if (error.Code.Contains("Email"))
                        viewModel.EmailError = "The email is already taken";
                    if (error.Code.Contains("Password"))
                        viewModel.PasswordError =
                            "Your password must be at least 6 characters, and it must contains one uppercase letter, one lowercase letter and one non alphanumerical character";
                    // ModelState.AddModelError("",error.Description);
                }
            }

            return View(viewModel);
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
                if (result.Succeeded) return RedirectToAction("List", "BankAccount");

                model.ShouldIShowSignInError = true;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}