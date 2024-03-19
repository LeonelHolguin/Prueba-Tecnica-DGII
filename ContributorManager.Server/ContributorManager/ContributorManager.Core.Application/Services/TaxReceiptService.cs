using ContributorManager.Core.Application.Interfaces.Repositories;
using ContributorManager.Core.Application.Interfaces.Services;
using ContributorManager.Core.Application.ViewModels.TaxReceipts;

namespace ContributorManager.Core.Application.Services
{
    public class TaxReceiptService : ITaxReceiptService
    {
        private readonly ITaxReceiptRepository _taxReceiptRepository;
        public TaxReceiptService(ITaxReceiptRepository taxReceiptRepository)
        {
            _taxReceiptRepository = taxReceiptRepository;
        }

        public async Task<List<TaxReceiptViewModel>> GetAllTaxReceipts()
        {
            var taxReceiptList = await _taxReceiptRepository.GetAllAsync();

            return taxReceiptList.Select(taxReceipt => new TaxReceiptViewModel
            {
                TaxIdentificationNumber = taxReceipt.TaxIdentificationNumber,
                TaxVerificationNumber = taxReceipt.TaxVerificationNumber,
                Amount = taxReceipt.Amount,
                VAT18 = taxReceipt.VAT18,

            }).ToList();
        }
    }
}
