using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public decimal Price { get; set; }

        //[ForeignKey(nameof(Product.Brand))]
        public int ProductBrand {  get; set; }
        public ProductBrand Brand { get; set; }

        public int ProductCategoryId { get; set; }
        public int BrandId { get; set; }
        public ProductCategory Category { get; set; }
    
    }
}
