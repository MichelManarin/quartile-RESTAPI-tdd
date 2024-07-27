using System.ComponentModel.DataAnnotations;

namespace Stores.API.ViewModel
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "Street is required.")]
        [StringLength(100, ErrorMessage = "Street can't be longer than 100 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City can't be longer than 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "State can't be longer than 50 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country can't be longer than 50 characters.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "ZipCode is required.")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid ZipCode format.")]
        public string ZipCode { get; set; }

        public AddressViewModel()
        {
        }

        public AddressViewModel(string street, string city, string state, string country, string zipCode)
        {
            City = city;
            State = state;
            Street = street;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
