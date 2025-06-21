using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification
{
    // Bro this object okkkk the send for function 
    public class BaseSpecifications<T> : ISpecification<T> where T : BaseEntity
    {
        // can implelent propty one of two way one fullproety or autmatic propyt 
       // do autmatic becuase not write get or set
        public Expression<Func<T, bool>>? Criteria { get; set ; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = [];

        public BaseSpecifications()
        {
            
        }



        public BaseSpecifications(Expression<Func<T,bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
           
        }
    }
}
