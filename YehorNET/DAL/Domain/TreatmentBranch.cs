using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.DAL.Domain
{
    public class TreatmentBranch
    {
        public TreatmentBranch()
        {
            Doctors = new List<Doctor>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
