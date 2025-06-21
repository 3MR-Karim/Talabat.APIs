using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification
{
    public interface ISpecification<T> where T : BaseEntity
    {

        public Expression<Func<T, bool>> Criteria { get; set; } // P => P.Id = 1 
        // preopty load funct send for where OK   
        public List<Expression<Func<T,object>>> Includes { get; set; }
        // return more things dont set one ok object for  beucae for point for navgiaton protye
        // i dontt know what return BRO

    }
}
