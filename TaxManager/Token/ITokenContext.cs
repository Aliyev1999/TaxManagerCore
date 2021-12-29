
using TaxManager.Requests;
using TaxManager.Token.Response;

namespace TaxManager.Token
{
    internal interface ITokenContext
    {
        TokenLoginResponse Login(string cashRegisterFactoryNumber, string pin);
        TokenResponse Logout(string accessKey);
        TokenGetShiftResponse GetShiftStatus(string accessKey);
        TokenResponse OpenShift(string accessKey);
        TokenZReportResponse CloseShift(string accessKey);
        TokenXReportResponse GetXReport(string accessKey);
        TokenInfoResponse GetTokenInfo();


        TokenOperationResponse Sale(SaleRequest invoice, string accessKey);
        TokenOperationResponse Return(ReturnRequest invoice, string accessKey); // money_back
        TokenOperationResponse AddDeposit(decimal deposit, string cashierName, string accessKey);
        TokenOperationResponse Reprint(string docNumber);

        TokenOperationResponse AddWithDraw(decimal withdraw, string cashierName, string accessKey);
        TokenOperationResponse RollBack(RollBackRequest invoice, string accessKey);
        TokenOperationResponse AddCorrection(CorrectionRequest correction, string accessKey);

    }
}
