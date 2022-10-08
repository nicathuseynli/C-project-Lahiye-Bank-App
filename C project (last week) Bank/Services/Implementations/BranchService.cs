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
        private EmployeeService employeeService;
        private Bank<Branch> data;
        public BranchService(EmployeeService data1 )
        {
            employeeService = data1;
            data = new Bank<Branch>();
        }
        public void Create()
        {
            Branch partner = new Branch();            
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
            partner.SoftDelete = false;
            data.Datas.Add(partner);

        }
        public void Delete()
        {
            Console.Write("Please enter the name which you want delete : ");
            string name=Console.ReadLine();
            try
            {
            Branch branch = data.Datas.Find(x => x.Name.Contains(name.ToLower().Trim()));
            branch.SoftDelete = true;
            Console.WriteLine("Employee deleted successfully ");    
            }
            catch (Exception)
            {

                Console.WriteLine("Bracnh was deleted"); ;
            }
        }
        public void Get()
        {
              string name = Console.ReadLine();
            try
            {
                Branch branch = data.Datas.Find(l => l.Name.Contains(name.Trim()) || l.Budget.ToString().Contains(name.Trim()) || l.Address.Contains(name.Trim()));
                Console.WriteLine(branch.Name + " " + branch.Budget + " " + branch.Address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAll()
        {
            foreach (var branch in data.Datas.Where(m => m.SoftDelete == false))
            {
                Console.WriteLine($"Name : { branch.Name}\nAddress : {branch.Address}\nBudget : { branch.Budget}\n");
            } ;
        }
        public void GetProfit()
        {
            try
            {
                Console.WriteLine("Please enter the branch Name : ");
            string branchName = Console.ReadLine();
            Branch branch = data.Datas.Find(x => x.Name == branchName);
            decimal sum = 0;
            foreach (var employee in employeeService.data1.Datas)
            {
                sum += employee.Salary;
            }
            decimal profit = branch.Budget - sum;
            Console.WriteLine(profit);        
            }
            catch (Exception)
            {
                Console.WriteLine("Branch has not enough money");
            }
        }
        public void HireEmployee(string branchName,string employeeName)
        {
            try
            {
            Branch branch = data.Datas.Where(x => x.Name == branchName).FirstOrDefault();
            Employee employee=employeeService.data1.Datas.Where(n => n.Name == employeeName).FirstOrDefault();
            branch.employees.Add(employee);
            foreach (var item in branch.employees)
            {
                Console.WriteLine();
            }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void TransferEmployee(string employeeName,Branch branch)
        {
            
            Console.Write("Please Enter the Employee's name : ");
            string ename = Console.ReadLine();
            //Console.WriteLine(         "Please Enter the Branch Name : ");
            //string bname = Console.ReadLine();
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
                break;
            }
            
            
            
            
        }

        public void TransferMoney()
        { 
            Console.Write("Please Enter YourBranch Name:");
            string mainame=Console.ReadLine();
            Console.Write("Please Enter OwnerBranch Name :");
            string name =Console.ReadLine();
            Console.Write("Select Amount :");
            int amount = Convert.ToInt32(Console.ReadLine());
            Branch branch = new Branch();  
            foreach(Branch Transfer in data.Datas)
            {
                if (Transfer.Name == mainame)
                {
                    Transfer.Budget -= amount;

                }               
            }
            foreach(Branch Transfer in data.Datas)
            {
                if(Transfer.Name == name)
                {
                    Transfer.Budget += amount ;
                    break;
                }
            }
        }
        public void Update()
        {
            {
                Console.Write("Branch name : ");
                string name = Console.ReadLine();
                Branch branch  = data.Datas.Find(u => u.Name.ToLower().Trim() == name.ToLower().Trim());
                Console.Write("New Budget : ");
                branch.Budget = decimal.Parse(Console.ReadLine());
                Console.Write("New address : ");
                branch.Address = Console.ReadLine();
                Console.Write("Branch's datas are refreshed successfully");
            }
        }
    }
}
