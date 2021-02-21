using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            CreateTreatFilter();
            return View();
        }

        private void CreateTreatFilter()
        {
            var selectList = new List<SelectListItem>();
            var existingTreats = _dbContext.TreatmentBranches.ToList();
            selectList.Add(new SelectListItem("All", null, true));
            foreach (var treat in existingTreats)
            {
                selectList.Add(new SelectListItem(treat.Name, treat.Id.ToString()));
            }
            ViewBag.TreatFilter = selectList;
        }
    }
}
