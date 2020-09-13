using System;
using Microsoft.AspNetCore.Mvc;
using MiniBank.BLL;
using MiniBank.Entities;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountSystem _accountSystem;

        public LoginController(IAccountSystem accountSystem)
        {
            _accountSystem = accountSystem;
        }
        
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Client client)
        {
            IActionResult result = View();
            if (ModelState.IsValid)
            {
                try
                {
                    _accountSystem.SignUp(client);
                    result = RedirectToAction("SignIn");
                }
                catch (InvalidOperationException e) when(e.Message == "There's already a Client with such email")
                {
                    ViewData["EmailError"] = e.Message;
                }
                catch (InvalidOperationException e) when(e.Message == "There's already a Client with such Id")
                {
                    ViewData["IdError"] = e.Message;
                }
            }
                return result;
        }
        [HttpPost]
        public IActionResult SignIn(int id, string password)
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Demo(Client client)
        {
            return View();
        }
    }
}