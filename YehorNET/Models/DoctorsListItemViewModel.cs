using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.Models
{
    public class DoctorsListItemViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<string> Treats { get; set; }

        public double Rate { get; set; }

        public int CommentsCount { get; set; }
    }
}
