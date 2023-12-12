using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OG.Multitenancy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController: ControllerBase
    {

        [HttpPost]
        public IActionResult Create()
        {
            //bool existOrg = await this._masterDbContext.Organizations.AnyAsync(o => o.Name == org.Name);

            //if (!existOrg)
            //{
            //    var connectionString = string.Format(this._configuration.GetConnectionString("OrganizationTemplate"), org.Name);
            //    org.ConnectionString = connectionString;
            //    org.Active = true;

            //    var created = await this._masterDbContext.Organizations.AddAsync(org);
            //    await this._masterDbContext.SaveChangesAsync();

            //    await this._organizationDbCreator.Create(created.Entity);

            //    return Created();
            //}
            //else
            //{
            //    return Conflict("Organization already exist");
            //}

            return Created();
        }
    }
}
