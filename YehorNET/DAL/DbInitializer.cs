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
            if (context.Doctors.Any())
                return;

            context.Users.Add(new User
            {
                Name = "admin",
                Password = "admin",
                Role = "Admin"
            });

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
                EducationUnits = new List<DoctorEducation> { new DoctorEducation { Id = Guid.NewGuid(), Title = "KNMU", SubTitle = "Test subtitle", From = new DateTime(1996, 9, 1), To = new DateTime(2000, 6, 1) } }
            });
            context.Doctors.Add(new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Juk Maickyi",
                Age = 31,
                ContactPhone = "333333333",
                ProffecionalExperienceFrom = new DateTime(2005, 12, 1),
                VisitPrice = 450,
                Clinic = new Clinic
                {
                    Id = Guid.NewGuid(),
                    Title = "GoldenHealth",
                    Address = "Na",
                    ContactNumber = "777",
                    WebsiteUrl = "http://golden.org"
                },
                Treatments = new List<TreatmentBranch>
                {
                    new TreatmentBranch { Id = Guid.NewGuid(), Name = "Lore" }
                },
                EducationUnits = new List<DoctorEducation> { new DoctorEducation { Id = Guid.NewGuid(), Title = "KNMU", SubTitle = "Test subtitle", From = new DateTime(2000, 9, 1), To = new DateTime(2005, 6, 1) } }
            });
            context.SaveChanges();
        }
    }
}
