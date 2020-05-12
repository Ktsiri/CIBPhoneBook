using System;
using System.Threading;
using System.Threading.Tasks;
using CIBPhonebook.Domain.DomainObjects;
using CIBPhonebook.Domain.Repositories.Interfaces;
using CIBPhonebook.Domain.Services.Interfaces;
using CIBPhonebook.Domain.Validations.Interfaces;
using CIBPhonebook.Dtos;

namespace CIBPhonebook.Domain.Services.Implementation
{
    public class AddPhoneBookRecord : IAddPhoneBookRecord
    {
        private readonly IRepository<PhoneBook> repository;
        private readonly IValidatorObject<PhoneBookDto> validator;

        public AddPhoneBookRecord(IRepository<PhoneBook> repository,
            IValidatorObject<PhoneBookDto> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<ValidationResponseDto> CreatePhoneBookRecord(PhoneBookDto phoneBookDto,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var validationResponse = await this.validator.ValidateWithResultAsync(phoneBookDto, cancellationToken);

            if (!validationResponse.IsValid)
            {
                return validationResponse;
            }

            // TODO: add autofac to map objects
            var phonebook = new PhoneBook();
            phonebook.FirstName = phoneBookDto.FirstName;
            phonebook.Surname = phoneBookDto.Surname;
            phonebook.PhoneNumber = phoneBookDto.PhoneNumber;

            await this.repository.Add(phonebook);

            return validationResponse;
        }
    }
}
