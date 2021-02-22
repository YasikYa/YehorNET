using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YehorNET.DAL;
using YehorNET.DAL.Domain;

namespace YehorNET.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AccountController(AppDbContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string name, string password)
        {
            var existingUser = _dbContext.Users.Where(u => u.Name.Equals(name)).FirstOrDefault();
            if (existingUser != null)
                return RedirectToAction(nameof(SignUp));

            var user = new User 
            {
                Name = name,
                Password = password,
                Role = "User"
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            await SignInUser(user);
            return RedirectToAction(nameof(Login), "Account", new { name, password });
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string name, string password, string returnUrl)
        {
            var user = _dbContext.Users.Where(u => u.Name.Equals(name)).FirstOrDefault();
            if (user == null)
                return RedirectToAction(nameof(Login));

            await SignInUser(user);
            return string.IsNullOrEmpty(returnUrl) ? (IActionResult)RedirectToAction("Index", "Home") : Redirect(returnUrl);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        private async Task SignInUser(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            };
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "CoockieDefault"));
            await HttpContext.SignInAsync(userPrincipal);
        }
    }
}
