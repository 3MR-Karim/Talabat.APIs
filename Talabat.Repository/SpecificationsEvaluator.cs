using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Repository
{

    internal static class SpecificationsEvaluator<IEntity> where IEntity : BaseEntity
    {
        public static IQueryable<IEntity> GetQuery(IQueryable<IEntity> inputQuery, ISpecification<IEntity> spec)
        {
            var query = inputQuery; //Dbcontent.setEntity =>Dbcontent.set<Product>

            if (spec.Criteria != null) // P =>P.ID == 1
            {
                query = query.Where(spec.Criteria); 
            }
            
            // Finsih resuele query = _Dbcontetn.set<TEntitty>().Where(E=>E.id==1)
            // includeExpression 
            // P=>P.Brand
            // P => P.Category



           query=   spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            // Quey =>_dbContext.Set<Product>().Where( P => P.Id == 1).Include(P => P.Brand)
            // Quey =>_dbContext.Set<Product>().Where( P => P.Id == 1).Include(P => P.Brand).Include(P=>P.Category)
            return query;

        }

    }
}
