using Stores.API.Models;

namespace Stores.API.Infrastructure.Repositories
{
    public interface ICompanyRepository
    {
        void Add(Company company);
        List<Company> GetAll();
        Company? Get(int id);
    }
}
