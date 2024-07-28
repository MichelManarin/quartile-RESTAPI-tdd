using Stores.API.Models;
using Stores.API.ViewModel;

public interface ICompanyService
{
    Task<List<Company>> GetAllCompaniesAsync();
    Task<Company?> GetByIdAsync(int id);
    Task AddCompanyAsync(Company company);
}