using System;
using System.Collections.Generic;

namespace TaxManager.Token.Response
{
    public class ReportData
    {
        public string document_id { get; set; }

        public string shiftOpenAtUtc { get; set; }

        public string createdAtUtc { get; set; }

        public int firstDocNumber { get; set; }

        public int lastDocNumber { get; set; }

        public int reportNumber { get; set; }
        //
        public int docCountToSend { get; set; }
        //
        public List<Currency> currencies { get; set; }

        public DateTime ShiftOpenAt => Convert.ToDateTime(shiftOpenAtUtc);

        public DateTime CreatedAt => Convert.ToDateTime(createdAtUtc);

    }
}
