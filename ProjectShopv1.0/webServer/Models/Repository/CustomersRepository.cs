using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webServer.Models.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private DatabaseConnection db = new DatabaseConnection();

        public IEnumerable<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customers GetCustomersByID(int id)
        {
            return db.Customers.FirstOrDefault(c => c.id == id);
        }

        public void CreateCustomer(Customers customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void DeleteCustomers(int id)
        {
            var deleteCustomer = GetCustomersByID(id);
            db.Customers.Remove(deleteCustomer);
            db.SaveChanges();
        }



    }
}