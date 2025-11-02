using PeopleManagement.Core.Models;
using PeopleManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.Interfaces
{
    public interface IPersonService
    {
        Task<GetPersonDTO?> GetPersonByIdAsync(Guid id);
        Task<IEnumerable<GetPersonDTO>> GetAllPeopleAsync();
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Guid personId, UpdatePersonDTO person);
        Task DeletePersonAsync(Guid id);
    }
}
