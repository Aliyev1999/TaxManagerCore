using System;

namespace TaxManager.Token.Request
{
    public class CorrectionData : MonyBack
    {
        public string firstOperationAtUtc { get; set; }

        public string lastOperationAtUtc { get; set; }

        public DateTime FirstOperationAtUtc
        {
            get
            {
                return Convert.ToDateTime(firstOperationAtUtc);
            }
            set
            {
                //FirstOperationAtUtc = value;
                firstOperationAtUtc = value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
            }
        }

        public DateTime LastOperationAtUtc
        {
            get
            {
                return Convert.ToDateTime(lastOperationAtUtc);
            }
            set
            {
                //LastOperationAtUtc = value;
                lastOperationAtUtc = value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
            }
        }

    }

}
