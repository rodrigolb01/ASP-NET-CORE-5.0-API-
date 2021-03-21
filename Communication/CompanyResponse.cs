using WebApplication3.Domain.Models;

namespace WebApplication3.Communication
{
    public class CompanyResponse : BaseResponse
    {
        public Company Company { get; private set; }

        private CompanyResponse(bool success, string message, Company company) : base(success, message)
        {
            Company = company;
        }


        /// <summary>
        /// creates success response
        /// </summary>
        /// <param name="company">Saved company.</param>
        /// <returns>Response.</returns>
        public CompanyResponse(Company company) : this(true, string.Empty, company)
        {

        }

        /// <summary>
        /// Creates an error message
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CompanyResponse(string message) : this(false, message, null)
        {

        }
    }
}
