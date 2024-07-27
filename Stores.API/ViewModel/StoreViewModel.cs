using System.ComponentModel.DataAnnotations;

namespace Stores.API.ViewModel
{
    public class StoreViewModel
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "Store name is required.")]
        [StringLength(100, ErrorMessage = "Store name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public AddressViewModel Address { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public StoreViewModel()
        {
        }
        public StoreViewModel(int companyId, string name, AddressViewModel address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
