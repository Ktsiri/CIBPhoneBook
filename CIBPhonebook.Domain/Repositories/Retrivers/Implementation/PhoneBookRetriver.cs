using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CIBPhonebook.Domain.DomainObjects;
using CIBPhonebook.Domain.Repositories.Interfaces;
using CIBPhonebook.Domain.Repositories.Retrivers.Interfaces;

namespace CIBPhonebook.Domain.Repositories.Retrivers.Implementation
{
    public class PhoneBookRetriver : IPhoneBookRetriver
    {
        private readonly IRepository<PhoneBook> phoneBookRepository;

        public PhoneBookRetriver(IRepository<PhoneBook> phoneBookRepository)
        {
            this.phoneBookRepository = phoneBookRepository;
        }

        public async Task<IEnumerable<PhoneBook>> GetAllPhoneBookEntries()
        {
            return await this.phoneBookRepository.GetAll();
        }

        public async Task<IEnumerable<PhoneBook>> GetPhoneBookByName(string name)
        {
            return await this.phoneBookRepository.GetWhere(x => x.FirstName == name);
        }

        public async Task<IEnumerable<PhoneBook>> GetPhoneBookBySurname(string surname)
        {
            return await this.phoneBookRepository.GetWhere(x => x.Surname == surname);
        }

        public async Task<IEnumerable<PhoneBook>> GetPhoneBookByPhoneNumber(string phonenumber)
        {
            return await this.phoneBookRepository.GetWhere(x => x.PhoneNumber == phonenumber);
        }
    }
}
