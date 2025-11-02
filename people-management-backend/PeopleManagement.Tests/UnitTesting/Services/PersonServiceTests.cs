using Moq;
using PeopleManagement.Api.Services;
using PeopleManagement.Core.DTOs;
using PeopleManagement.Core.Interfaces;
using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Tests.UnitTesting.Services
{
    public class PersonServiceTests
    {
        [Fact]
        public async Task GetPersonByIdAsync_ReturnsSamePerson()
        {
            //arrange
            var personId = Guid.NewGuid();
            var person = new Person()
            {
                Addresses = [],
                DateOfBirth = DateTime.UtcNow,
                Name = "Test 123",
                PersonId = personId
            };
            var mockRepo = new Mock<IPersonRepository>();
            mockRepo.Setup(repo => repo.GetPersonByIdAsync(personId)).ReturnsAsync(person);

            var service = new PersonService(mockRepo.Object);

            //act
            var result = await service.GetPersonByIdAsync(personId);
            var dto = PersonMapper.ToGetPersonDTO(person);

            //assert
            Assert.NotNull(result);
            Assert.Equal(dto.PersonId, result.PersonId);
            Assert.Equal(dto.Name, result.Name);
        }
    }
}
