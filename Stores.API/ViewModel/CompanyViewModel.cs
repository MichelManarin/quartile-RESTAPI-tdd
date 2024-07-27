using Stores.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Stores.API.ViewModel
{
    public class CompanyViewModel
    {
        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(100, ErrorMessage = "Company name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public AddressViewModel Address { get; set; }

        public CompanyViewModel()
        {
        }
        public CompanyViewModel(string name, AddressViewModel address)
        {
            Name = name;
            Address = address;
        }
    }
}
