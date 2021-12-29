using System.Collections.Generic;

namespace TaxManager.Token.Request
{
    public class SaleData : MoneyData
    {
        public List<Item> items { get; set; } = new List<Item>();
    }
}
