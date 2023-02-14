using ContactsApi.Logic.Dto;
using ContactsApi.Web.Infrastructure;
using FluentValidation;

namespace ContactsApi.Web.Validators
{
    public class AuthDtoValidator : AbstractValidator<AuthDto>
    {
        public AuthDtoValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(1)
                .WithMessage("The 'Password' should have at least 1 character.")
                .MaximumLength(100)
                .WithMessage("The 'Password' should have not more than 100 characters.");
        }
    }
}
