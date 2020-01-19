using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interview;
using Interview.Controllers;
using Moq;
using Interview.Data;

namespace Interview.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            HttpResponseMessage result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
      
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            HttpResponseMessage result = controller.Get("1231");

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();



            Mock<MainApp> mock = new Mock<MainApp>();

         // fill in mock - time limit :)
            // Act
            controller.Post(mock.Object);

            // Assert
        }


        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete("231");

            // Assert
        }
    }
}
