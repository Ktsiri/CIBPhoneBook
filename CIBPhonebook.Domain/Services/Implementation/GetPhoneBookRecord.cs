using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CIBPhonebook.Domain.Repositories.Retrivers.Interfaces;
using CIBPhonebook.Domain.Services.Interfaces;
using CIBPhonebook.Dtos;

namespace CIBPhonebook.Domain.Services.Implementation
{
    public class GetPhoneBookRecord : IGetPhoneBookRecord
    {
        private readonly IPhoneBookRetriver phoneBookRetriver;

        public GetPhoneBookRecord(IPhoneBookRetriver phoneBookRetriver)
        {
            this.phoneBookRetriver = phoneBookRetriver;
        }

        public async Task<IEnumerable<PhoneBookDto>> GetAllPhoneBookEntries()
        {
            var phoneBookEntries = await this.phoneBookRetriver.GetAllPhoneBookEntries();

            // TODO: replace this manual mapping with autofac configuartions
            var phoneBookDto = new List<PhoneBookDto>();

            foreach (var entry in phoneBookEntries)
            {
                phoneBookDto.Add(new PhoneBookDto
                {
                    FirstName = entry.FirstName,
                    Surname = entry.Surname,
                    PhoneNumber = entry.PhoneNumber
                });
            }
            return phoneBookDto;
        }

        public async Task<IEnumerable<PhoneBookDto>> GetPhoneBookByName(string name)
        {
            var phoneBookEntries = await this.phoneBookRetriver.GetPhoneBookByName(name);

            // TODO: replace this manual mapping with autofac configuartions
            var phoneBookDto = new List<PhoneBookDto>();

            foreach (var entry in phoneBookEntries)
            {
                phoneBookDto.Add(new PhoneBookDto
                {
                    FirstName = entry.FirstName,
                    Surname = entry.Surname,
                    PhoneNumber = entry.PhoneNumber
                });
            }
            return phoneBookDto;
        }

        public async Task<IEnumerable<PhoneBookDto>> GetPhoneBookByPhoneNumber(string phonenumber)
        {
            var phoneBookEntries = await this.phoneBookRetriver.GetPhoneBookByPhoneNumber(phonenumber);

            // TODO: replace this manual mapping with autofac configuartions
            var phoneBookDto = new List<PhoneBookDto>();

            foreach (var entry in phoneBookEntries)
            {
                phoneBookDto.Add(new PhoneBookDto
                {
                    FirstName = entry.FirstName,
                    Surname = entry.Surname,
                    PhoneNumber = entry.PhoneNumber
                });
            }
            return phoneBookDto;
        }

        public async Task<IEnumerable<PhoneBookDto>> GetPhoneBookBySurname(string surname)
        {
            var phoneBookEntries = await this.phoneBookRetriver.GetPhoneBookBySurname(surname);

            // TODO: replace this manual mapping with autofac configuartions
            var phoneBookDto = new List<PhoneBookDto>();

            foreach (var entry in phoneBookEntries)
            {
                phoneBookDto.Add(new PhoneBookDto
                {
                    FirstName = entry.FirstName,
                    Surname = entry.Surname,
                    PhoneNumber = entry.PhoneNumber
                });
            }
            return phoneBookDto;
        }
    }
}
