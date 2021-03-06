﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YehorNET.DAL.Domain;
using YehorNET.DAL.ModelConfigurations;

namespace YehorNET.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<DoctorEducation> DoctorsEducations { get; set; }

        public DbSet<TreatmentBranch> TreatmentBranches { get; set; }

        public DbSet<Comment> DoctorsComments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        }
    }
}
