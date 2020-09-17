using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniBank.DAL;
using MiniBank.Entities;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly SignInManager<Client> _signInManager;

        public BankAccountController(IBankAccountRepository bankAccountRepository, SignInManager<Client> signInManager)
        {
            _bankAccountRepository = bankAccountRepository;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult List()
        {
            var loggedUser = _signInManager.UserManager.GetUserAsync(HttpContext.User).Result;

            if (loggedUser is null)
            {
                TempData["IsHeSignIn"] = false;
                return RedirectToAction("SignIn", "Account");
            }

            var bankAccounts = _bankAccountRepository.GetByClientId(loggedUser.Id);
            return View(bankAccounts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var loggedUser = _signInManager.UserManager.GetUserAsync(HttpContext.User).Result;
            if (loggedUser is null)
            {
                TempData["IsHeSignIn"] = false;
                return RedirectToAction("SignIn", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                var loggedUser = _signInManager.UserManager.GetUserAsync(HttpContext.User).Result;
                bankAccount.Client = loggedUser;
                _bankAccountRepository.Add(bankAccount);
                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int accountNumber)
        {
            var loggedUser = _signInManager.UserManager.GetUserAsync(HttpContext.User).Result;
            if (loggedUser is null)
            {
                TempData["IsHeSignIn"] = false;
                return RedirectToAction("SignIn", "Account");
            }

            var bankAccount = _bankAccountRepository.GetByAccountNumber(accountNumber);
            return View(bankAccount);
        }

        [HttpPost]
        public IActionResult Update(BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                _bankAccountRepository.Update(bankAccount);
                return RedirectToAction("List");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int accountNumber)
        {
            _bankAccountRepository.Delete(accountNumber);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult SearchResult(string bankAccountName, string url)
        {
            var loggedUser = _signInManager.UserManager.GetUserAsync(HttpContext.User).Result;
            if (loggedUser is null)
            {
                TempData["IsHeSignIn"] = false;
                return RedirectToAction("SignIn", "Account");
            }

            if (String.IsNullOrEmpty(bankAccountName))
            {
                return Redirect(url);
            }

            var results = _bankAccountRepository.GetByBankAccountNumberOrName(loggedUser.Id, bankAccountName);
            var viewModel = new SearchResultViewModel
            {
                Results = results,
                SearchText = bankAccountName,
                NumberOfResults = results.ToArray().Length
            };
            return View(viewModel);
        }
    }
}