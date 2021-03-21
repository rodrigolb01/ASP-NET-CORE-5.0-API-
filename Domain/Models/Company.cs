using System.Collections.Generic;

namespace WebApplication3.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public long CNPJ { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
