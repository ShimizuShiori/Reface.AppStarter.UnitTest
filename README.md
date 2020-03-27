# Reface.AppStarter.UnitTest

## 简介

基于 *Reface.AppStarter* 的单元测试。

使用 *Reface.AppStarter* 启动程序总是需要启过下面这些步骤

1. 创建启动 *AppModule* 的实例
2. 创建 *AppSetup** 的实例
3. 通过 *AppSetup.Start(IAppModule)* 方法启动程序并得到 *App* 实例
4. 通过 *App.GetAppContainer&lt;IComponentContainer>()* 方法获取组件容器
5. 通过 *IComponentContainer* 创建组件并运行。

在每一次的单元测试中都要编写这些代码肯定是一件糟糕的事情。
因此，开发者可以通过引用 *Reface.AppStarter.UnitTest* 来简化这些工作。

*Reface.AppStarter.UnitTest* 其实只是提供了一个封装了 *TestInitialize* 和 *TestCleanup* 的基础类，开发者可以通过继承此类来减少上述的步骤。

## 依赖项

* Reface.AppStarter >= 1.2.0-beta.1
* MSTest.TestAdapter >= 1.3.2
* MSTest.TestFramework >= 1.3.2

## 用法

不同于其它的 *AppModule* ,
使用此 *Library* 不需要依赖 *AppModule* ,
你所要用做的，只是将你的单元测试类，继承于 *ClassTestBase&lt;TAppModule>* 。
其中的是 *TAppModule* 就是你单元测试项目的 *AppModule* 。

## Nuget 地址

https://www.nuget.org/packages/Reface.AppStarter.UnitTests