using Stores.API.Models;

public interface IStoreService
{
    Task<List<Store>> GetAllStoresAsync();
    Task AddStoreAsync(Store store);
    Task RemoveStoreAsync(int companyId, int id);
    Task UpdateStoreAsync(int id, Store store);
    Task<Store?> GetStoreByIdAndCompanyAsync(int companyId, int id);
}