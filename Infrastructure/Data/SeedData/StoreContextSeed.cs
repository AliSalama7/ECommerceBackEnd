using Core.Models;
using System.Text.Json;

namespace Infrastructure.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.productBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);    
                context.productBrands.AddRange(brands);
            }
            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }
            if (!context.productBrands.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }
            if(context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
    }
}
