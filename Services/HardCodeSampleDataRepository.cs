using Bogus;
using MyFirstWeb.Models;

namespace MyFirstWeb.Services
{
    public class HardCodeSampleDataRepository : IProductService
    {
        static List<ProductModel> productslist = new List<ProductModel>();
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }
        //temp
        public List<ProductModel> GetAllProducts()
        {
            if(productslist.Count == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    productslist.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 1)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                        );
                }
            }
            return productslist;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }
        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
