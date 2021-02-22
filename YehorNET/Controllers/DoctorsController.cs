using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
        public IActionResult List(string searchString, Guid[] treatments, string sortingOrder)
        {
            var selectQuery = _dbContext.Doctors.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
                selectQuery = selectQuery.Where(d => d.Name.Contains(searchString));
            if (treatments != null && treatments.Length != 0)
                selectQuery = selectQuery.Where(d => d.Treatments.Any(t => treatments.Any(filterTreatment => filterTreatment.Equals(t.Id))));

            var result = selectQuery.Select(d => new DoctorsListItemViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Rate = d.Comments.Count == 0 ? 0 : Math.Round(d.Comments.Select(c => c.Rate).Average(), 2),
                CommentsCount = d.Comments.Count,
                Treats = d.Treatments.Select(tb => tb.Name).ToList()
            });

            if (sortingOrder == "rate_desc")
                result = result.OrderByDescending(m => m.Rate);

            ViewBag.RateSort = Url.ActionLink(nameof(List), "Doctors", new { searchString, treatments, sortingOrder = string.IsNullOrEmpty(sortingOrder) ? "rate_desc" : "" });
            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Details(Guid id, string searchListUrl)
        {
            var detailsModel = _dbContext.Doctors.Where(d => d.Id == id)
                .Select(d => new DoctorDetailsViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Age = d.Age,
                    ContactPhone = d.ContactPhone,
                    Rating = d.Comments.Count == 0 ? 0 : Math.Round(d.Comments.Select(c => c.Rate).Average(), 2),
                    ProffecionalExperienceFrom = d.ProffecionalExperienceFrom,
                    VisitPrice = d.VisitPrice,
                    Treats = d.Treatments.Select(t => new TreatLookupViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList(),
                    Clinic = new ClinicViewModel
                    {
                        Id = d.Clinic.Id,
                        Name = d.Clinic.Title,
                        SiteUrl = d.Clinic.WebsiteUrl
                    },
                    Educations = d.EducationUnits.Select(e => new EducationViewModel
                    {
                        Title = e.Title,
                        SubTitle = e.SubTitle,
                        From = e.From,
                        To = e.To
                    }).ToList(),
                    Comments = d.Comments.Select(c => new CommentViewModel
                    {
                        Rate = c.Rate,
                        Text = c.Text,
                        Date = c.Date
                    }).OrderBy(c => c.Date).ToList()
                }).FirstOrDefault();

            ViewBag.ReturnUrl = searchListUrl;
            return View(detailsModel);
        }

        [HttpPost]
        public IActionResult Comment(Guid id, string searchListUrl, CommentViewModel model)
        {
            var doctor = _dbContext.Doctors.Where(d => d.Id == id).FirstOrDefault();
            _dbContext.DoctorsComments.Add(new Comment
            {
                Id = Guid.NewGuid(),
                Text = model.Text,
                Rate = (int)model.Rate,
                Date = DateTime.Now,
                Doctor = doctor
            });
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Details), new { id, searchListUrl });
        }


        [HttpGet]
        public IActionResult Create()
        {
            var existingClinics = _dbContext.Clinics.Select(c => new ClinicLookupViewModel { Id = c.Id, Name = c.Title }).ToList();
            var existingTreats = _dbContext.TreatmentBranches.Select(t => new TreatLookupViewModel { Id = t.Id, Name = t.Name }).ToList();
            ViewBag.Clinics = existingClinics;
            ViewBag.Treats = existingTreats;
            return View();
        }

        [HttpPost]
        public IActionResult Create(DoctorCreateModel model)
        {
            var clinic = _dbContext.Clinics.Where(c => c.Id == model.ClinicId).First();
            var addDoctor = new Doctor
            {
                Age = model.Age,
                Name = model.Name,
                ContactPhone = model.ContactPhone,
                VisitPrice = model.VisitPrice,
                ProffecionalExperienceFrom = model.ProffecionalExperienceFrom,
                Clinic = clinic
            };
            _dbContext.Doctors.Add(addDoctor);
            foreach (var treatId in model.Treats)
            {
                _dbContext.TreatmentBranches.Find(treatId).Doctors.Add(addDoctor);
            }
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}
