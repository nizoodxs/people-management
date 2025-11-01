using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> GetPersonByIdAsync(Guid id);
    }
}
