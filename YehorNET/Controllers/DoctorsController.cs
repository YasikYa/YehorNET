using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YehorNET.DAL;
using YehorNET.Models;

namespace YehorNET.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DoctorsController(AppDbContext dbContext) => _dbContext = dbContext;

        public IActionResult Search(string searchString)
        {
            var matches = _dbContext.Doctors.Where(d => d.Name.Contains(searchString))
                .Select(d => new DoctorsListItemViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    //Rate = d.Comments.Select(c => c.Rate).Average(),
                    CommentsCount = d.Comments.Count,
                    //Treats = d.TreatmentBranches.Select(tb => tb.Name).ToList()
                }).ToList();

            return View(matches);
        }
    }
}
