
using System.ComponentModel;

namespace WebApplication3.Domain.Helpers
{
    public enum EPurchaseStatus
    {
        [Description("Order sent")]
        sent = 1,

        [Description("Order in processing")]
        processing = 2,

        [Description("Order accepted")]
        accepted = 3,

        [Description("Order rejected")]
        rejected = 4,

        [Description("Order shipped")]
        shipped = 5
    }
}
