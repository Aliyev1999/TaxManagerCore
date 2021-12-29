using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Response
{
    public class MBAResponse
    {
        public bool IsSucces;

        public int StatusCode;

        public string ResponseString;

        public string Mesage;

        public string FiscalNumber;

        public string ShortFiscalNumber { get; set; }
    }
}
