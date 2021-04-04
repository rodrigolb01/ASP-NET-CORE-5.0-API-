using System.Collections.Generic;
using WebApplication3.Domain.Helpers;

namespace WebApplication3.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string Observation { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public IList<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
