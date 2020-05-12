using System;
using CIBPhonebook.Dtos;
using FluentValidation;

namespace CIBPhonebook.Domain.Validations.PhoneBook
{
    public class PhoneBookDtoValidator : AbstractValidator<PhoneBookDto>
    {
        public PhoneBookDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage(PropertyCannotBeNull);

            RuleFor(x => x.Surname)
                .NotNull()
                .NotEmpty()
                .WithMessage(PropertyCannotBeNull);

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(PropertyCannotBeNull);
        }

        public static string PropertyCannotBeNull { get; } = "The value of property {0} cannot be null";
    }
}
