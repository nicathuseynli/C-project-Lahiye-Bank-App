using System;
using System.Collections.Generic;
using System.Text;

namespace C_project__last_week__Bank.Models
{
    public class BaseEntity
    {
        public string Name { get; set; }
        public bool SoftDelete { get; set; }
    }
}
