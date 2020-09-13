using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Entities;

namespace WebUI.Components
{
    public class SignOut : ViewComponent
    {
        private readonly SignInManager<Client> _signInManager;

        public SignOut(SignInManager<Client> signInManager)
        {
            _signInManager = signInManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = HttpContext.User;
            ViewData["IsHeSigIn"] = _signInManager.IsSignedIn(user);
            ViewData["Username"] = _signInManager.UserManager.GetUserName(user);
            return View();
        }
    }
}