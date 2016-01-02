using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webServer.Models.Interface;

namespace webServer.Models.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private DatabaseConnection db = new DatabaseConnection();
        


        public IEnumerable<Products> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Products GetProductsByID(int id)
        {
            return db.Products.FirstOrDefault(p => p.id == id);
        }


        public IEnumerable <Products> Search(string name)
        {
    

            var s =  db.Products.Select(x => x).AsEnumerable().Where(x => x.productName.Contains(name));

            return s;

        }
          

        public void CreateProducts(Products products)
        {
            db.Products.Add(products);
            db.SaveChanges();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void DeleteProducts(int id)
        {
            var deleteProduct = GetProductsByID(id);
            db.Products.Remove(deleteProduct);
            db.SaveChanges();
        }
    }
}