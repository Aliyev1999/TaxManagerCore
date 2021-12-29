using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager
{
    public  static class TaxAccess
    {
        public static volatile string AccessKey;

        private static TokenSettings token;

        public static TokenSettings Token
        {
            get
            {
                if(token==null)
                {
                    try
                    {
                        token = TokenSettings.Get();
                    }
                    catch(Exception ex)
                    {

                    }
                }
                return token;
            }
        }

    }
}
