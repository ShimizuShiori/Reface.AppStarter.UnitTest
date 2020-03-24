using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.AppContainers;
using Reface.AppStarter.AppModules;

namespace Reface.AppStarter.UnitTests
{
    /// <summary>
    /// 测试类基础类
    /// </summary>
    /// <typeparam name="TAppModule">启动的 AppModule 泛型</typeparam>
    public abstract class TestClassBase<TAppModule> where TAppModule : IAppModule, new()
    {
        /// <summary>
        /// 组件容器
        /// </summary>
        public IComponentContainer ComponentContainer { get; private set; }

        /// <summary>
        /// 应用实例
        /// </summary>
        public App App { get; private set; }

        [TestInitialize]
        public void Init()
        {
            IAppModule appModule = new TAppModule();
            AppSetup setup = new AppSetup();
            this.App = setup.Start(appModule);
            IComponentContainer componentContainer = this.App.GetAppContainer<IComponentContainer>();
            ComponentContainer = componentContainer.BeginScope("TEST");
        }

        [TestCleanup]
        public void Cleanup()
        {
            ComponentContainer.Dispose();
        }
    }
}
