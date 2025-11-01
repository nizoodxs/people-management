using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }

        public ICollection<Address> Addresses { get; set; } = [];

        public bool IsDeleted { get; set; } //soft delete
    }
}
