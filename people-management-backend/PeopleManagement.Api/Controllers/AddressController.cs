using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Api.Services;
using PeopleManagement.Core.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }


        // GET: api/<AddressController>
        [HttpGet("for-person/{personId}")]
        public async Task<IEnumerable<Address>> GetAddressForPerson(Guid personId)
        {
            var addressses = await _addressService.GetAllAddressForPersonAsync(personId);
            return addressses;
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<Address> Get(Guid id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            return address;
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task Post([FromQuery]Guid personId, [FromBody] Address address)
        {
            await _addressService.AddAddressToPersonAsync(personId, address);
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
