using ContributorManager.Core.Application.Interfaces.Repositories;
using ContributorManager.Core.Domain.Entities;
using ContributorManager.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ContributorManager.Infrastructure.Persistence.Repositories
{
    public class ContributorRepository : IContributorRepository
    {
        private readonly ApplicationContext _dbcontext;

        public ContributorRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }   


        public async Task<List<Contributor>> GetAllAsync()
        {
            return await _dbcontext.Set<Contributor>()
                .ToListAsync();
        }
    }
}
