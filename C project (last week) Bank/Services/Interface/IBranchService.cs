using C_project__last_week__Bank.Models;
using C_project__last_week__Bank.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_project__last_week__Bank.Services.Interface
{
    public interface IBranchService : IBankService<Branch>
    {
        void HireEmployee(Branch branch, EmployeeService employeeService);
        void GetProfit(Branch branch);
        void TransferMoney();
        void TransferEmployee(string employeeName,string branchName, Branch branch);

    }
}
