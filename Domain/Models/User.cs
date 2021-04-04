using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public long CPF { get; set; }
        public IList<Purchase> purchases { get; set; } = new List<Purchase>();
    }
}
