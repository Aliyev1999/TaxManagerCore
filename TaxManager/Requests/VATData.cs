using Newtonsoft.Json;

namespace TaxManager.Requests
{
    public class VATData
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? VatPercent { get; set; }

        public decimal VatSum { get; set; } = 0;
    }



}
