using System;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Domain.Helpers;

namespace WebApplication3.Resources
{
    public class SavePurchaseResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double TotalValue { get; set; }
        [Required]
        public EPaymentMethod PaymentMethod { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public EPurchaseStatus Status { get; set; }
        [Required]
        [MaxLength(60)]
        public string Observation { get; set; }
        [Required]
        [MaxLength(8)]
        public string Cep { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
