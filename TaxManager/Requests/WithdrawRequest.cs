namespace TaxManager.Requests
{
    public class WithdrawRequest
    {
        public decimal WithdrawValue { get; set; }

        public string CashierName { get; set; }
    }
}
