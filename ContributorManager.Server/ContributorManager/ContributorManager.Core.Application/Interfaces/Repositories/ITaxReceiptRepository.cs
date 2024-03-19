using ContributorManager.Core.Domain.Entities;

namespace ContributorManager.Core.Application.Interfaces.Repositories
{
    public interface ITaxReceiptRepository
    {
        Task<List<TaxReceipt>> GetAllAsync();
    }
}
