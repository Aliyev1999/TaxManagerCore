using System;
using Newtonsoft.Json;
using System.Threading;
using TaxManager.Requests;
using NetMQ.Sockets;
using NetMQ;
using TaxManager.Token.Request;
using TaxManager.Token.Response;

namespace TaxManager.Token
{
    internal class TokenContext : ITokenContext
    {
        //Fields
        private static TokenContext tokenInstance;

        //Constructors
        private TokenContext() { }

        //Methods 
        public static ITokenContext GetInstance()
        {
            if (tokenInstance == null) tokenInstance = new TokenContext();
            return tokenInstance;
        }


        // requests

        private string ExecuteRequest(string message)
        {

            using (var client = new RequestSocket())
            {
                client.Connect(TaxAccess.Token.TokenAddress);

                using (var cts = new CancellationTokenSource(new TimeSpan(0, 0, 10)))
                {
                    client.SendFrame(message);

                    string str = client.ReceiveFrameString();

                    return str;
                }
            }
        }


        private TokenResponse ExecuteSimpleRequest(string message)
        {
            string str = ExecuteRequest(message);

            var obj = JsonConvert.DeserializeObject<TokenResponse>(str);

            return obj;
        }

        private TokenInfoResponse ExecuteGetInfoRequest(string message)
        {
            string str = ExecuteRequest(message);

            var obj = JsonConvert.DeserializeObject<TokenInfoResponse>(str);

            return obj;
        }

        private TokenLoginResponse ExecuteLoginRequest(string message)
        {
            string str = ExecuteRequest(message);

            var obj = JsonConvert.DeserializeObject<TokenLoginResponse>(str);

            return obj;
        }

        private TokenGetShiftResponse ExecuteGetShiftRequest(string message)
        {
            string str = ExecuteRequest(message);

            var obj = JsonConvert.DeserializeObject<TokenGetShiftResponse>(str);

            return obj;
        }
        private TokenOperationResponse ExecuteReprintRequest(string message)
        {
            string str = ExecuteRequest(message);

            var obj = JsonConvert.DeserializeObject<TokenOperationResponse>(str);

            return obj;
        }

        private TokenZReportResponse ExecuteCloseShiftRequest(string message)
        {
            string str = ExecuteRequest(message);

            var obj = JsonConvert.DeserializeObject<TokenZReportResponse>(str);

            return obj;
        }

        private TokenOperationResponse ExecuteOperationRequest(string message)
        {
            string str = ExecuteRequest(message);

            var obj = JsonConvert.DeserializeObject<TokenOperationResponse>(str);

            return obj;
        }


        // commands
        public TokenLoginResponse Login(string cashRegisterFactoryNumber, string pin)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "toLogin";
            request.parameters = new LoginParameters()
            {
                pin = pin,
                role = "user",
                cashregister_factory_number = cashRegisterFactoryNumber
            };

            string str = JsonConvert.SerializeObject(request);

            return ExecuteLoginRequest(JsonConvert.SerializeObject(request));
        }

        public TokenResponse Logout(string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "toLogout";
            request.parameters = new AuthenticatedCommandParameters()
            {
                access_token = accessKey
            };

            return ExecuteSimpleRequest(JsonConvert.SerializeObject(request));
        }
        public TokenOperationResponse Reprint(string docNumber)
        {
            TokenAdvanceRequest tokenAdvanceRequest = new TokenAdvanceRequest();

            tokenAdvanceRequest.version = 1;
            tokenAdvanceRequest.operationId = "printReceiptCopy";
            tokenAdvanceRequest.parameters = new ReprintData() { document_number = docNumber };

            return ExecuteReprintRequest(JsonConvert.SerializeObject(tokenAdvanceRequest));

        }



        public TokenGetShiftResponse GetShiftStatus(string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "getShiftStatus";
            request.parameters = new AuthenticatedCommandParameters()
            {
                access_token = accessKey
            };

            return ExecuteGetShiftRequest(JsonConvert.SerializeObject(request));

        }

        public TokenResponse OpenShift(string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "openShift";
            request.parameters = new AuthenticatedCommandParameters() { access_token = accessKey };

            TokenResponse openShiftResponse = ExecuteSimpleRequest(JsonConvert.SerializeObject(request));

            return openShiftResponse;
        }

        public TokenZReportResponse CloseShift(string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "closeShift";
            request.parameters = new AuthenticatedCommandParameters() { access_token = accessKey };

            TokenZReportResponse closeShiftResponse = ExecuteCloseShiftRequest(JsonConvert.SerializeObject(request));

            return closeShiftResponse;
        }

        public TokenXReportResponse GetXReport(string accessKey)
        {
            TokenAdvanceRequest request = new TokenAdvanceRequest();

            request.version = 1;
            request.operationId = "getXReport";
            request.parameters = new AuthenticatedCommandParameters() { access_token = accessKey };

            TokenXReportResponse closeShiftResponse = ExecuteCloseShiftRequest(JsonConvert.SerializeObject(request));

            return closeShiftResponse;
        }

        public TokenOperationResponse Sale(SaleRequest invoice, string accessKey)
        {
            string serializedString = TokenHelper.SerializeSaleForToken(invoice, accessKey);

            TokenOperationResponse saleResponse = ExecuteOperationRequest(serializedString);

            return saleResponse;
        }

        public TokenOperationResponse Return(ReturnRequest invoice, string accessKey)
        {
            string serializedString = TokenHelper.SerializeReturnForToken(invoice, accessKey);

            TokenOperationResponse returnResponse = ExecuteOperationRequest(serializedString);

            return returnResponse;
        }

        public TokenOperationResponse AddDeposit(decimal deposit, string cashierName, string accessKey)
        {
            TokenOperationResponse depositResponse = ExecuteOperationRequest(TokenHelper.SerializeDepositForToken(deposit, cashierName, accessKey));

            return depositResponse;
        }

        public TokenOperationResponse AddWithDraw(decimal withdraw, string cashierName, string accessKey)
        {
            string serializedString = TokenHelper.SerializeWithDrawForToken(withdraw, cashierName, accessKey);

            TokenOperationResponse withdrawResponse = ExecuteOperationRequest(serializedString);

            return withdrawResponse;
        }

        public TokenOperationResponse RollBack(RollBackRequest invoice, string accessKey)
        {
            TokenOperationResponse rollBackResponse = ExecuteOperationRequest(TokenHelper.SerializeRollBackForToken(invoice, accessKey));

            return rollBackResponse;
        }

        public TokenInfoResponse GetTokenInfo()
        {
            TokenRequest request = new TokenRequest();
            request.version = 1;
            request.operationId = "getInfo";

            TokenInfoResponse getInfoResponse = ExecuteGetInfoRequest(JsonConvert.SerializeObject(request));

            return getInfoResponse;

        }

        public TokenOperationResponse AddCorrection(CorrectionRequest correction, string accessKey)
        {
            TokenOperationResponse correctionResponse = ExecuteOperationRequest(TokenHelper.SerializeCorrectionForToken(correction, accessKey));
          
            return correctionResponse;
        }


    }
}
