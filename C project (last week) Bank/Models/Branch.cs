using System;
using System.Collections.Generic;
using System.Text;

namespace C_project__last_week__Bank.Models
{
    public class Branch:BaseEntity
    {
        public string Address { get; set; }
        public decimal Budget { get; set; }
        public List<Employee> employees = new List<Employee>();
        
    }
}
