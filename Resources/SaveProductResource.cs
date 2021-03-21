using System.ComponentModel.DataAnnotations;
using WebApplication3.Domain.Helpers;

namespace WebApplication3.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double value { get; set; }
        [Required]
        public string observation { get; set; }
    }
}
