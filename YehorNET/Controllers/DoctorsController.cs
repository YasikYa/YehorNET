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
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DoctorsController(AppDbContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public IActionResult List(string searchString, string[] treatments)
        {
            var selectQuery = _dbContext.Doctors.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
                selectQuery = selectQuery.Where(d => d.Name.Contains(searchString));
            if (treatments != null && treatments.Length != 0)
                selectQuery = selectQuery.Where(d => d.Treatments.Any(t => treatments.Any(filterTreatment => filterTreatment.Equals(t))));

            var result = selectQuery.Select(d => new DoctorsListItemViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Rate = d.Comments.Count == 0 ? 0 : d.Comments.Select(c => c.Rate).Average(),
                CommentsCount = d.Comments.Count,
                Treats = d.Treatments.Select(tb => tb.Name).ToList()
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var detailsModel = _dbContext.Doctors.Where(d => d.Id == id)
                .Select(d => new DoctorDetailsViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Age = d.Age,
                    ContactPhone = d.ContactPhone,
                    Rating = d.Comments.Count == 0 ? 0 : d.Comments.Select(c => c.Rate).Average(),
                    ProffecionalExperienceFrom = d.ProffecionalExperienceFrom,
                    VisitPrice = d.VisitPrice,
                    Clinic = new ClinicViewModel
                    {
                        Id = d.Clinic.Id,
                        Name = d.Clinic.Title,
                        SiteUrl = d.Clinic.WebsiteUrl
                    },
                    Comments = d.Comments.Select(c => new CommentViewModel
                    {
                        Rate = c.Rate,
                        Text = c.Comments
                    }).ToList()
                }).FirstOrDefault();

            return View(detailsModel);
        }

        [HttpPost]
        public IActionResult Comment(Guid id, CommentViewModel model)
        {
            _dbContext.DoctorsComments.Add(new Comment
            {
                Id = Guid.NewGuid(),
                Comments = model.Text,
                Rate = (int)model.Rate,
                Doctor = new Doctor { Id = id }
            });
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
