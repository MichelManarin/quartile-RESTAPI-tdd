using Stores.API.Infrastructure;
using Stores.API.Models;

namespace Stores.API.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ConnectionContext _context;

        public CompanyRepository(ConnectionContext context)
        {
            _context = context;
        }

        public void Add(Company company)
        {
            _context.Add(company);
            _context.SaveChanges();
        }

        public List<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public Company? Get(int id)
        {
            return _context.Companies.Find(id);
        }
    }
}
