using C_project__last_week__Bank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_project__last_week__Bank.Data
{
    public class Bank<T>
    {
        public List<T> Datas = new List<T>();
        public Bank()
        {
            Datas = new List<T>();
        }
    }
}
