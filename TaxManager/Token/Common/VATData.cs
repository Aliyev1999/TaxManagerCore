using Newtonsoft.Json;

namespace TaxManager.Token.Common
{
    public class VATData
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? vatPercent { get; set; }

        public decimal vatSum { get; set; } = 0;
    }
}
