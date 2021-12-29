using System.Collections.Generic;
using TaxManager.Token.Common;

namespace TaxManager.Token.Request
{
    public abstract class MoneyData : Data
    {
        public string textField1 { get; set; }

        public decimal cashSum { get; set; }

        public decimal cashlessSum { get; set; }

        public decimal prepaymentSum { get; set; }

        public decimal creditSum { get; set; }

        public decimal bonusSum { get; set; }

        public decimal? cashFromClient { get; set; }
        public List<VATData> vatAmounts { get; set; }
    }

}
