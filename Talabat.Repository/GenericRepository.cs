using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.contract;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcontext;

        public GenericRepository(StoreContext dbcontext) //Ask CLR for Creating obj from dbContext
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //if (typeof(T)==typeof(Product)) 
            //    return (IEnumerable<T>) await _dbcontext.Set<Product>().Include(P=>P.Brand).Include(P=>P.Category).ToListAsync();
            return await _dbcontext.Set<T>().ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            //if (typeof(T) == typeof(Product))
            //    return await _dbcontext.Set<Product>().Where(P=>P.Id==id).Include(P => P.Brand).Include(P => P.Category)
            //        .FirstOrDefaultAsync() as T;

            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();

        }

        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec) 
        {
            return SpecificationsEvaluator<T>.GetQuery(_dbcontext.Set<T>(), spec);
        }
    }
}
