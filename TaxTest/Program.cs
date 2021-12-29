using System;
using System.Collections.Generic;
using TaxManager;
using TaxManager.Requests;

namespace TaxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxOperation operation = new TaxOperation(AppDomain.CurrentDomain.BaseDirectory + "TokenConfig.json");

            var Items = new List<DocumentItem>();

            var item = new DocumentItem();
            item.ItemCode = "123";
            item.ItemName = "test";
            item.ItemPrice = 10;
            item.ItemQuantity = 2;
            item.ItemSum = 20;
            item.ItemVatPercent = 18;

            Items.Add(item);

            var VATDatas = new List<VATData>();

            var vatdata = new VATData();
            vatdata.VatPercent = 18;
            vatdata.VatSum = 20;

            VATDatas.Add(vatdata);


            SaleRequest request = new SaleRequest()
            {
                CashierName = "test",
                PaymentData = new PaymentDataWithBonus()
                {
                    CashlessSum = 20,
                    Sum = 20,
                    CashFromClient = 20
                },
                Items = Items,
                VATDatas = VATDatas,
            };
            try
            {
                var response = operation.Sale(request);

            }
            catch(Exception e)
            {

            }
        }
    }
}
