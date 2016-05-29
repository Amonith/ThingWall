using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ThingWall.Controllers;
using ThingWall.Data.Model;

namespace ThingWall.Tests
{
    [TestClass]
    public class ExampleTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new HomeController();

            var result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestSomethingElse()
        {
            var dbUserModel = new User()
            {
                Nick = ""
            };

            var errors = Helpers.Validate(dbUserModel);
            Assert.AreNotEqual(0, errors.Count);
        }
    }
}
