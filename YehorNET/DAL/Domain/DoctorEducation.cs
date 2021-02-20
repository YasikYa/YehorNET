using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.DAL.Domain
{
    public class DoctorEducation
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public Doctor Doctor { get; set; }
    }
}
