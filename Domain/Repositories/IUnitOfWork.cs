using System.Threading.Tasks;

namespace WebApplication3.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
