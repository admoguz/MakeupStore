using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ProductsFilterSpecification : Specification<Product>
    {
        public ProductsFilterSpecification(int? branId, int? categoryId)
        {
            if (branId.HasValue)
                Query.Where(x => x.BrandId == branId);

            if (categoryId.HasValue)
                Query.Where(x => x.CategoryId == categoryId);
        }

        public ProductsFilterSpecification(int? branId, int? categoryId, int skip, int take) : this(branId, categoryId)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
