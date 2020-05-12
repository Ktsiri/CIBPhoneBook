using System;
using System.Threading;
using System.Threading.Tasks;
using CIBPhonebook.Domain.DomainObjects;
using CIBPhonebook.Domain.Repositories.Interfaces;
using CIBPhonebook.Domain.Services.Implementation;
using CIBPhonebook.Domain.Validations.Interfaces;
using CIBPhonebook.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CIBPhonebook.Domain.Tests.Services.Implementation
{
    [TestClass]
    public class AddPhoneBookRecordTest
    {
        [TestMethod]
        public async Task CreatePhoneBookRecord_Success()
        {
            // Arrange

            var mockPhoneBookRespository = new Mock<IRepository<PhoneBook>>();

            var mockValidate = new Mock<IValidatorObject<PhoneBookDto>>();

            mockValidate.Setup(x => x.ValidateWithResultAsync(It.IsAny<PhoneBookDto>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(SuccessFakeValidationResponse());

            var addPhoneBookRecord = new AddPhoneBookRecord(mockPhoneBookRespository.Object,
                mockValidate.Object);

            // Act

            var phonebookDto = new PhoneBookDto{
                FirstName = "Test Firstname",
                Surname = "Test Surname",
                PhoneNumber = "0215365215"
            };
            await addPhoneBookRecord.CreatePhoneBookRecord(phonebookDto,
                It.IsAny<CancellationToken>());

            // Assert

            mockValidate.Verify(x => x.ValidateWithResultAsync(It.IsAny<PhoneBookDto>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mockPhoneBookRespository.Verify(x => x.Add(It.IsAny<PhoneBook>()), Times.Once);
        }

        [TestMethod]
        public async Task CreatePhoneBookRecord_When_Validation_Has_Failed_Do_Not_Invoke_All_Interfaces()
        {
            // Arrange

            var mockPhoneBookRespository = new Mock<IRepository<PhoneBook>>();

            var mockValidate = new Mock<IValidatorObject<PhoneBookDto>>();

            mockValidate.Setup(x => x.ValidateWithResultAsync(It.IsAny<PhoneBookDto>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(FailedFakeValidationResponse());

            var addPhoneBookRecord = new AddPhoneBookRecord(mockPhoneBookRespository.Object,
                mockValidate.Object);

            // Act

            var phonebookDto = new PhoneBookDto
            {
                FirstName = "Test Firstname",
                Surname = "Test Surname",
                PhoneNumber = "0215365215"
            };
            await addPhoneBookRecord.CreatePhoneBookRecord(phonebookDto,
                It.IsAny<CancellationToken>());

            // Assert

            mockValidate.Verify(x => x.ValidateWithResultAsync(It.IsAny<PhoneBookDto>(),
                It.IsAny<CancellationToken>()), Times.Once);

            // This should not be invoked

            mockPhoneBookRespository.Verify(x => x.Add(It.IsAny<PhoneBook>()), Times.Never);
        }
        private ValidationResponseDto FailedFakeValidationResponse()
        {
            var fakeResponse = new ValidationResponseDto
            {
                IsValid = false
            };

            return fakeResponse;
        }
        private ValidationResponseDto SuccessFakeValidationResponse()
        {
            var fakeResponse = new ValidationResponseDto
            {
                IsValid = true
            };

            return fakeResponse;
        }
    }
}
