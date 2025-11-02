using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address?> GetAddressByIdAsync(Guid id);
        Task<IEnumerable<Address>> GetAllAddressesForPersonAsync(Guid personId);
        Task AddAddressToPersonAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddress(Guid addressId);
    }
}
