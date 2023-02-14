using ContactsApi.Logic.Dto;
using FluentValidation;

namespace ContactsApi.Web.Validators
{
    public class CompanyCreateDtoValidator : AbstractValidator<CompanyCreateDto?>
    {
        public CompanyCreateDtoValidator()
        {
            RuleFor(x => x).NotNull();

            RuleFor(x => x.CompanyType)
                .IsInEnum()
                .WithMessage("CompanyType is invalid.");

            RuleFor(x => x.Name)
                .MinimumLength(1)
                .WithMessage("The 'Name' should have at least 1 character.")
                .MaximumLength(100)
                .WithMessage("The 'Name' should have not more than 100 characters.");

            RuleFor(x => x.City)
                .MinimumLength(1)
                .WithMessage("The 'City' should have at least 1 character.")
                .MaximumLength(100)
                .WithMessage("The 'City' should have not more than 100 characters.");

            RuleFor(x => x.ZipCode)
                .MinimumLength(1)
                .WithMessage("The 'ZipCode' should have at least 1 character.")
                .MaximumLength(50)
                .WithMessage("The 'ZipCode' should have not more than 50 characters.");

            RuleFor(x => x.CompanyMainLine)
                .MinimumLength(1)
                .WithMessage("The 'CompanyMainLine' should have at least 1 character.")
                .MaximumLength(50)
                .WithMessage("The 'CompanyMainLine' should have not more than 50 characters.");

            RuleFor(x => x.StateId)
                .GreaterThan(0);

            RuleFor(x => x.CountryId)
                .GreaterThan(0);
        }
    }
}
