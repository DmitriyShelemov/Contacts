using ContactsApi.Database;
using ContactsApi.Logic;
using ContactsApi.Logic.Interfaces;
using ContactsApi.Web.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IValidator<AuthDto> _validator;

        public AuthController(ITokenService tokenService, IUserService userService, IValidator<AuthDto> validator)
        {
            _tokenService = tokenService;
            _userService = userService;
            _validator = validator;
        }

        [HttpPost("/API/Auth/Login")]
        public async Task<IActionResult> Login(AuthDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToArray());
            }

            var user = await _userService.FindAsync(dto.Email, dto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.CreateToken(user);
            return Ok(new
            {
                dto.Email,
                Token = token
            });
        }
    }
}