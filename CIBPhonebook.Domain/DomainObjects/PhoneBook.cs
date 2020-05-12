using System;
using CIBPhonebook.Domain.DomainObjects.Base;

namespace CIBPhonebook.Domain.DomainObjects
{
    public class PhoneBook : BaseDomainObject<Guid>
    {

        public string FirstName { get; set; }

        public string Surname { get; set; }
      
        public string PhoneNumber { get; set; }

    }
}
