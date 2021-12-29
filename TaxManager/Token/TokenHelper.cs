using Newtonsoft.Json;
using System.Collections.Generic;
using TaxManager.Extensions;
using TaxManager.Requests;
using TaxManager.Token.Request;

namespace TaxManager.Token
{
    public static class TokenHelper
    {
        public static string SerializeSaleForToken(SaleRequest invoice, string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "createDocument";
            request.parameters = new DocumentParameters()
            {
                access_token = accessKey,
                doc_type = "sale"
            };

            List<Item> items = new List<Item>();
            decimal itemSum = 0;
            foreach (DocumentItem invoiceDetail in invoice.Items)
            {
                Item item = new Item();
                item.itemName = invoiceDetail.ItemName;
                item.itemCode = invoiceDetail.ItemCode;
                item.itemQuantity = invoiceDetail.ItemQuantity;//.ToRoundedDecimal();
                item.itemPrice = invoiceDetail.ItemPrice;//.ToRoundedDecimal();
                item.itemSum = invoiceDetail.ItemSum;//.ToRoundedDecimal();
                item.itemCodeType = invoiceDetail.ItemCodeType; // this means itemCode is EAN0 EAN8 barcode
                item.itemVatPercent = invoiceDetail.ItemVatPercent;

                item.itemMarginPrice = invoiceDetail.ItemMarginPrice;
                item.itemMarginSum = invoiceDetail.ItemMarginSum;
                itemSum += item.itemSum;
                items.Add(item);
            }


            List<Common.VATData> vatAmounts = new List<Common.VATData>();
            foreach (var item in invoice.VATDatas)
            {
                vatAmounts.Add(new Common.VATData()
                {
                    vatPercent = item.VatPercent,
                    vatSum = item.VatSum
                });
            }

            SaleData data;
            if (invoice.Customer != null)
            {
                data = new SaleData()
                {
                    textField1 = $"[left]Müştəri:  {invoice.Customer.FullName}[/left][left]İlkin bonus:          {invoice.PaymentData.InitialBonus}[/left][left]Qazanılan bonus:      {invoice.PaymentData.EarnedBonus}[/left][left]Ödənilən bonus:       {invoice.PaymentData.PaidedBonus}[/left][left]Son bonus:            {invoice.PaymentData.FinalBonus}[/left]",
                    cashier = invoice.CashierName,
                    currency = "AZN",
                    items = items,
                    cashSum = invoice.PaymentData.CashSum.ToRoundedDecimal(3),//.ToRoundedDecimal(),
                    cashlessSum = invoice.PaymentData.CashlessSum,//.ToRoundedDecimal(),
                    creditSum = invoice.PaymentData.CreditSum,
                    prepaymentSum = invoice.PaymentData.PrepaymentSum,
                    bonusSum = invoice.PaymentData.BonusSum,//.ToRoundedDecimal(),
                    sum = invoice.PaymentData.Sum.ToRoundedDecimal(3),
                    vatAmounts = vatAmounts,
                    cashFromClient = invoice.PaymentData.CashFromClient

                };
            }
            else
            {
                data = new SaleData()
                {
                    textField1 = "",
                    cashier = invoice.CashierName,
                    currency = "AZN",
                    items = items,
                    cashSum = invoice.PaymentData.CashSum.ToRoundedDecimal(3),//.ToRoundedDecimal(),
                    cashlessSum = invoice.PaymentData.CashlessSum,//.ToRoundedDecimal(),
                    creditSum = invoice.PaymentData.CreditSum,
                    prepaymentSum = invoice.PaymentData.PrepaymentSum,
                    bonusSum = invoice.PaymentData.BonusSum,//.ToRoundedDecimal(),
                    sum = invoice.PaymentData.Sum.ToRoundedDecimal(3),
                    vatAmounts = vatAmounts,
                    cashFromClient = invoice.PaymentData.CashFromClient

                };
            }

            if (itemSum != data.sum)
            {
                decimal sub = data.sum - itemSum;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].itemSum + sub > 0)
                    {
                        items[i].itemSum += sub;
                        if (data.cashlessSum > 0 && data.sum < data.cashlessSum)
                            data.cashlessSum = data.sum;
                        break;
                    }
                }

            }

            (request.parameters as DocumentParameters).data = data;

            //  (data as MoneyBackData).parentDocument = invoice.ParentFiscalId;
            (request.parameters as DocumentParameters).data = data;

            string str = JsonConvert.SerializeObject(request);
            return str;
        }

        public static string SerializeReturnForToken(ReturnRequest invoice, string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "createDocument";
            request.parameters = new DocumentParameters()
            {
                access_token = accessKey,
                doc_type = "sale"
            };

            List<Item> items = new List<Item>();
            decimal itemSum = 0;
            foreach (DocumentItem invoiceDetail in invoice.Items)
            {
                Item item = new Item();
                item.itemName = invoiceDetail.ItemName;
                item.itemCode = invoiceDetail.ItemCode;
                item.itemQuantity = invoiceDetail.ItemQuantity;//.ToRoundedDecimal();
                item.itemPrice = invoiceDetail.ItemPrice;//.ToRoundedDecimal();
                item.itemSum = invoiceDetail.ItemSum;//.ToRoundedDecimal();
                item.itemCodeType = invoiceDetail.ItemCodeType; // this means itemCode is EAN0 EAN8 barcode
                item.itemVatPercent = invoiceDetail.ItemVatPercent;

                item.itemMarginPrice = invoiceDetail.ItemMarginPrice;
                item.itemMarginSum = invoiceDetail.ItemMarginSum;
                itemSum += item.itemSum;
                items.Add(item);
            }


            List<Common.VATData> vatAmounts = new List<Common.VATData>();
            foreach (var item in invoice.VATDatas)
            {
                vatAmounts.Add(new Common.VATData()
                {
                    vatPercent = item.VatPercent,
                    vatSum = item.VatSum
                });
            }

            SaleData data;
            if (invoice.Customer != null)
            {
                data = new MoneyBackData()
                {
                    textField1 = $"[left]Müştəri:  {invoice.Customer.FullName}[/left][left]İlkin bonus:          {invoice.PaymentData.InitialBonus}[/left][left]Qazanılan bonus:      {invoice.PaymentData.EarnedBonus}[/left][left]Ödənilən bonus:       {invoice.PaymentData.PaidedBonus}[/left][left]Son bonus:            {invoice.PaymentData.FinalBonus}[/left]",
                    cashier = invoice.CashierName,
                    currency = "AZN",
                    items = items,
                    cashSum = invoice.PaymentData.CashSum.ToRoundedDecimal(3),//.ToRoundedDecimal(),
                    cashlessSum = invoice.PaymentData.CashlessSum,//.ToRoundedDecimal(),
                    creditSum = invoice.PaymentData.CreditSum,
                    prepaymentSum = invoice.PaymentData.PrepaymentSum,
                    bonusSum = invoice.PaymentData.BonusSum,//.ToRoundedDecimal(),
                    sum = invoice.PaymentData.Sum.ToRoundedDecimal(3),
                    vatAmounts = vatAmounts,
                    cashFromClient=invoice.PaymentData.CashFromClient
                };
            }
            else
            {
                data = new MoneyBackData()
                {
                    textField1 = "",
                    cashier = invoice.CashierName,
                    currency = "AZN",
                    items = items,
                    cashSum = invoice.PaymentData.CashSum.ToRoundedDecimal(3),//.ToRoundedDecimal(),
                    cashlessSum = invoice.PaymentData.CashlessSum,//.ToRoundedDecimal(),
                    creditSum = invoice.PaymentData.CreditSum,
                    prepaymentSum = invoice.PaymentData.PrepaymentSum,
                    bonusSum = invoice.PaymentData.BonusSum,//.ToRoundedDecimal(),
                    sum = invoice.PaymentData.Sum.ToRoundedDecimal(3),
                    vatAmounts = vatAmounts,
                    cashFromClient = invoice.PaymentData.CashFromClient

                };
            }
            if (itemSum != data.sum)
            {
                decimal sub = data.sum - itemSum;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].itemSum + sub > 0)
                    {
                        items[i].itemSum += sub;
                        if (data.cashlessSum > 0 && data.sum < data.cashlessSum)
                            data.cashlessSum = data.sum;
                        break;
                    }
                }
            }

            (data as MoneyBackData).parentDocument = invoice.ParentFiscalId;
            (request.parameters as DocumentParameters).data = data;

            string str = JsonConvert.SerializeObject(request);
            return str;
        }

        internal static string SerializeCorrectionForToken(CorrectionRequest correction, string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "createDocument";
            CorrectionData data = new CorrectionData();
            data.bonusSum = correction.PaymentData.BonusSum;
            data.cashier = correction.CashierName;
            data.cashlessSum = correction.PaymentData.CashlessSum;
            data.cashSum = correction.PaymentData.CashSum;
            data.creditSum = correction.PaymentData.CreditSum;
            data.currency = correction.PaymentData.Currency;
            data.FirstOperationAtUtc = correction.FirstOperationAtUtc;
            data.LastOperationAtUtc = correction.LastOperationAtUtc;
            data.prepaymentSum = correction.PaymentData.PrepaymentSum;

            decimal sum = data.bonusSum + data.cashSum + data.cashlessSum + data.creditSum + data.prepaymentSum;
            data.sum = sum;

            data.vatAmounts = new List<Common.VATData>();

            Common.VATData vatData = new Common.VATData();
            vatData.vatPercent = correction.VatPercent;
            vatData.vatSum = sum;

            data.vatAmounts.Add(vatData);


            request.parameters = new DocumentParameters()
            {
                access_token = accessKey,
                doc_type = "correction",
                data = data
            };

            return JsonConvert.SerializeObject(request);
        }

        internal static string SerializeDepositForToken(decimal deposit, string cashierName, string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "createDocument";
            Data data = new Data();
            data.sum = deposit.ToRoundedDecimal();
            data.cashier = cashierName;
            data.currency = "AZN";

            request.parameters = new DocumentParameters() { access_token = accessKey, doc_type = "deposit", data = data };

            return JsonConvert.SerializeObject(request);
        }

        internal static string SerializeWithDrawForToken(decimal withdraw, string cashierName, string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "createDocument";

            Data data = new Data
            {
                sum = withdraw.ToRoundedDecimal(),
                cashier = cashierName,
                currency = "AZN"
            };

            request.parameters = new DocumentParameters() { access_token = accessKey, doc_type = "withdraw", data = data };

            return JsonConvert.SerializeObject(request);
        }


        public static string SerializeRollBackForToken(RollBackRequest invoice, string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "createDocument";
            ///VATP changes
            List<Common.VATData> vatAmounts = new List<Common.VATData>();
            foreach (var item in invoice.VATDatas)
            {
                vatAmounts.Add(new Common.VATData()
                {
                    vatPercent = item.VatPercent,
                    vatSum = item.VatSum
                });
            }

            request.parameters = new DocumentParameters()
            {
                access_token = accessKey,
                doc_type = "rollback",
                data = new RollbackData()
                {
                    cashier = invoice.CashierName,
                    currency = "AZN",
                    cashSum = invoice.CashSum,//.ToRoundedDecimal(),
                    cashlessSum = invoice.CashlessSum,//.ToRoundedDecimal(),
                    creditSum = invoice.CreditSum,
                    prepaymentSum = invoice.PrepaymentSum,
                    bonusSum = invoice.BonusSum,//.ToRoundedDecimal(),
                    sum = invoice.Sum.ToRoundedDecimal(),
                    vatAmounts = vatAmounts,
                    parentDocument = invoice.ParentFiscalId // ??
                }
            };

            return JsonConvert.SerializeObject(request);
        }


    }
}
