using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.UnitTestsTests;
using Reface.AppStarter.UnitTestsTests.Services;

namespace Reface.AppStarter.UnitTests.Tests
{
    [TestAppModule]
    [TestClass]
    public class TestClassBaseTests : TestClassBase
    {
        [AutoCreate]
        public IService Service { get; set; }

        [TestMethod]
        public void MyTestMethod()
        {
            Assert.AreEqual(1, this.App.Context["VALUE"]);
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            Assert.AreEqual(1, this.App.Context["VALUE"]);
        }

        [TestMethod]
        public void ServiceIsDefaultService()
        {
            Assert.IsInstanceOfType(this.Service, typeof(DefaultService));
        }
    }
}