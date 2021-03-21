using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Resources
{
    public class SaveCompanyResource
    {
        [Required]
        int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string nomeFantasia { get; set; }
        [Required]
        [MaxLength(30)]
        public string razaoSocial { get; set; }
        [Required]
        public long cnpj { get; set; }
    }
}
