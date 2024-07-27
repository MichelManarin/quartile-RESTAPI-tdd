using System.ComponentModel.DataAnnotations;

namespace Stores.API.Models
{
    public class Address
    {
        public Address() { }

        public Address(string street, string city, string state, string country, string zipCode)
        {
            City = city;
            State = state;
            Street = street;
            Country = country;
            ZipCode = zipCode;
        }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
}