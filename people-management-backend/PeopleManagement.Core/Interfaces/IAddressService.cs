using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.Interfaces
{
    public interface IAddressService
    {
        Task<Address?> GetAddressByIdAsync(Guid id);
        Task<IEnumerable<Address>> GetAllAddressForPersonAsync(Guid personId);
        Task AddAddressToPersonAsync(Guid personId, Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(Guid id);
    }
}
