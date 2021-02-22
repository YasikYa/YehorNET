using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.DAL.Domain
{
    public class Clinic
    {
        public Clinic()
        {
            Doctors = new List<Doctor>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ContactNumber { get; set; }

        public string WebsiteUrl { get; set; }

        public string Address { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
