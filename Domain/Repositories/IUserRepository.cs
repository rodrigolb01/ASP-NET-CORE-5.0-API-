using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;

namespace WebApplication3.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();

        Task<User> FirstOrDefaultAsync(String login, String password);

        Task AddAsync(User product);

        Task<User> FindByIdAsync(int id);

        void Update(User user);

        void Remove(User user);
    }
}
