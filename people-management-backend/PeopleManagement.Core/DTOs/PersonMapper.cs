using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.DTOs
{
    public static class PersonMapper
    {
        public static GetPersonDTO ToGetPersonDTO(Person? person)
        {
            if (person == null)
                return null!;

            return new GetPersonDTO
            {
                PersonId = person.PersonId,
                Name = person.Name.Trim(),
                DateOfBirth = DateOnly.FromDateTime(person.DateOfBirth)
            };
        }

        public static IEnumerable<GetPersonDTO> ToGetPersonDTOList(IEnumerable<Person> people)
        {
            return people.Select(ToGetPersonDTO).ToList();
        }

        public static Person ToPersonDto(Guid personId, UpdatePersonDTO person)
        {
            if (person == null)
                return null!;

            return new Person
            {
                PersonId = personId,
                Name = person.Name.Trim(),
                DateOfBirth = person.DateOfBirth.ToDateTime(new TimeOnly())
            };
        }
    }
}
