using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.UnitTestsTests;

namespace Reface.AppStarter.UnitTests.Tests
{
    [TestClass()]
    public class TestClassBaseTests : TestClassBase<TestAppModule>
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Assert.AreEqual(1, this.App.Context["VALUE"]);
        }
    }
}