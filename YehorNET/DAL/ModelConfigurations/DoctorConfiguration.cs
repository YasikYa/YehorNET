using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YehorNET.DAL.Domain;

namespace YehorNET.DAL.ModelConfigurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Pavel Morozov",
                Age = 31,
                ContactPhone = "1111111111",
                ProffecionalExperienceFrom = new DateTime(2000, 12, 1),
                VisitPrice = 500,
                TreatmentBranches = new List<TreatmentBranch> { new TreatmentBranch { Id = Guid.NewGuid(), Name = "Therapist"} },
                Clinic = new Clinic
                {
                    Id = Guid.NewGuid(),
                    ContactNumber = "22222222",
                    Title = "NURE",
                    WebsiteUrl = "http://dummyurl.org",
                    Address = "NA"
                }
            });
        }
    }
}
