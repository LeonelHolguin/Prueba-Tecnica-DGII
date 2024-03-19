
namespace ContributorManager.Core.Application.ViewModels.TaxReceipts
{
    public class TaxReceiptViewModel
    {
        public required string TaxIdentificationNumber { get; set; }
        public required string TaxVerificationNumber { get; set; }
        public double Amount { get; set; }  
        public double VAT18 { get; set; }
    }
}
