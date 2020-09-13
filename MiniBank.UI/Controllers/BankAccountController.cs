using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BankAccountController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}