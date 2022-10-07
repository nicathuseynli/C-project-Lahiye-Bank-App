﻿using C_project__last_week__Bank.Data;
using C_project__last_week__Bank.Models;
using C_project__last_week__Bank.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_project__last_week__Bank.Services.Implementations
{
    public class EmployeeService : IEmployeeService, IBankService<Employee>
    {
        public Bank<Employee> data1;
        public EmployeeService()
        {
            data1 = new Bank<Employee>();
        }
        public void Create()
        {
            Employee partner = new Employee();            
            Console.Clear();
            Console.WriteLine("Create Employee");
            Console.WriteLine("Please Enter the Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please Enter the Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Please Enter the Salary:");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Profession:");
            string profession = Console.ReadLine();
            partner.Name = name;
            partner.Surname = surname;
            partner.Salary = salary;
            partner.Profession = profession;
            partner.SoftDelete = false;
            data1.Datas.Add(partner);
            //if(partner.SoftDelete == false)
            //{
            //}
            //else
            //{
            //    Console.WriteLine(" This Employee is avaialable .");
            //}
        }

        public void Delete()
        {
            string name = Console.ReadLine();
            try
            {
                Employee employee = data1.Datas.Find(x=>x.Name.Contains(name.ToLower().Trim()) || x.Surname.Contains(name.ToLower().Trim()));
            }
            catch(Exception)
            {
                Console.WriteLine("Employee was not found");
            }
        }

        public void Get()           
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Employee employee = data1.Datas.Find(l=>l.Name.Contains(name.Trim()) || l.Surname.Contains(name.Trim()) || l.Profession.Contains(name.Trim()));
            Console.WriteLine($"Name: {employee.Name}  Surname: {employee.Surname}  Profession: {employee.Profession}  Salary:{employee.Salary}");
        }

        public void GetAll()
        {
            foreach (Employee employee in data1.Datas.Where(n => n.SoftDelete == false))
            {
                Console.WriteLine($" Name: {employee.Name}\n Surname: {employee.Surname}\n Profession: {employee.Profession}\n Salary:{employee.Salary}");
            }
        }

        public void Update()
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Employee employee = data1.Datas.Find(u=>u.Name.ToLower().Trim() == name.ToLower().Trim());
            Console.Write("New Salary : ");
            employee.Salary = decimal.Parse(Console.ReadLine());
            Console.Write("New Profession : ");
            employee.Profession = Console.ReadLine();
        }
    }
}
