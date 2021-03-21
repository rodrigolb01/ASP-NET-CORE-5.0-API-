using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Resources
{
    public class SaveUserResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Login { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        public long Cpf { get; set; }
    }
}
