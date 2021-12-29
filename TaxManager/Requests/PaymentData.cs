using System.Collections.Generic;

namespace TaxManager.Requests
{
    public class PaymentData
    {
        internal string Currency { get; set; } = "AZN";

        public decimal Sum { get; set; }

        public decimal CashSum { get; set; }

        public decimal CashlessSum { get; set; }

        public decimal PrepaymentSum { get; set; }

        public decimal CreditSum { get; set; }

        public decimal BonusSum { get; set; }

        public decimal? CashFromClient { get; set; }

    }
}
