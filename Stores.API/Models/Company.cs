using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.API.Models
{
    [Table("company")]
    public class Company
    {
        public Company() { }

        public Company(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] 
        public Address Address { get; set; }
    }
}
