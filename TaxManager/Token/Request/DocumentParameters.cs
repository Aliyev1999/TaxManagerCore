namespace TaxManager.Token.Request
{
    public class DocumentParameters : AuthenticatedCommandParameters
    {
        public string doc_type { get; set; }

        public Data data { get; set; }
    }

}
