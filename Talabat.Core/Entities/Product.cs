using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int BrandId { get; set; } //FK column => ProductBrand
        public ProductBrand Brand { get; set; } //navigational prop [ONE]

        public int CategoryId { get; set; } //FK column => ProductCategory

        public ProductCategory Category { get; set; } // navigational prop [ONE]
    }
}
