using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Api.Services;
using PeopleManagement.Core.DTOs;
using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger, IAddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }


        // GET: api/<AddressController>
        [HttpGet("for-person/{personId}")]
        public async Task<IEnumerable<Address>> GetAddressForPerson(Guid personId)
        {
            _logger.LogInformation("Fetching address for person: " + personId);
            var addressses = await _addressService.GetAllAddressForPersonAsync(personId);
            return addressses;
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<Address?> Get(Guid id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            return address;
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task Post([FromBody] AddAddressDTO addressDto)
        {
            await _addressService.AddAddressToPersonAsync(addressDto.personId, addressDto.address);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] Address address)
        {
            await _addressService.UpdateAddressAsync(address);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _addressService.DeleteAddressAsync(id);
        }
    }
}
