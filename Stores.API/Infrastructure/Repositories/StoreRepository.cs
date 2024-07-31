using Microsoft.EntityFrameworkCore;
using Stores.API.Models;

namespace Stores.API.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ConnectionContext _context;

        public StoreRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await _context.Stores
               .Include(s => s.Company)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task Add(Store store)
        {
            _context.Add(store);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int companyId, int id)
        {
            var store = _context.Stores
              .FirstOrDefault(s => s.Id == id && s.CompanyId == companyId);

            if (store == null)
            {
                throw new ArgumentException("Store not found.");
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Store store)
        {
            var existingStore = _context.Stores.Find(id);

            if (existingStore == null)
            {
                throw new ArgumentException("Store not found.");
            }

            existingStore.Name = store.Name;
            existingStore.Address = store.Address;
            existingStore.PhoneNumber = store.PhoneNumber;
            existingStore.Address = store.Address;
            await _context.SaveChangesAsync();
        }

        async Task<Store?> IStoreRepository.GetStore(int companyId, int id)
        {
            return await _context.Stores
                .Where(store => store.CompanyId == companyId && store.Id == id)
                .FirstOrDefaultAsync();
        }

        async Task<List<Store>> IStoreRepository.GetAll()
        {
            return await _context.Stores.ToListAsync();
        }
    }
}
