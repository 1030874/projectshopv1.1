using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webServer.Models.Repository;
using webServer.Models;
using webServer.Models.Interface;

namespace webServer.Tests.Model
{
    class InMemoryProductsRepository : IProductsRepository
    {
        private List<Products> db = new List<Products>();

        public Exception ExceptionToThrow { get; set; }

        public IEnumerable<Products> GetAllProducts()
        {
            return db.ToList();
        }

        public Products GetProductsByID(int id)
        {
            return db.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<Products> Search(string name)
        {

            return db.Select(x => x).AsEnumerable().Where(x => x.productName.Contains(name));
         
        }

        public void CreateProducts(Products products)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            db.Add(products);
        }

        public void SaveChanges(Products productsToUpdate)
        {
            foreach (Products products in db)
            {
                if (products.id == productsToUpdate.id)
                {
                    db.Remove(products);
                    db.Add(productsToUpdate);
                    break;

                }

            }
        }

        public void Add(Products productsToAdd)
        {
            db.Add(productsToAdd);
        }
        public int SaveChanges()
        {
            return 1;
        }

        public void DeleteProducts(int id)
        {
            db.Remove(GetProductsByID(id));
        }


    }
}
