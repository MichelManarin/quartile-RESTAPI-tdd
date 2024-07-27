using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.API.Models
{
    [Table("store")]
    public class Store
    {
        public Store() { }

        public Store(int companyId, string name, Address address, string phoneNumber)
        {
            Name = name;
            Address = address;
            CompanyId = companyId;
            PhoneNumber = phoneNumber;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Address Address { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
