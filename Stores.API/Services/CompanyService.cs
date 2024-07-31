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
            return await _companyRepository.GetAll();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _companyRepository.Get(id);
        }

        public async Task AddCompanyAsync(Company company)
        {
            await _companyRepository.Add(company);
        }
    }
}
