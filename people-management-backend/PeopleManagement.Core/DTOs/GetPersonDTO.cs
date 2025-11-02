using PeopleManagement.Core.Models;

namespace PeopleManagement.Core.DTOs
{
    public class GetPersonDTO
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
