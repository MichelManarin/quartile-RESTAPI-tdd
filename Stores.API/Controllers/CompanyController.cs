using Microsoft.AspNetCore.Mvc;
using Stores.API.Models;
using Stores.API.ViewModel;

namespace Stores.API.Controllers
{
    [ApiController]
    [Route("v1/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger) { 
            _companyService = companyService;
            _logger = logger;
        }

        [HttpGet(Name = "GetCompanies")]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var companys = await _companyService.GetAllCompaniesAsync();
                return Ok(companys);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while request companies");
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }

        [HttpPost(Name = "AddCompany")]
        public async Task<IActionResult> Add(CompanyViewModel companyView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var address = new Address(
                    companyView.Address.Street, 
                    companyView.Address.City, 
                    companyView.Address.State, 
                    companyView.Address.Country, 
                    companyView.Address.ZipCode
                );
                
                var company = new Company(companyView.Name, address);

                await _companyService.AddCompanyAsync(company);

                return Ok(new { message = "Company created with success" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a company");
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
           
        }

    }
}
