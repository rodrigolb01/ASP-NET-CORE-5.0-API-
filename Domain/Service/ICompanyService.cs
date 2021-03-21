using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Communication;
using WebApplication3.Domain.Models;

namespace WebApplication3.Domain.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> ListAsync();
        Task<CompanyResponse> SaveAsync(Company company);
        Task<CompanyResponse> UpdateAsync(int id, Company company);

        Task<CompanyResponse> DeleteAsync(int id);
    }
}
