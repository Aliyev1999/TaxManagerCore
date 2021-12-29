using Newtonsoft.Json;
using System;
using TaxManager.Requests;
using TaxManager.Response;
using TaxManager.Token;
using TaxManager.Token.Response;

namespace TaxManager
{

    internal class TokenOperation : ITokenOperation
    {
        private readonly ITokenContext TokenContext;

        private static TokenOperation tokenOperationInstance;

        public TokenOperation()
        {

            TokenContext = TaxManager.Token.TokenContext.GetInstance();
        }

        public static ITokenOperation GetInstance()
        {
            tokenOperationInstance ??= new TokenOperation();
            return tokenOperationInstance;
        }

        private static TokenInfoResponse info = null;
        public TokenInfoResponse GetNmqInfo()
        {
            info ??= TokenContext.GetTokenInfo();

            return info;
        }

        private static TokenGetShiftResponse shiftResponse;
        public TokenGetShiftResponse GetShiftStatus()
        {
            if (TaxAccess.AccessKey == null)
            {
                LoginTaxDevice();
            }
            shiftResponse ??= TokenContext.GetShiftStatus(TaxAccess.AccessKey);

            return shiftResponse;
        }

        public MBAResponse LoginTaxDevice()
        {
            try
            {
                TokenLoginResponse loginResponse = TokenContext.Login(TaxAccess.Token.CashRegisterFactoryNumber, TaxAccess.Token.TokenPIN);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = loginResponse.IsSucces,
                    Mesage = loginResponse.message,
                    StatusCode = loginResponse.code,
                    ResponseString = JsonConvert.SerializeObject(loginResponse),
                };

                if (!loginResponse.IsSucces)
                {
                    return response;
                }

                TaxAccess.AccessKey = loginResponse.data.access_token;

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

        public MBAResponse OpenShift()
        {
            try
            {
                TokenResponse openShiftResponse = TokenContext.OpenShift(TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = openShiftResponse.IsSucces,
                    Mesage = openShiftResponse.message,
                    StatusCode = openShiftResponse.code,
                    ResponseString = JsonConvert.SerializeObject(openShiftResponse),
                };

                if (!openShiftResponse.IsSucces)
                {
                    if (openShiftResponse.code == 66)
                    {
                        response.IsSucces = true;
                    }
                }
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

        public MBAResponse LogoutTaxDevice()
        {
            try
            {
                TokenResponse tokenResponse = TokenContext.Logout(TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = tokenResponse.IsSucces,
                    Mesage = tokenResponse.message,
                    StatusCode = tokenResponse.code,
                    ResponseString = JsonConvert.SerializeObject(tokenResponse),
                };

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

        //asaidakilari da duzelt .. operationlar yaradacaqsan
        public MBAResponse CloseShift()
        {
            try
            {
                TokenZReportResponse closeShiftResponse = TokenContext.CloseShift(TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = closeShiftResponse.IsSucces,
                    Mesage = closeShiftResponse.message,
                    StatusCode = closeShiftResponse.code,
                    ResponseString = JsonConvert.SerializeObject(closeShiftResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = closeShiftResponse.data.document_id;
                }

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

        public MBAResponse GetXReport()
        {
            try
            {
                TokenXReportResponse xReportResponse = TokenContext.GetXReport(TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = xReportResponse.IsSucces,
                    Mesage = xReportResponse.message,
                    StatusCode = xReportResponse.code,
                    ResponseString = JsonConvert.SerializeObject(xReportResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = xReportResponse.data.document_id;
                }

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

        public MBAResponse Sale(SaleRequest invoice)
        {
            try
            {
                TokenOperationResponse saleResponse = TokenContext.Sale(invoice, TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = saleResponse.IsSucces,
                    Mesage = saleResponse.message,
                    StatusCode = saleResponse.code,
                    ResponseString = JsonConvert.SerializeObject(saleResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = saleResponse.data.document_id;
                    response.ShortFiscalNumber = saleResponse.data.short_document_id;
                }

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

        public MBAResponse Return(ReturnRequest bonus)
        {
            try
            {
                TokenOperationResponse returnResponse = TokenContext.Return(bonus, TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = returnResponse.IsSucces,
                    Mesage = returnResponse.message,
                    StatusCode = returnResponse.code,
                    ResponseString = JsonConvert.SerializeObject(returnResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = returnResponse.data.document_id;
                    response.ShortFiscalNumber = returnResponse.data.short_document_id;
                }

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

        public MBAResponse AddDeposit(DepositRequest deposit)
        {
            try
            {
                var depositResponse = TokenContext.AddDeposit(deposit.Deposit, deposit.CashierName, TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = depositResponse.IsSucces,
                    Mesage = depositResponse.message,
                    StatusCode = depositResponse.code,
                    ResponseString = JsonConvert.SerializeObject(depositResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = depositResponse.data.document_id;
                    response.ShortFiscalNumber = depositResponse.data.short_document_id;
                }

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

        public MBAResponse Reprint(string docNumber)
        {
            try
            {
                TokenOperationResponse reprintResponse = TokenContext.Reprint(docNumber);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = reprintResponse.IsSucces,
                    Mesage = reprintResponse.message,
                    StatusCode = reprintResponse.code,
                    ResponseString = JsonConvert.SerializeObject(reprintResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = reprintResponse.data.document_id;
                    response.ShortFiscalNumber = reprintResponse.data.short_document_id;
                }

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

        public MBAResponse AddWithdraw(WithdrawRequest withdraw)
        {
            try
            {
                TokenOperationResponse withdrawResponse = TokenContext.AddWithDraw(withdraw.WithdrawValue, withdraw.CashierName, TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = withdrawResponse.IsSucces,
                    Mesage = withdrawResponse.message,
                    StatusCode = withdrawResponse.code,
                    ResponseString = JsonConvert.SerializeObject(withdrawResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = withdrawResponse.data.document_id;
                    response.ShortFiscalNumber = withdrawResponse.data.short_document_id;
                }

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

        public MBAResponse Rollback(RollBackRequest inv)
        {
            try
            {
                TokenOperationResponse rollbackResponse = TokenContext.RollBack(inv, TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = rollbackResponse.IsSucces,
                    Mesage = rollbackResponse.message,
                    StatusCode = rollbackResponse.code,
                    ResponseString = JsonConvert.SerializeObject(rollbackResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = rollbackResponse.data.document_id;
                    response.ShortFiscalNumber = rollbackResponse.data.short_document_id;
                }

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

        public MBAResponse AddCorrection(CorrectionRequest correction)
        {
            try
            {

                TokenOperationResponse correctionResponse = TokenContext.AddCorrection(correction, TaxAccess.AccessKey);

                MBAResponse response = new MBAResponse()
                {
                    IsSucces = correctionResponse.IsSucces,
                    Mesage = correctionResponse.message,
                    StatusCode = correctionResponse.code,
                    ResponseString = JsonConvert.SerializeObject(correctionResponse),
                };
                if (response.IsSucces)
                {
                    response.FiscalNumber = correctionResponse.data.document_id;
                    response.ShortFiscalNumber = correctionResponse.data.short_document_id;
                }

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