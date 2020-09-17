using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Entities;

namespace WebUI.Controllers
{
    public class BankController : Controller
    {
        private readonly SignInManager<Client> _signInManager;

        public BankController(SignInManager<Client> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Deposit()
        {
            var loggedUser = _signInManager.UserManager.GetUserAsync(HttpContext.User).Result;
            if (loggedUser is null)
            {
                TempData["IsHeSignIn"] = false;
                return RedirectToAction("SignIn", "Account");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Withdraw()
        {
            var loggedUser = _signInManager.UserManager.GetUserAsync(HttpContext.User).Result;
            if (loggedUser is null)
            {
                TempData["IsHeSignIn"] = false;
                return RedirectToAction("SignIn", "Account");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            var loggedUser = _signInManager.UserManager.GetUserAsync(HttpContext.User).Result;
            if (loggedUser is null)
            {
                TempData["IsHeSignIn"] = false;
                return RedirectToAction("SignIn", "Account");
            }

            return View();
        }
    }
}