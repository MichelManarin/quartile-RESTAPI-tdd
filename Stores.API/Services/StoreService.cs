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
            return await Task.Run(() => _storeRepository.GetAll());
        }

        public async Task AddStoreAsync(Store store)
        {
            await Task.Run(() => _storeRepository.Add(store));
        }

        public async Task UpdateStoreAsync(int id, Store store)
        {
            await Task.Run(() => _storeRepository.Update(id, store));
        }
        public async Task RemoveStoreAsync(int companyId, int id)
        {
            await Task.Run(() => _storeRepository.Delete(companyId, id));
        }

        public Task<Store?> GetStoreByIdAndCompanyAsync(int companyId, int id)
        {
            return Task.Run(() => _storeRepository.GetStore(companyId, id));
        }
    }
}
