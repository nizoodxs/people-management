using Microsoft.EntityFrameworkCore;
using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;
using PeopleManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _dbContext;

        public AddressRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAddressToPersonAsync(Guid personId, Address address)
        {
            var person = await _dbContext.People.FindAsync(personId) ?? throw new Exception("Person does not exists");
            address.Person = person;
            await _dbContext.Addresses.AddAsync(address);
        }

        public async Task DeleteAddress(Guid addressId)
        {
            var address = await _dbContext.Addresses.FindAsync(addressId);
            if (address != null)
            {
                _dbContext.Addresses.Remove(address);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Address?> GetAddressByIdAsync(Guid id)
        {
            return await _dbContext.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAllAddressesForPersonAsync(Guid personId)
        {
            return await _dbContext.Addresses.Where(a =>a.PersonId == personId).ToListAsync();
        }

        public async Task UpdateAddressAsync(Address address)
        {
            _dbContext.Addresses.Update(address);
            await _dbContext.SaveChangesAsync();
        }
    }
}
