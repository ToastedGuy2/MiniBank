using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class Bank : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}