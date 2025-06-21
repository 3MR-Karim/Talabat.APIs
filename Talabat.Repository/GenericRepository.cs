using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contracts;
using Talabat.Core.Specification;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        #region This way without Specification
        public GenericRepository(StoreContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
                return (IEnumerable<T>)await _dbContext.Set<Product>().Include(P => P.Brand).Include(P => P.Category).AsNoTracking().ToListAsync();
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

      
        public async Task<T?> GetAsync(int id)
        {
            if (typeof(T) == typeof(Product))
                return await _dbContext.Set<Product>().Where(P => P.Id == id).Include(P => P.Category).FirstOrDefaultAsync() as T;
            return await _dbContext.Set<T>().FindAsync(id);

        }

        #endregion



        #region This Way USE | Specification Design Patteren |
        public async   Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySepciifcations(spec).AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetWithSepcAsync(ISpecification<T> spec)
        {
            return await ApplySepciifcations(spec).FirstOrDefaultAsync();
        }


        private IQueryable<T> ApplySepciifcations(ISpecification<T> spec)
        {
            return SpecificationsEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }

        #endregion
    }
}
