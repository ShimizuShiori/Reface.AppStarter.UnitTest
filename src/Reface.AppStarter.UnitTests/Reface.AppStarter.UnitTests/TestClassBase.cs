using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.AppContainers;
using Reface.AppStarter.AppModules;
using Reface.AppStarter.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reface.AppStarter.UnitTests
{
    /// <summary>
    /// 测试类基础类
    /// </summary>
    /// <typeparam name="TAppModule">启动的 AppModule 泛型</typeparam>
    public abstract class TestClassBase
    {
        protected virtual IAppModule GetAppModule()
        {
            IEnumerable<AppModule> modules = this.GetType().GetCustomAttributes<AppModule>();
            if (modules.Count() == 1)
                return modules.First();
            else
                return null;
        }

        /// <summary>
        /// 组件容器
        /// </summary>
        public IComponentContainer ComponentContainer { get; private set; }

        protected void Start(IAppModule appModule)
        {
            AppSetup setup = new AppSetup();
            this.App = setup.Start(appModule);
            IComponentContainer componentContainer = this.App.GetAppContainer<IComponentContainer>();
            ComponentContainer = componentContainer.BeginScope("TEST");
            foreach (var prop in this.GetType().GetProperties())
            {
                var attr = prop.GetCustomAttribute<AutoCreateAttribute>();
                if (attr == null) continue;

                prop.SetValue(this, this.ComponentContainer.CreateComponent(prop.PropertyType));
            }
            this.OnAppStarted();
        }

        protected virtual void OnAppStarted()
        {

        }

        /// <summary>
        /// 应用实例
        /// </summary>
        public App App { get; private set; }

        [TestInitialize]
        public void Init()
        {
            IAppModule appModule = this.GetAppModule();
            if (appModule == null) return;
            this.Start(appModule);
        }

        [TestCleanup]
        public void Cleanup()
        {
            ComponentContainer.Dispose();
        }
    }


    public abstract class TestClassBase<TAppModule> : TestClassBase
        where TAppModule : IAppModule, new()
    {
        protected override IAppModule GetAppModule()
        {
            return new TAppModule();
        }
    }
}
