using C_project__last_week__Bank.Data;
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
        private Bank<Employee> data;
        public EmployeeService()
        {
            data = new Bank<Employee>();
        }
        public void Create(Employee partner)
        {
            if(partner.SoftDelete == false)
            {
                data.Datas.Add(partner);
            }
            else
            {
                Console.WriteLine(" This Employee is avaialable .");
            }
        }

        public void Delete(string name)
        {
            try
            {
                Employee employee = data.Datas.Find(x=>x.Name.Contains(name.ToLower().Trim()) || x.Surname.Contains(name.ToLower().Trim()));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Employee was not found");
            }
        }

        public void Get(string basentity)
        {
            Employee employee = data.Datas.Find(l=>l.Name.Contains(basentity.ToLower().Trim()) || l.Surname.Contains(basentity.ToLower().Trim()) || l.Profession.Contains(basentity.ToLower().Trim()));
            Console.WriteLine(employee.Name + " " + employee.Surname + " " + employee.Profession);
        }

        public void GetAll()
        {
            foreach (var employee in data.Datas.Where(n => n.SoftDelete = false))
            {
                Console.WriteLine(employee.Name + " " + employee.Surname);
            }
        }

        public void Update(string Text, decimal Number, string Text1)
        {
            Employee employee = data.Datas.Find(u=>u.Name.ToLower().Trim() == Text.ToLower().Trim());
            employee.Salary = Number;
            employee.Profession = Text1;
        }
    }
}
