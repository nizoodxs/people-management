using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.DTOs
{
    public class UpdatePersonDTO
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
