using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Requests
{
    public class CorrectionRequest
    {
        public DateTime FirstOperationAtUtc { get; set; }

        public DateTime LastOperationAtUtc { get; set; }

        public PaymentData PaymentData { get; set; }

        public string CashierName { get; set; }

        public decimal VatPercent { get; set; }

    }
}
