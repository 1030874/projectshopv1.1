using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using webServer.Controllers;
using webServer.Models;
using webServer.Models.Repository;
using webServer.Tests.Model;

namespace webServer.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        //CustomersController controller = null;
        // Initialize controller for the later tests.
        private static CustomersController GetCustomersController(ICustomersRepository cusRepository)
        {
            CustomersController cusController = new CustomersController(cusRepository);
            cusController.ControllerContext = new ControllerContext()
            {
                Controller = cusController,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };

            return cusController;
        }

        Customers GetCustomersName(int Id, string fName, string lName, int accId)
        {
            return new Customers
            {
                id = Id,
                firstName = fName,
                lastName = lName,
                accountId = accId


            };
        }

     

        [TestMethod]
        public void GetAllCustomersFromRepository()
        {
            Customers customer1 = GetCustomersName(1, "Rene", "Dahl", 1);

            InMemoryCustomersRepository cusRepository = new InMemoryCustomersRepository();

            cusRepository.Add(customer1);

            var controller = GetCustomersController(cusRepository);

            var result = controller.Index();

            var datamodel = ((ViewResult)result).ViewData.Model as IList<Customers>;

            CollectionAssert.Contains(datamodel.ToList(), customer1);



        }

        [TestMethod]
        public void Details()
        {
            //Check if firstname and last is equal to the user.
            Customers customer1 = GetCustomersName(1, "Rene", "Dahl", 1);
            Customers customer2 = GetCustomersName(1, "Josephine", "Jørgensen", 1);
            Assert.AreEqual("Josephine" + "Jørgensen", customer2.firstName + customer2.lastName);
        }









        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
    }
}
