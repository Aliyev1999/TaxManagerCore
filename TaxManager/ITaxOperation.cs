using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Requests;
using TaxManager.Response;

namespace TaxManager
{
    public interface ITaxOperation
    {
        MBAResponse AddCorrection(CorrectionRequest correction);

        MBAResponse Rollback(RollBackRequest inv);

        MBAResponse AddWithdraw(WithdrawRequest withdraw);

        MBAResponse Reprint(string docNumber);

        MBAResponse AddDeposit(DepositRequest deposit);

        MBAResponse Return(ReturnRequest bonus);

        MBAResponse Sale(SaleRequest invoice);

        MBAResponse GetXReport();

        MBAResponse GetZReport();

    }
}
