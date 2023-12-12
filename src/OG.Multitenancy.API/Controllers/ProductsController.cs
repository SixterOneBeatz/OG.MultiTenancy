using MediatR;
using Microsoft.AspNetCore.Mvc;
using OG.Multitenancy.Application.Features.Product.Queries;


namespace OG.Multitenancy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<List<Domain.Product>>> Get()
        {
            GetProductsQuery request = new();

            return Ok(await this._mediator.Send(request));
        }
    }
}
