using Stores.API.Infrastructure;
using Stores.API.Models;
using System.ComponentModel.Design;

namespace Stores.API.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ConnectionContext _context;

        public StoreRepository(ConnectionContext context)
        {
            _context = context;
        }

        public void Add(Store store)
        {
            _context.Add(store);
            _context.SaveChanges();
        }
        public Store? GetStore(int companyId, int id)
        {
            return _context.Stores
                .Where(store => store.CompanyId == companyId && store.Id == id)
                .FirstOrDefault();
        }

        public List<Store> GetAll()
        {
            return _context.Stores.ToList();
        }

        public void Delete(int companyId, int id)
        {
            var store = _context.Stores
              .FirstOrDefault(s => s.Id == id && s.CompanyId == companyId);

            if (store == null)
            {
                throw new ArgumentException("Store not found.");
            }

            _context.Stores.Remove(store);
            _context.SaveChanges();
        }
        public void Update(int id, Store store)
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
            _context.SaveChanges();
        }
    }
}
