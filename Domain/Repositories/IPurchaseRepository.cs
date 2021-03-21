using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;

namespace WebApplication3.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> ListAsync();

        Task AddAsync(Purchase purchase);

        Task<Purchase> FindByIdAsync(int id);

        void Update(Purchase purchase);

        void Remove(Purchase purchase);
    }
}
