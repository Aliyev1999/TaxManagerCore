using Newtonsoft.Json;
using System;

namespace TaxManager.Extensions
{
    public static class StringExtensions
    {
        public static T DeserializeAsJson<T>(this string json)
        {
            try
            {
                if (json.IsEmpty()) return default(T);

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
