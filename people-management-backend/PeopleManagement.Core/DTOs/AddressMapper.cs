using PeopleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Core.DTOs
{
    public static class AddressMapper
    {
        public static Address ToAddress(Guid personId, CreateAddressDTO addressDto)
        {
            if (addressDto == null)
                return null!;

            return new Address
            {
                AddressId = Guid.NewGuid(),
                PersonId = personId,
                AddressLine1 = addressDto.AddressLine1,
                AddressLine2 = addressDto.AddressLine2??string.Empty,
                Country = addressDto.Country,
                PostCode = addressDto.PostCode,
                Town = addressDto.Town,
            };
        }
    }
}
