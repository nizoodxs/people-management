using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> GetPersonByIdAsync(Guid id);
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Guid id);

        //included address in the same repository but for scaling/in future use different repository for each data entity
        Task<Address?> GetAddressByIdAsync(Guid id);
        Task AddAddressToPersonAsync(Guid personId, Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddress(Guid addressId);

        Task<int> SaveChangesAsync(); // for unit of work
    }
}
