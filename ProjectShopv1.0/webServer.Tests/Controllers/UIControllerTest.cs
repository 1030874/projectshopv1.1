using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using webServer;
using webServer.Controllers;
using Moq;
using System.Web;
using System.Security.Principal;

namespace webServer.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            UIController controller = new UIController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual("Home Page", result.ViewBag.Title);
  

        
        }
    }
}
