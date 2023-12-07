using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.API.Data;
using OG.Multitenancy.API.Domain;

namespace OG.Multitenancy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(OrganizationDbContext organizationDbContext) : ControllerBase
    {
        private readonly OrganizationDbContext _organizationDbContext = organizationDbContext;

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await this._organizationDbContext.Products.ToListAsync());
        }
    }
}
