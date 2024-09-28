using Core.Models;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : Specification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProductSpecParams productParams) :
            base 
            (p => (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) 
            &&(!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId)
            && (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
            AddOrderBy(p => p.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }
        public ProductWithTypesAndBrandsSpecification(int id) : base(p => p.Id == id)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }
    }
}
