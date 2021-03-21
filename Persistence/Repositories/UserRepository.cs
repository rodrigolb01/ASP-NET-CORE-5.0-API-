using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;
using WebApplication3.Domain.Repositories;
using WebApplication3.Persistence.Context;

namespace WebApplication3.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<User> FirstOrDefaultAsync(String login, String password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task AddAsync(User user)
        {
           await _context.AddAsync(user);
        }
        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
        }
        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
