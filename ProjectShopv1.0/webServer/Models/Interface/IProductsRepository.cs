using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webServer.Models.Interface
{
     public interface IProductsRepository
    {
         IEnumerable<Products> GetAllProducts();

         IEnumerable<Products> Search(string name);
         void CreateProducts(Products products);

         void DeleteProducts(int id);
         Products GetProductsByID(int id);

         int SaveChanges();
    }
}
