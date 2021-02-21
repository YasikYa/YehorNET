using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YehorNET.DAL.Domain;

namespace YehorNET.DAL
{
    public static class DbInitializer
    {
        public static void SeedData(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Doctors.Any())
                return;

            context.Doctors.Add(new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Pavel Morozov",
                Age = 31,
                ContactPhone = "1111111111",
                ProffecionalExperienceFrom = new DateTime(2000, 12, 1),
                VisitPrice = 500,
                Clinic = new Clinic
                {
                    Id = Guid.NewGuid(),
                    Title = "EasyTreat",
                    Address = "Na",
                    ContactNumber = "22222222222",
                    WebsiteUrl = "http://dummyurl.org"
                },
                Treatments = new List<TreatmentBranch>
                {
                    new TreatmentBranch { Id = Guid.NewGuid(), Name = "Dentist" }
                },
                EducationUnits = new List<DoctorEducation> { new DoctorEducation { Id = Guid.NewGuid(), Title = "KNMU", SubTitle = "Test subtitle", From = new DateTime(1996, 9, 1), To = new DateTime(2000, 6, 1) } },
                Comments = new List<Comment> { new Comment { Id = Guid.NewGuid(), Rate = 5, Text = "Nice!", Date = DateTime.Now.AddDays(-1) } }
            });
            context.SaveChanges();
        }
    }
}
