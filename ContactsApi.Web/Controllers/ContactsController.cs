using ContactsApi.Logic.Dto;
using ContactsApi.Logic.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IValidator<ContactCreateDto> _validator;
        private readonly IContactService _service;

        public ContactsController(ILogger<ContactsController> logger, IContactService service, IValidator<ContactCreateDto> validator)
        {
            _logger = logger;
            _service = service;
            _validator = validator;
        }

        [HttpGet("/API/Contacts/List")]
        public async Task<IActionResult> List(int skip, int take)
        {
            if (skip < 0 || take <= 0 || take > 100)
            {
                return BadRequest();
            }

            return Ok(await _service.GetAsync(skip, take));
        }

        [HttpPost("/API/Contacts/Add")]
        public async Task<IActionResult> Add(ContactCreateDto contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            var result = await _validator.ValidateAsync(contact);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToArray());
            }

            if (!await _service.AddAsync(contact))
            {
                return BadRequest();
            }
            return Ok(new
            {
                BusinessInfoId = contact.BusinessInfo.Id,
                contact.BusinessInfo.CompanyId,
                contact.BusinessInfo.ContactId
            });
        }
    }
}