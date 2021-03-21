
using System.ComponentModel;

namespace WebApplication3.Domain.Helpers
{
    public enum EPaymentMethod : byte
    {
        [Description("Boleto")]
        Boleto = 1,

        [Description("Cartao de Credito")]
        CartaoDeCredito = 2,

        [Description("Cartao de Debito")]
        CartaoDeDebito = 3,
    }
}
