using C_project__last_week__Bank.Data;
using C_project__last_week__Bank.Models;
using C_project__last_week__Bank.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_project__last_week__Bank.Services.Implementations
{
    public class BranchService : IBranchService,IBankService<Branch>
    {
        private Bank<Branch> data;
        public BranchService()
        {
            data = new Bank<Branch>();
        }
        public void Create(Branch partner)
        {
            
                data.Datas.Add(partner);
            Console.Clear();
            Console.WriteLine("Create Branch");
            Console.WriteLine("Please Enter the Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please Enter the Budget:");
            decimal budget = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Address:");
            string address = Console.ReadLine();
            partner.Name = name;
            partner.Budget = budget;
            partner.Address = address;
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
            catch (Exception ex)
            {
                Console.WriteLine("Branch not found");
            }
        }

        public void GetAll()
        {
            foreach (var branch in data.Datas.Where(m => m.SoftDelete = false)) ;
        }

        public void GetProfit( string branchName,decimal totalSalary,decimal profitCount)
        {
    
        }

        public void HireEmployee(string employeeName,string branchName)
        {

        }

        public void TransferEmployee(string employeeName,string branchName,Branch branch)
        {
            Console.WriteLine(         "Transfer Employee");
            Console.Write(             "Please Enter the Employee's name");
            string ename = Console.ReadLine();
            Console.WriteLine(         "Please Enter the Branch Name");
            string bname = Console.ReadLine();
            int count=Convert.ToInt32(Console.ReadLine());
            Employee employee = new Employee();
            foreach(Branch Transfer in data.Datas)
            {
                if (employee.Name != employeeName)
                {
                    
                    Console.WriteLine("Employee successfully added ");
                    
                }
                else if (employee.Name == employeeName)
                {
                    Console.WriteLine("Employee already in this branch");
                }
            }
            foreach(Branch Transfer in data.Datas)
            {
                if(employee.Name != bname)
                {
                    Console.WriteLine("");
                }
            }
        }

        public void TransferMoney(decimal transferAmount,string transferId)
        { 
            Console.WriteLine(           "Transfer Money");
            Console.Write(           "Please Enter Your Name:");
            string mainame=Console.ReadLine();
            Console.Write(          "Please Enter the Owner Name :");
            string name =Console.ReadLine();
            Console.WriteLine(       "Select Amount :");
            int amount = Convert.ToInt32(Console.ReadLine());
            Employee employee = new Employee();
            foreach(Branch Transfer in data.Datas)
            {
                if (employee.Name == name)
                {
                    Transfer.Budget += employee.Salary;

                }               
            }
            foreach(Branch Transfer in data.Datas)
            {
                if(Transfer.Name == employee.Name)
                {
                    employee.Salary += Transfer.Budget;
                }
            }
        }

        public void Update(string Text, decimal Number, string Text1)
        {
            {
                Branch branch = data.Datas.Find(u => u.Name.ToLower().Trim() == Text.ToLower().Trim());
                branch.Budget = Number;
                branch.Address = Text1;
            }
        }
    }

}
