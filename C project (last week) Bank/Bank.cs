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
            BranchService branchService = new BranchService();

            Console.WriteLine(                     " Welcome The CA Bank");
             

            Branch branch = new Branch();
            Employee employee = new Employee();
            Manager manager = new Manager();



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
                                        branchService.Create(branch);
                                        goto Menu;
                                        break;
                                     case 2:
                                        //branchService.Delete(branch);
                                        goto Menu;
                                        break;

                                    case 3:
                                        //branchService.Update(branch);
                                        goto Menu;
                                        break;
                                    case 4:
                                        //branchService.TransferMoney();
                                        goto Menu;
                                        break;
                                    case 5:
                                        //branchService.Get(branch);
                                        goto Menu;
                                        break;
                                    case 6:
                                        //branchService.TransferEmployee();
                                        goto Menu;
                                        break;

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
                                employeeService.Create(employee);
                                goto Menu;
                                break;
                            case 2:
                                // employeeService.Delete();
                                goto Menu;
                                break;
                            case 3:
                               // employeeService.Update();
                                goto Menu;
                                break;
                            case 4:
                                //employeeService.Get();
                                goto Menu;
                                break;
                            case 5:
                               // employeeService.GetAll();
                                goto Menu;
                                break;
                        }
                        break;
                }

            }
            else
            {
                Console.WriteLine("Incorrect Login and Password");
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
            Console.WriteLine("2 : Delete Branch");
            Console.WriteLine("3 : Update Branch");
            Console.WriteLine("4 : Get    Branch");
            Console.WriteLine("5 : GetAll Branch");
            Console.WriteLine("6 : Get    Profit");
            Console.WriteLine("7 : Hire  Employee");
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
    
