using System;
using WebApplication3.Domain.Models;

namespace WebApplication3.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; set; }

        private UserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        /// <summary>
        /// creates success response
        /// </summary>
        /// <param name="user">Saved user.</param>
        /// <returns>Response.</returns>
        public UserResponse(User user) : this(true, string.Empty, user)
        {

        }

        /// <summary>
        /// Creates an error message
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : this(false, message, null)
        {

        }
    }
}
