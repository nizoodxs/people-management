using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.Interfaces
{
    public interface IPersonService
    {
        Task<Person?> GetPersonByIdAsync(Guid id);
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Guid id);
    }
}
