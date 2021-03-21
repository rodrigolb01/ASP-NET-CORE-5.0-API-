using System;
using WebApplication3.Domain.Helpers;

namespace WebApplication3.Domain.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public double TotalValue { get; set; }
        public EPaymentMethod PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public EPurchaseStatus Status { get; set; }
        public string Observation { get; set; }
        public string Cep { get; set; }
        public string Address { get; set; }
    }
}
