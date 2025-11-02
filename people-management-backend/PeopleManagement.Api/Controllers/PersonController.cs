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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IEnumerable<GetPersonDTO>> Get()
        {
            var people = await _personService.GetAllPeopleAsync();
            return people;
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<GetPersonDTO?> Get(Guid id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            return person;
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async Task Post([FromBody] Person person)
        {
            await _personService.AddPersonAsync(person);
        }


        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] UpdatePersonDTO person)
        {
            await _personService.UpdatePersonAsync(id, person);
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _personService.DeletePersonAsync(id);
        }
    }
}
