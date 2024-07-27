using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stores.API.Models;
using Stores.API.ViewModel;

namespace Stores.API.Controllers
{
    [ApiController]
    [Route("v1/companies/{companyId}/stores")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly ICompanyService _companyService;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreService storeService, ICompanyService companyService, ILogger<StoreController> logger)
        { 
            _storeService = storeService;
            _companyService = companyService;
            _logger = logger;
        }

        [HttpGet(Name = "GetStores")]
        public async Task<IActionResult> Get(int companyId)
        {
            var stores = await _storeService.GetAllStoresAsync();

            return Ok(stores);
        }

         [HttpPost(Name = "AddStore")]
        public async Task<IActionResult> Add(int companyId, StoreViewModel storeView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var hasCompany = await _companyService.GetByIdAsync(companyId);

                if (hasCompany == null)
                {
                    return BadRequest(new { message = "CompanyId is invalid" });
                }

                var address = new Address(
                    storeView.Address.Street,
                    storeView.Address.City,
                    storeView.Address.State,
                    storeView.Address.Country,
                    storeView.Address.ZipCode
                );

                var store = new Store(
                    companyId,
                    storeView.Name,
                    address,
                    storeView.PhoneNumber
                );

                await _storeService.AddStoreAsync(store);

                return Ok(new { message = "Store created with success" });
            } 
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while creating a store");
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }

        [HttpDelete("{storeId}", Name = "RemoveStore")]
        public async Task<IActionResult> Remove(int companyId, int storeId)
        {
            var hasStore = await _storeService.GetStoreByIdAndCompanyAsync(companyId, storeId);

            if (hasStore == null)
            {
                return NotFound(new { message = "Store not found" });
            }

            try
            {
                await _storeService.RemoveStoreAsync(companyId, storeId);

                return Ok(new { message = "Store deleted with success" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing a store");
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }

        [HttpPatch(Name = "UpdateStore")]
        public async Task<IActionResult> Update(int companyId, StoreViewModel storeView)
        {
            var hasStore = await _storeService.GetStoreByIdAndCompanyAsync(companyId, storeView.Id);

            if (hasStore == null)
            {
                return NotFound(new { message = "Store not found" });
            }

            try
            {
                var address = new Address(
                    storeView.Address.Street,
                    storeView.Address.City,
                    storeView.Address.State,
                    storeView.Address.Country,
                    storeView.Address.ZipCode
                );

                var store = new Store(
                    companyId,
                    storeView.Name,
                    address,
                    storeView.PhoneNumber
                );

                await _storeService.UpdateStoreAsync(storeView.Id, store);

                return Ok(new { message = "Store updated with success" });
            }  
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while updating a store");
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }      

    }
}
