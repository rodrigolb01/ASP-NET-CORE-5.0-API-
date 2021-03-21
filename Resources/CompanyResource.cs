using System.Collections.Generic;
using WebApplication3.Domain.Models;

namespace WebApplication3.Resources
{
    public class CompanyResource
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public long CNPJ { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
