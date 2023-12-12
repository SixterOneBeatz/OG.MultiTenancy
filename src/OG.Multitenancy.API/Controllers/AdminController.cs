using MediatR;
using Microsoft.AspNetCore.Mvc;
using OG.Multitenancy.Application.Common.DTOs;
using OG.Multitenancy.Application.Features.Organization.Commands;

namespace OG.Multitenancy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrganizationDTO organization)
        {
            CreateOrganizationCommand request = new(organization);
            int response = await _mediator.Send(request);

            if (response > 0)
            {
                return Created();
            }
            else
            {
                return Conflict();
            }
        }
    }
}
