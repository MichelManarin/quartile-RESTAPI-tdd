using Microsoft.EntityFrameworkCore;
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

        public async Task Add(Company company)
        {
            _context.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company?> Get(int id)
        {
            return await _context.Companies.FindAsync(id);
        }
    }
}
