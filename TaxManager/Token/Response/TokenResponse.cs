namespace TaxManager.Token.Response
{
    public class TokenResponse
    {
        public int code { get; set; }

        public string message { get; set; }

        public bool IsSucces => code == 0;
    }
}
