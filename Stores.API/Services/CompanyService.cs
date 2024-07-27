using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stores.API.Infrastructure.Repositories;
using Stores.API.Models;

namespace Stores.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await Task.Run(() => _companyRepository.GetAll());
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _companyRepository.Get(id));
        }

        public async void AddCompanyAsync(Company company)
        {
            await Task.Run(() => _companyRepository.Add(company));
        }
    }
}
