
using ContactsApi.Logic.Dto;
using FluentValidation;

namespace ContactsApi.Web.Validators
{
    public class ContactCreateDtoValidator : AbstractValidator<ContactCreateDto>
    {
        public ContactCreateDtoValidator()
        {
            RuleFor(x => x.TitleType)
                .IsInEnum()
                .WithMessage("TitleType is invalid.");

            RuleFor(x => x.FirstName)
                .MinimumLength(1)
                .WithMessage("The 'FirstName' should have at least 1 character.")
                .MaximumLength(100)
                .WithMessage("The 'FirstName' should have not more than 100 characters.");

            RuleFor(x => x.LastName)
                .MinimumLength(1)
                .WithMessage("The 'LastName' should have at least 1 character.")
                .MaximumLength(100)
                .WithMessage("The 'LastName' should have not more than 100 characters.");

            RuleFor(x => x.MiddleName)
                .MaximumLength(100)
                .WithMessage("The 'MiddleName' should have not more than 100 characters.");

            RuleFor(x => x.Notes)
                .MaximumLength(100)
                .WithMessage("The 'Notes' should have not more than 100 characters.");

            RuleFor(x => x.ZipCode)
                .MinimumLength(1)
                .WithMessage("The 'ZipCode' should have at least 1 character.")
                .MaximumLength(50)
                .WithMessage("The 'ZipCode' should have not more than 50 characters.");

            RuleFor(x => x.Address)
                .MinimumLength(1)
                .WithMessage("The 'Address' should have at least 1 character.")
                .MaximumLength(512)
                .WithMessage("The 'Address' should have not more than 512 characters.");

            RuleFor(x => x.City)
                .MinimumLength(1)
                .WithMessage("The 'City' should have at least 1 character.")
                .MaximumLength(100)
                .WithMessage("The 'City' should have not more than 100 characters.");

            RuleFor(x => x.PersonalMobile1)
                .MaximumLength(50)
                .WithMessage("The 'PersonalMobile1' should have not more than 50 characters.");

            RuleFor(x => x.PersonalMobile2)
                .MaximumLength(50)
                .WithMessage("The 'PersonalMobile2' should have not more than 50 characters.");

            RuleFor(x => x.HomePhone)
                .MaximumLength(50)
                .WithMessage("The 'HomePhone' should have not more than 50 characters.");

            RuleFor(x => x.LinkedIn)
                .MaximumLength(1024)
                .WithMessage("The 'LinkedIn' should have not more than 1024 characters.");

            RuleFor(x => x.PersonalEmail)
                .EmailAddress()
                .WithMessage("The 'PersonalEmail' should be a valid email.")
                .MaximumLength(100)
                .WithMessage("The 'PersonalEmail' should have not more than 100 characters.");

            RuleFor(x => x.DateOfBirth)
                .Must(x => x > DateTime.UtcNow.AddYears(-150))
                .Must(x => x < DateTime.UtcNow.AddYears(-5));

            RuleFor(x => x.StateId)
                .GreaterThan(0);

            RuleFor(x => x.CountryId)
                .GreaterThan(0);

            RuleFor(x => x.CompanyId)
                .GreaterThan(0)
                .When(x => x.Company == null);

            RuleFor(x => x.Company)
                .NotNull()
                .When(x => !x.CompanyId.HasValue);

            RuleFor(x => x.Company)
                .SetValidator(new CompanyCreateDtoValidator())
                .When(x => x.Company != null);

            RuleFor(x => x.BusinessInfo)
                .SetValidator(new CompanyContactCreateDtoValidator());
        }
    }
}
