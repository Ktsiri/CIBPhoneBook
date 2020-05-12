using System;
using System.Threading;
using System.Threading.Tasks;
using CIBPhonebook.Dtos;
namespace CIBPhonebook.Domain.Validations.Interfaces
{
    public interface IValidatorObject<TObjectType>
    {
        Task<ValidationResponseDto> ValidateWithResultAsync(TObjectType objectToValidate,
             CancellationToken cancellationToken = default(CancellationToken));
    }
}
