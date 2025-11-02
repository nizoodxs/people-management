using PeopleManagement.Core.DTOs;
using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;

namespace PeopleManagement.Api.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository) => _personRepository = personRepository;

        public async Task<GetPersonDTO?> GetPersonByIdAsync(Guid id)
        { 
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null) return null;
            return PersonMapper.ToGetPersonDTO(person);
        }
        public async Task<IEnumerable<GetPersonDTO>> GetAllPeopleAsync()
        {
            var people = await _personRepository.GetAllPeopleAsync();
            return PersonMapper.ToGetPersonDTOList(people);
        }
        public async Task AddPersonAsync(Person person)
        {
            await _personRepository.AddPersonAsync(person);
        }
        public async Task UpdatePersonAsync(Guid personId, UpdatePersonDTO person)
        {
            await _personRepository.UpdatePersonAsync(PersonMapper.ToPersonDto(personId, person));
        }
        public async Task DeletePersonAsync(Guid id)
        {
            await _personRepository.DeletePersonAsync(id);
        }
    }
}
