using System.Collections.Generic;
using TaxManager.Token.Common;

namespace TaxManager.Token.Request
{
    public abstract class MonyBack : Data
    {
        public decimal cashSum { get; set; }

        public decimal cashlessSum { get; set; }

        public decimal prepaymentSum { get; set; }

        public decimal creditSum { get; set; }

        public decimal bonusSum { get; set; }

        public List<VATData> vatAmounts { get; set; }
    }
}
