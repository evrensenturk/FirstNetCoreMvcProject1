using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCoreMvcProject.Models;
using Microsoft.Extensions.Configuration;

namespace FirstNetCoreMvcProject.Repositories
{
    public class EfProductDal : IProductDal
    {
       // static string connection = @"Data Source=(local);Initial Catalog=NetMvcProject;User=sa;Password=sa123;";


        CoreMvcDbContext dbContext = new CoreMvcDbContext();
        public void AddProduct(Product p)
        {
            dbContext.Add(p);
            dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.ToList<Product>();
        }

        public IEnumerable<Product> SearchProduct(string filter)
        {

            foreach (var item in dbContext.Products)
            {
                if (item.ProductBrand.Contains(filter)||item.ProductName.Contains(filter))
                {
                    yield return item;
                }
            }
              //return dbContext.Products.ToList<Product>();
        }
    }
}
