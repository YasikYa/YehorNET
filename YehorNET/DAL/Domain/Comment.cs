using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.DAL.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }

        public int Rate { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Doctor Doctor { get; set; }

        public User User { get; set; }
    }
}
