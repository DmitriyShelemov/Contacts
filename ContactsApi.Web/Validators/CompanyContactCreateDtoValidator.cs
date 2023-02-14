using ContactsApi.Logic.Dto;
using FluentValidation;

namespace ContactsApi.Web.Validators
{
    public class CompanyContactCreateDtoValidator : AbstractValidator<CompanyContactCreateDto?>
    {
        public CompanyContactCreateDtoValidator()
        {
            RuleFor(x => x).NotNull();

            RuleFor(x => x.Position)
                .MinimumLength(1)
                .WithMessage("The 'Position' should have at least 1 character.")
                .MaximumLength(50)
                .WithMessage("The 'Position' should have not more than 50 characters.");

            RuleFor(x => x.Department)
                .MinimumLength(1)
                .WithMessage("The 'Department' should have at least 1 character.")
                .MaximumLength(100)
                .WithMessage("The 'Department' should have not more than 100 characters.");

            RuleFor(x => x.Email)
                .MinimumLength(1)
                .WithMessage("The 'Email' should have at least 1 character.")
                .MaximumLength(100)
                .WithMessage("The 'Email' should have not more than 100 characters.");

            RuleFor(x => x.DirectLine)
                .MinimumLength(1)
                .WithMessage("The 'DirectLine' should have at least 1 character.")
                .MaximumLength(50)
                .WithMessage("The 'DirectLine' should have not more than 50 characters.");

            RuleFor(x => x.Mobile)
                .MaximumLength(50)
                .WithMessage("The 'Mobile' should have not more than 50 characters.");

            RuleFor(x => x.SecondLine)
                .MaximumLength(50)
                .WithMessage("The 'SecondLine' should have not more than 50 characters.");
        }
    }
}
