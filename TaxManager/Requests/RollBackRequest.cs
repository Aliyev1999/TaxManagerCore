using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Requests
{
    public class RollBackRequest
    {
        public string CashierName { get; set; }

        internal string Currrency { get; set; } = "AZN";

        public string ParentFiscalId { get; set; }

        public decimal Sum { get; set; }

        public decimal CashSum { get; set; }

        public decimal CashlessSum { get; set; }

        public decimal PrepaymentSum { get; set; }

        public decimal CreditSum { get; set; }

        public decimal BonusSum { get; set; }

        public List<VATData> VATDatas { get; set; }
    }
}
