namespace TaxManager.Requests
{
    public class ReturnRequest : SaleRequest
    {
        public string ParentFiscalId { get; set; }
    }
}
