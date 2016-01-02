using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webServer.Models.Repository;
using webServer.Models;

namespace webServer.Tests.Model
{
    class InMemoryCustomersRepository : ICustomersRepository
    {
        private List<Customers> db = new List<Customers>();

        public Exception ExceptionToThrow { get; set; }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return db.ToList();
        }

        public Customers GetCustomersByID(int id)
        {
            return db.FirstOrDefault(c => c.id == id);
        }

        public void CreateCustomer(Customers customer)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            db.Add(customer);
        }

        public void SaveChanges(Customers customersToUpdate)
        {
            foreach (Customers customers in db)
            {
                if (customers.id == customersToUpdate.id)
                {
                    db.Remove(customers);
                    db.Add(customersToUpdate);
                    break;
 
                }
                
            }
        }

        public void Add(Customers customersToAdd)
        {
            db.Add(customersToAdd);
        }
        public int SaveChanges()
        {
            return 1;
        }

        public void DeleteCustomers(int id)
        {
            db.Remove(GetCustomersByID(id));
        }




    


    }
}
