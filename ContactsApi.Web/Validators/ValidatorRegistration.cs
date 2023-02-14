using ContactsApi.Logic.Dto;
using ContactsApi.Web.Infrastructure;
using FluentValidation;

namespace ContactsApi.Web.Validators
{
    public static class ValidatorRegistration
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CompanyContactCreateDto>, CompanyContactCreateDtoValidator>();
            services.AddTransient<IValidator<CompanyCreateDto>, CompanyCreateDtoValidator>();
            services.AddTransient<IValidator<ContactCreateDto>, ContactCreateDtoValidator>();
            services.AddTransient<IValidator<AuthDto>, AuthDtoValidator>();
        }
    }
}
