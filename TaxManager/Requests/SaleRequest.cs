using System.Collections.Generic;

namespace TaxManager.Requests
{
    public class SaleRequest
    {
        public int? PrevDocNumber { get; set; }

        public string  CashierName { get; set; }

        public PaymentDataWithBonus PaymentData { get; set; }

        public List<DocumentItem> Items { get; set; }

        public Customer Customer { get; set; }

        public List<VATData> VATDatas { get; set; }
    }
}
