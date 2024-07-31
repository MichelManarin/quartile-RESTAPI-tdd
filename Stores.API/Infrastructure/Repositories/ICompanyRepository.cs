using Stores.API.Models;

namespace Stores.API.Infrastructure.Repositories
{
    public interface ICompanyRepository
    {
        Task Add(Company company);
        Task<List<Company>> GetAll();
        Task<Company?> Get(int id);
    }
}
