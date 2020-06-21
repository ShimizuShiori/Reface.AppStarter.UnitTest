using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.UnitTestsTests;
using Reface.AppStarter.UnitTestsTests.Services;
using System;

namespace Reface.AppStarter.UnitTests.Tests
{
    [TestAppModule]
    [TestClass]
    public class TestClassBaseTests : TestClassBase
    {
        public IService Service { get; set; }

        public IServiceHasNoImplementor ServiceHasNoImplementor { get; set; }

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

        [TestMethod]
        public void TestServiceHasNoImplementorIsNull()
        {
            Assert.IsNull(this.ServiceHasNoImplementor);
        }


        protected override void OnComponentContainerDiposed()
        {
            Console.WriteLine($"{nameof(TestClassBaseTests)}.{nameof(OnComponentContainerDiposed)}");
        }
    }
}