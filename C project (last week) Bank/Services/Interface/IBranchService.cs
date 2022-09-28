using C_project__last_week__Bank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_project__last_week__Bank.Services.Interface
{
    public interface IBranchService : IBankService<Branch>
    {
        void HireEmployee();
        void GetProfit();
        void TransferMoney();
        void TransferEmployee();
    }
}
