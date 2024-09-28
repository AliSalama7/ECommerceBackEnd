using Core.Models;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : Specification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) 
            : base
            (p => (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search))
            && (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId)
            && (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
        {
            
        }
    }
}
