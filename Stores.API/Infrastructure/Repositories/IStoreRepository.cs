using Stores.API.Models;

namespace Stores.API.Infrastructure.Repositories
{
    public interface IStoreRepository
    {
        Task Add(Store store);
        Task Delete(int companyId, int id);
        Task Update(int id, Store store);
        Task<Store?> GetStore(int companyId, int id);
        Task<List<Store>> GetAll();
    }
}
