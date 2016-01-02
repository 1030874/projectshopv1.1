using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webServer.Models.Repository
{
    public interface ICustomersRepository
    {
        IEnumerable<Customers> GetAllCustomers();
        void CreateCustomer(Customers customer);
        void DeleteCustomers(int id);
        Customers GetCustomersByID(int id);
        int SaveChanges();
    }
}
