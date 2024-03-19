using ContributorManager.Core.Application.Interfaces.Repositories;
using ContributorManager.Core.Domain.Entities;
using ContributorManager.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ContributorManager.Infrastructure.Persistence.Repositories
{
    public class TaxReceiptRepository : ITaxReceiptRepository
    {
        private readonly ApplicationContext _dbcontext;

        public TaxReceiptRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<List<TaxReceipt>> GetAllAsync()
        {
            return await _dbcontext.Set<TaxReceipt>()
                .ToListAsync();
        }
    }
}
