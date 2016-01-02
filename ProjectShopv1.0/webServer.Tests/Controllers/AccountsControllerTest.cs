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
using webServer.Models.Interface;
using webServer.Models.Repository;
using webServer.Tests.Model;

namespace webServer.Tests.Controllers
{
    [TestClass]
    public class AccountsControllerTest
	{

        private static AccountsController GetAccountsController(IAccountsRepository accRepository)
        {
            AccountsController accController = new AccountsController(accRepository);
            accController.ControllerContext = new ControllerContext()
            {
                Controller = accController,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };

            return accController;
 
        }


        Accounts GetAccountsName(int Id, String aName, string aPassword, string aRole)
        {
            return new Accounts
            {
                id = Id,
                accountName = aName,
                accountPassword = aPassword,
                accountRole = aRole
            };
        }


        [TestMethod]
        public void GetAllAccountsFromRepository()
        {
            Accounts accounts1 = GetAccountsName(1, "Rene", "Dahl", "1");

            InMemoryAccountsRepository accRepository = new InMemoryAccountsRepository();

            accRepository.Add(accounts1);

            var controller = GetAccountsController(accRepository);

            var result = controller.Index();

            var datamodel = ((ViewResult)result).ViewData.Model as IList<Accounts>;

            CollectionAssert.Contains(datamodel.ToList(), accounts1);
        }


        [TestMethod]
        public void Details()
        {
            //Check if firstname and last is equal to the user.
            Accounts accounts1 = GetAccountsName(1, "Rene", "Dahl", "1");
            Accounts accounts2 = GetAccountsName(1, "Josephine", "Jørgensen", "1");
            Assert.AreEqual("Rene" + "1", accounts1.accountName + accounts1.accountRole);
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
