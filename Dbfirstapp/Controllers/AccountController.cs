using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dbfirstapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dbfirstapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ecommerceContext _context;

        public AccountController(ecommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await _context.Userdetails
                .SingleOrDefaultAsync(m => m.Email == model.Email && m.Password == model.Password);
                if (userdetails == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Index");
                }
                HttpContext.Session.SetString("userId", userdetails.Name);

            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<ActionResult> Registar(RegistrationViewModel model)
        {

            if (ModelState.IsValid)
            {
                Userdetails user = new Userdetails
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    Mobile = model.Mobile

                };
                _context.Add(user);
                await _context.SaveChangesAsync();

            }
            else
            {
                return View("Registration");
            }
            return RedirectToAction("Index", "Account");
        }
        // registration Page load
        public IActionResult Registration()
        {
            ViewData["Message"] = "Registration Page";

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        public void ValidationMessage(string key, string alert, string value)
        {
            try
            {
                TempData.Remove(key);
                TempData.Add(key, value);
                TempData.Add("alertType", alert);
            }
            catch
            {
                Debug.WriteLine("TempDataMessage Error");
            }

        }
    }
}