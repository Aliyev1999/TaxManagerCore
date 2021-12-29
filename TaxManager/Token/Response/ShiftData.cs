using System;

namespace TaxManager.Token.Response
{
    public class ShiftData
    {
        public bool shift_open { get; set; }

        public string shift_open_time { get; set; }

        //{\"code\":0,\"message\":\"Success operation\",\"data\":{\"shift_open\":true,\"shift_open_time\":\"2019-05-15T08:59:55Z\"}}

        public DateTime ShiftOpenTime => Convert.ToDateTime(shift_open_time);
    }
}
