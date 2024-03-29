﻿using CategoryAndItemAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryAndItemAPI.BLL.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);


    }
}
