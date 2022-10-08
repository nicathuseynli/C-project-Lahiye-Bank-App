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
        public EmployeeService employeeService;
        private Bank<Branch> _data;
        public BranchService(EmployeeService data1 )
        {
            employeeService = data1;
            _data = new Bank<Branch>();
        }
        public void Create()
        {
            Branch partner = new Branch();            
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
            _data.Datas.Add(partner);
        }
        public void Delete()
        {
            Console.Write("Please enter the name which you want delete : ");
            string name=Console.ReadLine();            
            
             Branch branch = _data.Datas.Find(x => x.Name.Contains(name.ToLower().Trim()));
            if (branch.SoftDelete == false)
            {
                branch.SoftDelete = true;
                Console.WriteLine("Branch deleted successfully ");
            }
            else 
            {
             Console.WriteLine("Bracnh was deleted"); ;
            }
        }
        public void Get()
        {
            Console.WriteLine("Please enter the branch name : ");
            string name = Console.ReadLine();           
            Branch branch = _data.Datas.Find(l => l.Name.Contains(name.Trim()) || l.Budget.ToString().Contains(name.Trim()) || l.Address.Contains(name.Trim()));
            Console.WriteLine(branch.Name + " " + branch.Budget + " " + branch.Address);
        }
        public void GetAll()
        {
            foreach (var branch in _data.Datas.Where(m => m.SoftDelete == false))
            {
                Console.WriteLine($"Name : { branch.Name}\nAddress : {branch.Address}\nBudget : { branch.Budget}\n");
            };   
        }
        public void GetProfit()
        {
            Console.WriteLine("Please enter the branch Name : ");
            string branchName = Console.ReadLine();
            if(branchName!=null)
            {
                Branch branch = _data.Datas.Find(x => x.Name == branchName);
                decimal sum = 0;
                foreach (var employee in employeeService._data1.Datas)
                {
                    sum += employee.Salary;
                }
                decimal profit = branch.Budget - sum;
                Console.WriteLine(profit);
            }
            else
            {
                Console.WriteLine("Branch has not enough money");
            }
        }
        public void HireEmployee()
        {
            Console.WriteLine("Branch name: ");
            string branchName = Console.ReadLine();
            Console.WriteLine("Employee name: ");
            string employeeName = Console.ReadLine();
            Branch branch = _data.Datas.Where(x => x.Name == branchName).FirstOrDefault();
            Employee employee=employeeService._data1.Datas.Where(n => n.Name == employeeName).FirstOrDefault();
            branch.employees.Add(employee);
            foreach (var item in branch.employees)
            {
                Console.WriteLine($"{item.Name} hired successfully");
            }       
        }
        public void TransferEmployee()
        {
            Console.WriteLine("From Branch Name: ");
            string branName = Console.ReadLine();
            Console.WriteLine("To Branch Name: ");
            string bran1Name = Console.ReadLine();
            Console.WriteLine("Employee Name: ");
            string EmpName = Console.ReadLine();
            Branch frombranch = _data.Datas.Where(t => t.Name == branName).FirstOrDefault();
            Employee employee = frombranch.employees.Find(t => t.Name.Trim().ToLower() == EmpName.Trim().ToLower());
            Branch tobranch = _data.Datas.Where(t => t.Name == bran1Name).FirstOrDefault();

            if (frombranch.Budget > employee.Salary)
            {
                frombranch.employees.Remove(employee);
                tobranch.employees.Add(employee);
                tobranch.Budget -= employee.Salary;
                Console.WriteLine($"Employee {employee.Name} {employee.Surname} successfully transfer from {tobranch.Address}");
            }
            else
            {
                Console.WriteLine("Employee already in this branch");
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
            foreach(Branch Transfer in _data.Datas) 
            {
                if (Transfer.Name == mainame)
                {
                    Transfer.Budget -= amount;

                }               
            }
            foreach(Branch Transfer in _data.Datas)
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
                Branch branch  = _data.Datas.Find(u => u.Name.Trim() == name.Trim());
                Console.Write("New Budget : ");
                branch.Budget = decimal.Parse(Console.ReadLine());
                Console.Write("New address : ");
                branch.Address = Console.ReadLine();
                Console.WriteLine("Branch's datas are refreshed successfully");
            }
        }
    }
}
