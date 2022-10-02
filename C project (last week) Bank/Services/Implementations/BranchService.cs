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

        public void Delete()
        {
            string name=Console.ReadLine();
            Branch branch = data.Datas.Find(x => x.Name == name.ToLower().Trim());
            branch.SoftDelete = true;
        }

        public void Get()
        {
              string name = Console.ReadLine();
            try
            {
                Branch branch = data.Datas.Find(l => l.Name.Contains(name.ToLower().Trim()) || l.Budget.ToString().Contains(name.ToLower().Trim()) || l.Address.Contains(name.ToLower().Trim()));
                Console.WriteLine(branch.Name + " " + branch.Budget + " " + branch.Address);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Branch not found ! ! !");
            }
        }

        public void GetAll()
        {
            foreach (var branch in data.Datas.Where(m => m.SoftDelete = false)) ;
        }

        public void GetProfit(Branch branch)
        {
            Console.WriteLine("Calculate profit and less:\n");
            Console.WriteLine("Input Cost Price : ");
            Console.WriteLine("Input Selling Price : ");
            decimal Sellprice = 0;
            branch.employees.ForEach(c => Sellprice += c.Salary);
            decimal GetProfil = branch.Budget - Sellprice;
            Console.WriteLine( $"Profit of the {branch.Name} branch in {GetProfil}");
         
        }

        public void HireEmployee(Branch branch,EmployeeService employeeService)
        {
            Employee employee = new Employee();
            if (branch.Budget > employee.Salary)
            {
                branch.employees.Add(employee);
                branch.Budget = employee.Salary;
                Console.WriteLine($"Employee{employee.Name} surname {employee.Surname} was successfully hired .");
            }
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

        public void TransferMoney()
        { 
            Console.WriteLine(           "Transfer Money");
            Console.Write(           "Please Enter Your Name:");
            string mainame=Console.ReadLine();
            Console.Write(          "Please Enter the Owner Name :");
            string name =Console.ReadLine();
            Console.WriteLine(       "Select Amount :");
            int amount = Convert.ToInt32(Console.ReadLine());
            Branch branch = new Branch();  
            foreach(Branch Transfer in data.Datas)
            {
                if (branch.Name == name)
                {
                    Transfer.Budget += branch.Budget;

                }               
            }
            foreach(Branch Transfer in data.Datas)
            {
                if(Transfer.Name == branch.Name)
                {
                    branch.Budget += Transfer.Budget;
                    break;
                }
            }
        }

        public void Update()
        {
            {
                Console.Write("Name : ");
                string name = Console.ReadLine();
                Branch branch  = data.Datas.Find(u => u.Name.ToLower().Trim() == name.ToLower().Trim());
                Console.Write("New Salary : ");
                branch.Budget = decimal.Parse(Console.ReadLine());
                branch.Address = Console.ReadLine();
            }
        }
    }

}
