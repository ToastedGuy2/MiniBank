using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BankController : Controller
    {
        [HttpGet]
        public IActionResult Deposit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Withdraw()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            return View();
        }
    }
}