using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Communication;
using WebApplication3.Domain.Models;

namespace WebApplication3.Domain.Services
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> ListAsync();
        Task<PurchaseResponse> SaveAsync(Purchase purchase);
        Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase);
        Task<PurchaseResponse> DeleteAsync(int id);
    }
}
