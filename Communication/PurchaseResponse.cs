using System;
using WebApplication3.Domain.Models;

namespace WebApplication3.Communication
{
    public class PurchaseResponse : BaseResponse
    {
        public Purchase Purchase { get; set; }
        public PurchaseResponse(bool success, string message, Purchase purchase) : base(success, message)
        {
            Purchase = purchase;
        }

        /// <summary>
        /// creates success response
        /// </summary>
        /// <param name="purchase">Saved purchase.</param>
        /// <returns>Response.</returns>
        public PurchaseResponse(Purchase purchase) : this(true, string.Empty, purchase)
        {

        }

        /// <summary>
        /// Creates an error message
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PurchaseResponse(string message) : this(false, message, null)
        {

        }
    }
}
