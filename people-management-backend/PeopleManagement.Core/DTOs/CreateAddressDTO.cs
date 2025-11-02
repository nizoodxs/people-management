using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.DTOs
{
    public class CreateAddressDTO
    {
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }= string.Empty;
        public string Town { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }

    public class AddAddressDTO
    {
        public Guid personId { get; set; }
        public CreateAddressDTO address { get; set; }
    }
}
