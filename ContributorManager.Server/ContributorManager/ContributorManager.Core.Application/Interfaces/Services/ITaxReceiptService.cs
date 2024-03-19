using ContributorManager.Core.Application.ViewModels.TaxReceipts;

namespace ContributorManager.Core.Application.Interfaces.Services
{
    public interface ITaxReceiptService
    {
        Task<List<TaxReceiptViewModel>> GetAllTaxReceipts();
    }
}
