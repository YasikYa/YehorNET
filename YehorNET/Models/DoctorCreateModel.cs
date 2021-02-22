using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.Models
{
    public class DoctorCreateModel
    {
        public string Name { get; set; }

        public string ContactPhone { get; set; }

        public int Age { get; set; }

        public int VisitPrice { get; set; }

        public DateTime ProffecionalExperienceFrom { get; set; }

        public Guid ClinicId { get; set; }

        public ICollection<Guid> Treats { get; set; }
    }
}
