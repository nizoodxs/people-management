using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Api.Services;
using PeopleManagement.Core.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            var people = await _personService.GetAllPeopleAsync();
            return people;
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<Person?> Get(Guid id)
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
        public async Task Put(Guid id, [FromBody] Person person)
        {
            await _personService.UpdatePersonAsync(person);
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _personService.DeletePersonAsync(id);
        }
    }
}
