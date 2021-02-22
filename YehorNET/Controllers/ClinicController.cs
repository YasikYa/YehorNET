using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YehorNET.DAL;
using YehorNET.DAL.Domain;
using YehorNET.Models;

namespace YehorNET.Controllers
{
    public class ClinicController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ClinicController(AppDbContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public IActionResult Create(string callbackUrl)
        {
            ViewBag.ReturnUrl = callbackUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateClinicViewModel model, string callbackUrl)
        {
            _dbContext.Clinics.Add(new Clinic
            {
                Title = model.Name,
                Address = model.Address,
                ContactNumber = model.ContactPhone,
                WebsiteUrl = model.SiteUrl
            });
            _dbContext.SaveChanges();
            return string.IsNullOrEmpty(callbackUrl) ? RedirectToAction("Index", "Home") : (IActionResult)Redirect(callbackUrl);
        }
    }
}
