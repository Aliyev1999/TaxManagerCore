using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Extensions
{
    public static class DecimalExtension
    {
        public static decimal ToRoundedDecimal(this decimal value, int decimalPlaces = 2)
        {
            return Math.Round(value, decimalPlaces);
        }
    }
}
