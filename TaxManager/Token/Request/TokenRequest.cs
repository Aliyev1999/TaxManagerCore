using Newtonsoft.Json;

namespace TaxManager.Token.Request
{
    public class TokenRequest
    {
        public string operationId { get; set; }

        public int version { get; set; }
    }
}
