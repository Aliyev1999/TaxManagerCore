using System.Collections.Generic;
using TaxManager.Token.Common;

namespace TaxManager.Token.Response
{
    public class Currency
    {
        public string currency { get; set; }

        // sale
        public int saleCount { get; set; }

        public decimal saleSum { get; set; }

        public decimal saleCashSum { get; set; }

        public decimal saleCashlessSum { get; set; }

        public decimal salePrepaymentSum { get; set; }

        public decimal saleCreditSum { get; set; }

        public decimal saleBonusSum { get; set; }

        public List<VATData> saleVatAmounts { get; set; }

        public int depositCount { get; set; }

        public decimal depositSum { get; set; }

        public int withdrawCount { get; set; }

        public decimal withdrawSum { get; set; }

        // moneyback
        public int moneyBackCount { get; set; }

        public decimal moneyBackSum { get; set; }

        public decimal moneyBackCashSum { get; set; }

        public decimal moneyBackCashlessSum { get; set; }

        public decimal moneyBackPrepaymentSum { get; set; }

        public decimal moneyBackCreditSum { get; set; }

        public decimal moneyBackBonusSum { get; set; }

        public List<VATData> moneyBackVatAmounts { get; set; }

        // rollback
        public int rollbackCount { get; set; }
        public decimal rollbackSum { get; set; }
        public decimal rollbackCashSum { get; set; }
        public decimal rollbackCashlessSum { get; set; }
        public decimal rollbackPrepaymentSum { get; set; }
        public decimal rollbackCreditSum { get; set; }
        public decimal rollbackBonusSum { get; set; }
        public List<VATData> rollbackVatAmounts { get; set; }

        // correction
        public int correctionCount { get; set; }

        public decimal correctionSum { get; set; }

        public decimal correctionCashSum { get; set; }

        public decimal correctionCashlessSum { get; set; }

        public decimal correctionPrepaymentSum { get; set; }

        public decimal correctionCreditSum { get; set; }

        public List<VATData> correctionVatAmounts { get; set; }


    }



}
