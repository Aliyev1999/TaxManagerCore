using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Extensions
{
    internal static class JsonExtensions
    {
        public static string SerializeToJson(this object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented, GetSettings());
        }

        private static JsonSerializerSettings GetSettings()
        {
            return new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, Formatting = Formatting.Indented };
        }
    }
}
