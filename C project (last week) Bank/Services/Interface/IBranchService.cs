using C_project__last_week__Bank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_project__last_week__Bank.Services.Interface
{
    public interface IBranchService : IBankService<Branch>
    {
        void HireEmployee(string employeeName,string branhcName);
        void GetProfit(string branchName, decimal totalSalary, decimal profitCount);
        void TransferMoney(decimal transferAmount,string transferId);
        void TransferEmployee(string employeeName,string branchName, Branch branch);

    }
}
