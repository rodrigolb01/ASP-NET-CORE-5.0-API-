using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;

namespace WebApplication3.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();

        Task AddAsync(Product product);

        Task<Product> FindByIdAsync(int id);

        void Update(Product product);

        void Remove(Product product);
    }
}
