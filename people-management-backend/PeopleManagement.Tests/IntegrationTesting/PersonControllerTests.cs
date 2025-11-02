using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleManagement.Api.Controllers;
using PeopleManagement.Api.Services;
using PeopleManagement.Core.DTOs;
using PeopleManagement.Core.Models;
using PeopleManagement.Infrastructure.Data;
using PeopleManagement.Infrastructure.Repositories;

namespace PeopleManagement.Tests.IntegrationTesting
{
    public class PersonControllerTests
    {
        private AppDbContext GetInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new AppDbContext(options);
            return context;
        }

        [Fact]
        public async Task GetAll_ReturnsListOfPeople()
        {
            // Arrange
            var context = GetInMemoryDb();
            context.People.Add(new Person { PersonId = Guid.NewGuid(), Name = "John Doe" });
            context.People.Add(new Person { PersonId = Guid.NewGuid(), Name = "Ram Prasad" });
            await context.SaveChangesAsync();

            var personRepository = new PersonRepository(context);
            var service = new PersonService(personRepository);
            var controller = new PersonController(service);

            // Act
            var result = await controller.Get();

            // Assert
            var list = Assert.IsType<List<GetPersonDTO>>(result);
            Assert.Equal(2, list.Count());
        }
    }

}
