using TaxManager.Requests;
using TaxManager.Response;
using TaxManager.Token;
using TaxManager.Token.Response;

namespace TaxManager
{
    internal interface ITokenOperation
    {
        MBAResponse AddCorrection(CorrectionRequest correction);

        MBAResponse Rollback(RollBackRequest inv);

        MBAResponse AddWithdraw(WithdrawRequest withdraw);
        MBAResponse Reprint(string docNumber);

        MBAResponse AddDeposit(DepositRequest deposit);

        MBAResponse Return(ReturnRequest bonus);

        MBAResponse Sale(SaleRequest invoice);

        MBAResponse GetXReport();

        MBAResponse CloseShift();

        MBAResponse LogoutTaxDevice();

        MBAResponse OpenShift();

        MBAResponse LoginTaxDevice();

        TokenGetShiftResponse GetShiftStatus();

        TokenInfoResponse GetNmqInfo();


    }
}
