namespace TaxManager.Token.Response
{
    public class InfoData
    {
        //{"code":0,"message":"Success operation","data":{"company_tax_number":"123456789","company_name":"Microsoft","object_tax_number":"12345","object_name":"BazarStore","object_addres":"c. Baku str. Alieva b. 10","cashbox_tax_number":"test567890","cashbox_factory_number":"AVQ1019990201","firmware_version":"v0.1","cashregister_factory_number":"AVQ1019990201","cashregister_model":"TESLA01234555XB","qr_code_url":"https://monitoring.e-kassa.az/#/index?doc=","not_before":"2019-01-01T23:28:56Z","not_after":"2019-01-01T23:28:56Z","state":"ACTIVE", "last_online_time":"2019-01-01T23:28:56Z", "oldest_document_time":"2019-01-01T23:28:56Z"}}}
        public string company_tax_number { get; set; }

        public string company_name { get; set; }

        public string object_tax_number { get; set; }

        public string object_name { get; set; }

        public string object_address { get; set; }

        public string cashbox_tax_number { get; set; }

        public string cashbox_factory_number { get; set; }

        public string firmware_version { get; set; }

        public string cashregister_factory_number { get; set; }

        public string cashregister_model { get; set; }

        public string qr_code_url { get; set; }

        public string not_before { get; set; }

        public string not_after { get; set; }

        public string state { get; set; }

        public string last_online_time { get; set; }

        public string oldest_document_time { get; set; }
    }



}
