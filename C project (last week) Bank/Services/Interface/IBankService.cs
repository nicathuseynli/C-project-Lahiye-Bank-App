﻿using C_project__last_week__Bank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_project__last_week__Bank.Services.Interface
{
    public interface IBankService<T>where T : BaseEntity

    {
        void Create(T entity );
        void Update(string Text,decimal Number,string Text1 );
        void Delete( string name);
        void Get(string basentity);
        void GetAll();

    }
}