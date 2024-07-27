using Stores.API.Models;

namespace Stores.API.Infrastructure.Repositories
{
    public interface IStoreRepository
    {
        void Add(Store store);
        void Delete(int companyId, int id);
        void Update(int id, Store store);
        Store? GetStore(int companyId, int id);
        List<Store> GetAll();
    }
}
