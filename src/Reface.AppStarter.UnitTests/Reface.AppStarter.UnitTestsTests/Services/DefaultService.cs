using Reface.AppStarter.Attributes;
using System;

namespace Reface.AppStarter.UnitTestsTests.Services
{
    [Component]
    public class DefaultService : IService
    {
        public void Dispose()
        {
            Console.WriteLine("DefaultService.Disposing");
        }
    }
}
