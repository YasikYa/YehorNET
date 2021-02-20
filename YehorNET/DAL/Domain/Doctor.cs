using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.DAL.Domain
{
    public class Doctor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactPhone { get; set; }

        public int Age { get; set; }

        public int VisitPrice { get; set; }

        public DateTime ProffecionalExperienceFrom { get; set; }

        public Clinic Clinic { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<TreatmentBranch> Treatments { get; set; }

        public ICollection<DoctorEducation> EducationUnits { get; set; }
    }
}
