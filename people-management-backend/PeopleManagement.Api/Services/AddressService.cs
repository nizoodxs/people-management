using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;

namespace PeopleManagement.Api.Services
{
    public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository) => _addressRepository = addressRepository;

        public async Task<Address?> GetAddressByIdAsync(Guid id)
        {
            return await _addressRepository.GetAddressByIdAsync(id);
        }
        public async Task<IEnumerable<Address>> GetAllAddressForPersonAsync(Guid personId)
        {
            return await _addressRepository.GetAllAddressesForPersonAsync(personId);
        }
        public async Task AddAddressToPersonAsync(Guid personId, Address address)
        {
            await _addressRepository.AddAddressToPersonAsync(personId, address);
        }
        public async Task UpdateAddressAsync(Address address)
        {
            await _addressRepository.UpdateAddressAsync(address);
        }
        public async Task DeleteAddressAsync(Guid id)
        {
            await _addressRepository.DeleteAddress(id);
        }
    }
}
