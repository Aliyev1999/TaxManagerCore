namespace TaxManager.Token.Request
{
    public class LoginParameters : Parameters
    {
        public string pin { get; set; }

        public string role { get; set; }

        public string cashregister_factory_number { get; set; }
    }

}
