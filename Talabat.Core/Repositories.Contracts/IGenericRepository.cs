﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Core.Repositories.Contracts
{
    public interface IGenericRepository <T> where T :BaseEntity
    {
         Task<T?> GetAsync(int id );
         Task<IEnumerable<T>> GetAllAsync();



        Task<T?> GetWithSepcAsync(ISpecification<T> spec);
       
            Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);




    }
}
