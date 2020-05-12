using System.Threading;
using System.Threading.Tasks;
using CIBPhonebook.Dtos;

namespace CIBPhonebook.Domain.Services.Interfaces
{
    public interface IAddPhoneBookRecord
    {
        Task<ValidationResponseDto> CreatePhoneBookRecord(PhoneBookDto phoneBookDto,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
