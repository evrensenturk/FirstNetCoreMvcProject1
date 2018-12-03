using FirstNetCoreMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCoreMvcProject.Repositories
{
   public interface IProductDal
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> SearchProduct(string filter);
        void AddProduct(Product p);
    }
}
