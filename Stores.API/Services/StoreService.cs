using Stores.API.Infrastructure.Repositories;
using Stores.API.Models;

namespace Stores.API.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<List<Store>> GetAllStoresAsync()
        {
            return await _storeRepository.GetAll();
        }

        public async Task AddStoreAsync(Store store)
        {
            await _storeRepository.Add(store);
        }

        public async Task UpdateStoreAsync(int id, Store store)
        {
            await _storeRepository.Update(id, store);
        }
        public async Task RemoveStoreAsync(int companyId, int id)
        {
            await _storeRepository.Delete(companyId, id);
        }

        public async Task<Store?> GetStoreByIdAndCompanyAsync(int companyId, int id)
        {
           return await _storeRepository.GetStore(companyId, id);
        }
    }
}
