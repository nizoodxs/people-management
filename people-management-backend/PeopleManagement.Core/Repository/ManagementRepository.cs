using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.Repository
{
    public class ManagementRepository : IManagementRepository
    {
        public Task AddAddressToPersonAsync(Guid personId, Address address)
        {
            throw new NotImplementedException();
        }

        public Task AddPersonAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAddress(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Task DeletePersonAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Address?> GetAddressByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetPersonByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAddressAsync(Address address)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonAsync(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
