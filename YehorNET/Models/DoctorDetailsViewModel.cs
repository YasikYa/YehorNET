using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.Models
{
    public class DoctorDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactPhone { get; set; }

        public int Age { get; set; }

        public int VisitPrice { get; set; }

        public double Rating { get; set; }

        public DateTime ProffecionalExperienceFrom { get; set; }

        public ClinicViewModel Clinic { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }

    public class CommentViewModel
    {
        public double Rate { get; set; }

        public string Text { get; set; }
    }

    public class ClinicViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SiteUrl { get; set; }
    }
}
