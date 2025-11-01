using Microsoft.EntityFrameworkCore;
using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;
using PeopleManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _dbContext;
        public PersonRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public async Task AddPersonAsync(Person person)
        {
            await _dbContext.People.AddAsync(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(Guid id)
        {
            var person = await _dbContext.People.FindAsync(id);
            if (person != null)
            {
                _dbContext.People.Remove(person);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _dbContext.People.ToListAsync();
        }

        public async Task<Person?> GetPersonByIdAsync(Guid id)
        {
            var person = await _dbContext.People.FindAsync(id);
            return person;
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _dbContext.People.Update(person);
            await _dbContext.SaveChangesAsync();
        }
    }
}
