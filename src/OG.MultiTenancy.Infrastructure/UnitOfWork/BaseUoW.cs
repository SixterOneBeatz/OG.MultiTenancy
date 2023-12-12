using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.Application.Common.UnitOfWork;

namespace OG.Multitenancy.Infrastructure.UnitOfWork
{
    public abstract class BaseUoW<T>(T context) : IBaseUoW where T : DbContext
    {
        private readonly T _context = context;


        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
