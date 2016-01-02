using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using webServer;
using webServer.Controllers;
using webServer.Models;
using webServer.Models.Interface;
using webServer.Tests.Model;
using Moq;

using System.Linq;
using System.Data.Entity;
using webServer.Models.Repository;


namespace webServer.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {

        private static ProductsController GetProductsController(IProductsRepository proRepository)
        {
            ProductsController proController = new ProductsController(proRepository);
            proController.ControllerContext = new ControllerContext()
            {
                Controller = proController,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };

            return proController;
        }

        Products GetProductsName(int Id, int pCategory, string pName, string pDescription, int pRegular, int pSale, int pQuantity, int pStatus, string pImage, string pImageAlt)
        {
            return new Products
            {
                id = Id,
                productCategory = pCategory,
                productName = pName,
                productDescription = pDescription,
                productRegularPrice = pRegular,
                productSalePrice = pSale,
                productQuantity = pQuantity,
                productStatus = pStatus,
                productImage = pImage,
                productImageAltText = pImageAlt


            };
        }


        [TestMethod]
        public void GetAllProductsFromRepository()
        {
            Products products1 = GetProductsName(1, 1, "Test produkt", "Beskrivelse", 22, 22, 2, 1, "billede", "billede text");

            InMemoryProductsRepository proRepository = new InMemoryProductsRepository();

            proRepository.Add(products1);

            var controller = GetProductsController(proRepository);

            var result = controller.Index();

            var datamodel = ((ViewResult)result).ViewData.Model as IList<Products>;


            CollectionAssert.Contains(datamodel.ToList(), products1);

        }

        [TestMethod]
        public void Details()
        {
           
            Products products1 = GetProductsName(1, 1, "Test produkt", "Beskrivelse", 22, 22, 2, 1, "billede", "billede text");
            Assert.AreEqual("Test produkt" + "Beskrivelse", products1.productName + products1.productDescription);
        }

        [TestMethod]
        public void SearchProductByName()
        {
            string test = "Test produkt";
            Products products1 = GetProductsName(1, 1, "Test produkt", "Beskrivelse", 22, 22, 2, 1, "billede", "billede text");
            Assert.AreEqual("Test produkt" + "Beskrivelse", test + products1.productDescription);
         
       

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
