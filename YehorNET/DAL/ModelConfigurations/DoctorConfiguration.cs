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
            builder.HasMany(d => d.Comments)
                   .WithOne(c => c.Doctor)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Clinic)
                   .WithMany(c => c.Doctors)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(d => d.EducationUnits)
                   .WithOne(eu => eu.Doctor)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.Treatments)
                   .WithMany(t => t.Doctors);

        }
    }
}
