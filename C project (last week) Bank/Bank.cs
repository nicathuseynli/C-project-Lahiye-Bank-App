using C_project__last_week__Bank.Models;
using C_project__last_week__Bank.Services.Implementations;
using System;

namespace C_project__last_week__Bank
{
    public class Bank
    {
        static void Main(string[] args)
        {
            EmployeeService employeeService = new EmployeeService();
            BranchService branchService = new BranchService(employeeService);

            Console.WriteLine(                     " Welcome The CA Bank");
             

            Branch branch = new Branch();
            Employee employee = new Employee();
            Manager manager = new Manager();


            while (true)
            {

            Console.Write("Login: ");
            string login=Console.ReadLine();
            Console.Write("Password: ");
            string password=Console.ReadLine();
            manager.Username = "Nijat";
            manager.Password = "12345A";
           Menu : if (manager.Username==login&&password==manager.Password)
            {
                Console.WriteLine("Welcome to Manager Operations Menu");
                Console.WriteLine("If you want to Branch operations please click the 1");
                Console.WriteLine("If you want to Employee operations please click the 2");
                int command = int.Parse(Console.ReadLine());
                switch (command)
                { 
                    case 1:
                        Console.Clear();
                        ManagerMenu();
                        int commandmenu = int.Parse(Console.ReadLine());
                        switch (commandmenu)
                        {
                            case 1:
                                Console.Clear();
                                BranchMenu();
                                int branchmenu=int.Parse(Console.ReadLine());
                                switch (branchmenu)
                                {
                                    case 1:
                                            //isleyir
                                        branchService.Create();
                                        goto Menu;
                                     case 2:
                                            //isleyir
                                        branchService.TransferMoney();
                                        goto Menu;
                                    case 3:
                                            //isleyir
                                        branchService.Get();
                                        goto Menu;
                                    case 4:
                                            //isleyir
                                        branchService.GetAll();
                                        goto Menu;                                       
                                    case 5:
                                            //isleyir
                                        branchService.Delete();
                                        goto Menu;

                                    case 6:
                                            //isleyir
                                        branchService.Update();
                                        goto Menu;
                                    case 7:
                                            // isleyir
                                       branchService.GetProfit();
                                        goto Menu;
                                    case 8:
                                            //isleyir
                                      Console.WriteLine("Branch name: ");
                                      string brname=Console.ReadLine();
                                      Console.WriteLine("Employee name: ");
                                      string empname=Console.ReadLine();
                                      branchService.HireEmployee(brname, empname);
                                      goto Menu;
                                    case 9:
                                            //isleyir
                                      Console.Write("Enter the old branchName : ");
                                      string tname=Console.ReadLine();
                                      branchService.TransferEmployee(tname ,branch);
                                      goto Menu;
                                }
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        EmployeeMenu();
                        int empmenu=int.Parse(Console.ReadLine());
                        switch (empmenu)
                        {
                            case 1:
                                employeeService.Create();
                                goto Menu;
                            case 2:
                                 employeeService.Delete();
                                    Console.WriteLine(" Employee successfully deleted ");
                                goto Menu;
                            case 3:
                                employeeService.Update();
                                goto Menu;
                            case 4:
                               employeeService.Get();
                                Console.WriteLine(employee.Name + " " + employee.Surname + " " + employee.Profession);
                                goto Menu;
                            case 5:
                               employeeService.GetAll();
                                goto Menu;
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect Login and Password");
            }
            
            }
        }
        //public static void Data()
        //{
        //    string Name = Console.ReadLine();
        //    string Surname = Console.ReadLine();
        //    decimal Salary = decimal.Parse(Console.ReadLine());
        //    string Profession = Console.ReadLine();
        //}
        public static void ManagerMenu()
        {
            Console.WriteLine("1 : Branch");
            Console.WriteLine("2 : Employee");
        }
        public static void BranchMenu()
        {
            Console.WriteLine("1 : Create Branch");
            Console.WriteLine("2 : Transfer Money");
            Console.WriteLine("3 : Get");
            Console.WriteLine("4 : GetAll");
            Console.WriteLine("5 : Delete Branch");
            Console.WriteLine("6 : Update Branch");
            Console.WriteLine("7 : Get    Profit");
            Console.WriteLine("8 : Hire  Employee");
            Console.WriteLine("9 : Transfer Employee");
        }
        public static void EmployeeMenu()
        {
            Console.WriteLine("1 : Create Employee");
            Console.WriteLine("2 : Delete Employee");
            Console.WriteLine("3 : Update Employee");
            Console.WriteLine("4 : Get    Employee");
            Console.WriteLine("5 : GetAll Employee");
        }
           
    }
}
    
