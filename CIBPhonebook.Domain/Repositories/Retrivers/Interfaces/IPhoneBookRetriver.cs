using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CIBPhonebook.Domain.DomainObjects;

namespace CIBPhonebook.Domain.Repositories.Retrivers.Interfaces
{
    public interface IPhoneBookRetriver
    {
        Task<IEnumerable<PhoneBook>> GetAllPhoneBookEntries();
        Task<IEnumerable<PhoneBook>> GetPhoneBookByName(string name);
        Task<IEnumerable<PhoneBook>> GetPhoneBookBySurname(string surname);
        Task<IEnumerable<PhoneBook>> GetPhoneBookByPhoneNumber(string phonenumber);
    }
}
