using System;
using System.IO;
using TaxManager.Constants;
using TaxManager.Extensions;

namespace TaxManager
{
    public class TokenSettings
    {
        private static TokenSettings x;
        private const string ConfigFileName = "TokenConfig.json";
        private static string ConfigurationDirectory = AppDomain.CurrentDomain.BaseDirectory;

        private TokenSettings()
        {

        }
        public static TokenSettings Get()
        {
            if (x == null)
            {
                try
                {
                    var json = File.ReadAllText(AppConfiguration.ConfigurationPath);
                    x = json.DeserializeAsJson<TokenSettings>();
                }
                catch(Exception e) { }

                if (x == null) x = new TokenSettings();
            }

            return x;
        }

        public string CashRegisterFactoryNumber { get; set; } 

        public string TokenPIN { get; set; }

        public string TokenAddress { get; set; }

        public void Save()
        {
            var json = this.SerializeToJson();
            File.WriteAllText(AppConfiguration.ConfigurationPath, json);
        }

    }
}
