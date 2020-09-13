using Microsoft.AspNetCore.Mvc;
using MiniBank.Entities;

namespace WebUI.Components
{
    public class LogOut : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // var result = HttpContext.User.Identity.IsAuthenticated;
            // Username = HttpContext.User.Identity.Name;
            var client = new Client {UserName = HttpContext.User.Identity.Name};
            return View(client);
        }
    }
}