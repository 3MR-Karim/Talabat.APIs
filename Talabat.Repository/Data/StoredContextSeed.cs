using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoredContextSeed
    {
       public async static Task SeedAsync(StoreContext _dbContext)
        {
            if (_dbContext.ProductBrands.Count() == 0 ) // The seed do just one in app you need chakc becuase dont repaate
            {
                // First brand or category then finish category becuase read file json you will understand 

                var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json"); // open file the read and reading content is string  and is look project  you need tell her getout bro remind in html ../
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData); /*this stirng is consider json */
                // Deserlise transform from json for thing need and seralize oppsite 
                if (brands?.Count() > 0)//*abbrevciosn this condint  brands is not null && brands.Count() > 0*/)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name


                    //}).ToList(); IF need dont change i json file
                    foreach (var brand in brands)
                    {
                        _dbContext.Set<ProductBrand>().Add(brand);

                    }
                }
                await _dbContext.SaveChangesAsync(); 
            }

            if (_dbContext.ProductCategories.Count() == 0) // The seed do just one in app you need chakc becuase dont repaate
            {
                // First brand or category then finish category becuase read file json you will understand 

                var categoryData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/category.json"); // open file the read and reading content is string  and is look project  you need tell her getout bro remind in html ../
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoryData); /*this stirng is consider json */
                // Deserlise transform from json for thing need and seralize oppsite 
                if (categories?.Count() > 0)//*abbrevciosn this condint  brands is not null && brands.Count() > 0*/)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name


                    //}).ToList(); IF need dont change i json file
                    foreach (var category in categories)
                    {
                        _dbContext.Set<ProductCategory>().Add(category);

                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            if (_dbContext.Products.Count() == 0) // The seed do just one in app you need chakc becuase dont repaate
            {
                // First brand or category then finish category becuase read file json you will understand 

                var ProductsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json"); // open file the read and reading content is string  and is look project  you need tell her getout bro remind in html ../
                var products = JsonSerializer.Deserialize<List<Product>>(ProductsData); /*this stirng is consider json */
                // Deserlise transform from json for thing need and seralize oppsite 
                if (products?.Count() > 0)//*abbrevciosn this condint  brands is not null && brands.Count() > 0*/)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name


                    //}).ToList(); IF need dont change i json file
                    foreach (var product in products)
                    {
                        _dbContext.Set<Product>().Add(product);

                    }
                }
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
