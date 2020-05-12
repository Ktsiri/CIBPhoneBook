using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using CIBPhonebook.Domain.Validations.Interfaces;
using CIBPhonebook.Dtos;

namespace CIBPhonebook.Domain.Validations
{
    public class ValidationManager<TObjectType> : IValidatorObject<TObjectType>
    {
        private readonly IValidator<TObjectType> validator;

        public ValidationManager(IValidator<TObjectType> validator)
        {
            this.validator = validator;
        }
        public async Task<ValidationResponseDto> ValidateWithResultAsync(TObjectType objectToValidate,
             CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = new ValidationResponseDto();
            if (objectToValidate == null)
                throw new ArgumentNullException(nameof(objectToValidate), "Cannot pass null to Validate.");

            var validationResult = await validator.ValidateAsync(objectToValidate, cancellationToken);

            response.IsValid = validationResult.IsValid;
            var errors = new List<ErrorDto>();
            errors.AddRange(validationResult.Errors.Select(error => new ErrorDto
            {
                ErrorCode = error.ErrorCode,
                ErrorMessage = error.ErrorMessage,
                PropertyName = error.PropertyName
            }));
            response.Errors = errors;

            return response;
        }
    }
}
