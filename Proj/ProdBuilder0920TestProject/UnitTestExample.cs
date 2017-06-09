using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdBuilder0920.web.Controllers;

namespace ProdBuilder0920TestProject
{
    [TestClass]
    public class UnitTestExample
    {
        [TestMethod]
        public void TestMethod()
        {
            //Arrange
            HomeController controlerUnderTest = new HomeController();

            //Act
            ViewResult result = controlerUnderTest.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
