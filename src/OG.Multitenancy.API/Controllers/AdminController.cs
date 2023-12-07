using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.API.Data;
using OG.Multitenancy.API.Domain;
using OG.Multitenancy.API.Services;

namespace OG.Multitenancy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(MasterDbContext masterDbContext, IOrganizationDbCreator organizationDbCreator, IConfiguration configuration) : ControllerBase
    {
        private readonly MasterDbContext _masterDbContext = masterDbContext;
        private readonly IOrganizationDbCreator _organizationDbCreator = organizationDbCreator;
        private readonly IConfiguration _configuration = configuration;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Organization org)
        {
            bool existOrg = await this._masterDbContext.Organizations.AnyAsync(o => o.Name == org.Name);

            if (!existOrg)
            {
                var connectionString = string.Format(this._configuration.GetConnectionString("OrganizationTemplate"), org.Name);
                org.ConnectionString = connectionString;
                org.Active = true;

                var created = await this._masterDbContext.Organizations.AddAsync(org);
                await this._masterDbContext.SaveChangesAsync();

                await this._organizationDbCreator.Create(created.Entity);

                return Created();
            }
            else
            {
                return Conflict("Organization already exist");
            }
        }
    }
}
