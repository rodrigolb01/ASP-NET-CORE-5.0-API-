using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;

namespace WebApplication3.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> ListAsync();
        Task AddAsync(Company company);
        Task<Company> FindByIdAsync(int id);
        void Update(Company company);
        void Remove(Company company);


    }
}
