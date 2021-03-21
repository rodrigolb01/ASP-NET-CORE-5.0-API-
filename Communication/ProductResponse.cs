using System;
using WebApplication3.Domain.Models;

namespace WebApplication3.Communication
{
    public class ProductResponse : BaseResponse
    {
        public Product Product { get; set; }

        private ProductResponse(bool success, String message, Product product) : base(success, message)
        {
            Product = product;
        }

        /// <summary>
        /// creates success response
        /// </summary>
        /// <param name="product">Saved product.</param>
        /// <returns>Response.</returns>
        public ProductResponse(Product product) : this(true, string.Empty, product)
        {

        }

        /// <summary>
        /// Creates an error message
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProductResponse(string message) : this(false, message, null)
        {

        }
    }
}
