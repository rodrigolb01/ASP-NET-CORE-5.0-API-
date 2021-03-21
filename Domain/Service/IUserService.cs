using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;
using WebApplication3.Communication;
using System;

namespace WebApplication3.Domain.Services
{
    public interface IUserService
    {
        Task<User> FirstOrDefaultAsync(String login, String password);
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
