﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    internal static class SpecificationsEvaluator<TEntity> where TEntity: BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecifications<TEntity> spec) 
        {
            var query = inputQuery; // _dbContext.set<Product>();

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);
            //query = _dbContext.set<Product>().Where(P=> P.id == 1);
            //Includes
            //P => P.Brand
            //P => P.Category

            query = spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            //query = _dbContext.set<Product>().Where(P=> P.id == 1).Include(P => P.Brand);
            //query = _dbContext.set<Product>().Where(P=> P.id == 1).Include(P => P.Brand).Include(P => P.Category);

            return query;
        
        }
    }
}
