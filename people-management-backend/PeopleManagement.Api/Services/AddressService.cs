using PeopleManagement.Core.DTOs;
using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;

namespace PeopleManagement.Api.Services
{
    public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<AddressService> _logger;

        public AddressService(ILogger<AddressService> logger, IAddressRepository addressRepository)
        {
            _logger = logger;
            _addressRepository = addressRepository;
        }

        public async Task<Address?> GetAddressByIdAsync(Guid id)
        {
            return await _addressRepository.GetAddressByIdAsync(id);
        }
        public async Task<IEnumerable<Address>> GetAllAddressForPersonAsync(Guid personId)
        {
            return await _addressRepository.GetAllAddressesForPersonAsync(personId);
        }
        public async Task AddAddressToPersonAsync(Guid personId, CreateAddressDTO addressDTO)
        {
            await _addressRepository.AddAddressToPersonAsync(AddressMapper.ToAddress(personId, addressDTO));
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
