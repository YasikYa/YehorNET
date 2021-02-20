using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YehorNET.DAL;
using YehorNET.Models;

namespace YehorNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext) => _dbContext = dbContext;

        public IActionResult Index()
        {
            return View();
        }
    }
}
