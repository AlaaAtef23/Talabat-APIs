﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpecs
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        // this constructor wii ba used for creating an object that will be used to get all Products
        public ProductWithBrandAndCategorySpecifications()
            : base()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
        
        // this constructor wii ba used for creating an object that will be used to get specific product with id
        public ProductWithBrandAndCategorySpecifications(int id)
            : base(P=>P.Id==id)
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
