using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YehorNET.DAL.Domain
{
    public class User
    {
        public User()
        {
            Comments = new List<Comment>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
