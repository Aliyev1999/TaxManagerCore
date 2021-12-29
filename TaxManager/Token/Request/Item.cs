using Newtonsoft.Json;
using System;

namespace TaxManager.Token.Request
{
    public class Item
    {
        public string itemName { get; set; }

        public int itemCodeType { get; set; }

        public string itemCode { get; set; }

        public decimal itemQuantity { get; set; }

        public decimal itemPrice { get; set; }

        public decimal itemSum { get; set; }

        public decimal itemVatPercent { get; set; }


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<decimal> itemMarginPrice { get; set; }


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<decimal> itemMarginSum { get; set; }
    }

}
