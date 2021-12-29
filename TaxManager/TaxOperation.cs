using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Constants;
using TaxManager.Requests;
using TaxManager.Response;
using TaxManager.Token.Response;

namespace TaxManager
{
    public class TaxOperation : ITaxOperation
    {

        private static ITokenOperation tokenOperation;

        public TaxOperation(string configurationFileDirectory)
        {
            AppConfiguration.ConfigurationPath = configurationFileDirectory;

            tokenOperation = TokenOperation.GetInstance();
        }

        public MBAResponse AddCorrection(CorrectionRequest correction)
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = CheckShift();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.AddCorrection(correction);

            if (!response.IsSucces)
            {
                return response;
            }

            return response;

        }

        public MBAResponse AddDeposit(DepositRequest deposit)
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = CheckShift();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.AddDeposit(deposit);

            if (!response.IsSucces)
            {
                return response;
            }

            return response;


        }

        public MBAResponse AddWithdraw(WithdrawRequest withdraw)
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = CheckShift();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.AddWithdraw(withdraw);

            if (!response.IsSucces)
            {
                return response;
            }

            return response;
        }

        public MBAResponse GetZReport()
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.CloseShift();

            if (!response.IsSucces)
            {
                return response;
            }

            return response;
        }

        public MBAResponse GetXReport()
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = CheckShift();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.GetXReport();

            if (!response.IsSucces)
            {
                return response;
            }

            return response;
        }

        public MBAResponse Reprint(string docNumber)
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = CheckShift();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.Reprint(docNumber);

            if (!response.IsSucces)
            {
                return response;
            }

            return response;
        }

        public MBAResponse Return(ReturnRequest invoice)
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = CheckShift();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.Return(invoice);

            if (!response.IsSucces)
            {
                return response;
            }

            return response;
        }

        public MBAResponse Rollback(RollBackRequest inv)
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = CheckShift();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.Rollback(inv);

            if (!response.IsSucces)
            {
                return response;
            }

            return response;
        }

        public MBAResponse Sale(SaleRequest invoice)
        {
            MBAResponse response = new MBAResponse();

            response = tokenOperation.LoginTaxDevice();

            if (!response.IsSucces)
            {
                return response;
            }

            response = CheckShift();

            if (!response.IsSucces)
            {
                return response;
            }

            response = tokenOperation.Sale(invoice);

            if (!response.IsSucces)
            {
                return response;
            }

            return response;
        }

        private MBAResponse CheckShift()
        {
            try
            {
                MBAResponse response = new MBAResponse();
                var getShiftStatusResponse = tokenOperation.GetShiftStatus();
                if (getShiftStatusResponse.IsSucces)
                {
                    if (getShiftStatusResponse.data.shift_open == true)
                    {
                        if ((DateTime.Now - getShiftStatusResponse.data.ShiftOpenTime).TotalHours >= 24)
                        {
                            response.Mesage = "The shift should not be open for more than 24 hours.";
                            response.IsSucces = false;

                            return response;
                        }
                    }
                    else
                    {
                        response = tokenOperation.OpenShift();

                        return response;
                    }
                }

                response.Mesage = getShiftStatusResponse.message;
                response.IsSucces = getShiftStatusResponse.IsSucces;
                response.StatusCode = getShiftStatusResponse.code;
                response.ResponseString = JsonConvert.SerializeObject(getShiftStatusResponse);

                return response;
            }
            catch (Exception e)
            {
                MBAResponse response = new MBAResponse()
                {
                    IsSucces = false,
                    Mesage = "Internal Error",
                    StatusCode = 500,
                    ResponseString = e.Message.ToString(),
                };
                return response;
            }

        }

    }

}
