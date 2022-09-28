using C_project__last_week__Bank.Data;
using C_project__last_week__Bank.Models;
using C_project__last_week__Bank.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_project__last_week__Bank.Services.Implementations
{
    public class BranchService : IBranchService, IBankService<Branch>
    {
        private Bank<Branch> data;
        public BranchService()
        {
            data = new Bank<Branch>();
        }
        public void Create(Branch partner)
        {
            
                data.Datas.Add(partner);
        }

        public void Delete(string name)
        {
            Branch branch = data.Datas.Find(x => x.Name == name.ToLower().Trim());
            branch.SoftDelete = true;
        }

        public void Get(string basentity)
        {
            try
            {
                Branch branch = data.Datas.Find(n => n.Name == basentity.ToLower().Trim());
                Console.WriteLine(branch.Name + " " + branch.Budget);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Branch not found");
            }
        }

        public void GetAll()
        {
            foreach (var branch in data.Datas.Where(m => m.SoftDelete = false)) ;
        }

        public void GetProfit()
        {
            throw new NotImplementedException();
        }

        public void HireEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferMoney()
        {
            throw new NotImplementedException();
        }

        public void Update(string Text, decimal Number, string Text1)
        {
            Branch branch = data.Datas.Find(u => u.Name.ToLower().Trim() == Text.ToLower().Trim());
            branch.Budget = Number;
            branch.Address = Text1;
        }
    }
}
