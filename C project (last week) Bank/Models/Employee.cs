using System;
using System.Collections.Generic;
using System.Text;

namespace C_project__last_week__Bank.Models
{
    public class Employee:BaseEntity
    {
        public Branch Branch { get; set; }
        public string Surname { get; set; }
        public string  Profession { get; set; }
        public decimal Salary { get; set; }
        public Employee (string name,string surname,decimal salary,string profession,bool softdelete)
        {
            Name = name;
            Surname = surname;
            Profession = profession;
            Salary = salary;
            SoftDelete = softdelete;

        }
    
    }
}
