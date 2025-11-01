using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;

namespace PeopleManagement.Api.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository) => _personRepository = personRepository;

        public async Task<Person?> GetPersonByIdAsync(Guid id)
        { 
            return await _personRepository.GetPersonByIdAsync(id);
        }
        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _personRepository.GetAllPeopleAsync();
        }
        public async Task AddPersonAsync(Person person)
        {
            await _personRepository.AddPersonAsync(person);
        }
        public async Task UpdatePersonAsync(Person person)
        {
            await _personRepository.UpdatePersonAsync(person);
        }
        public async Task DeletePersonAsync(Guid id)
        {
            await _personRepository.DeletePersonAsync(id);
        }
    }
}
