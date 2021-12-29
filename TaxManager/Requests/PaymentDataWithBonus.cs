namespace TaxManager.Requests
{
    public class PaymentDataWithBonus:PaymentData
    {
        public decimal EarnedBonus { get; set; }

        public decimal FinalBonus { get; set; }

        public decimal InitialBonus { get; set; }

        public decimal PaidedBonus { get; set; }
    }
}
