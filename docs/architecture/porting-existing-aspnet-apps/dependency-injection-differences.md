---
title: Dependency injection differences between ASP.NET MVC and ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# Dependency injection differences between ASP.NET MVC and ASP.NET Core

Although dependency injection isn't built into ASP.NET MVC or Web API, many apps enable it by adding a NuGet package with an inversion of control (IOC) container. These are sometimes referred to as DI containers, for dependency injection (or inversion). Some of the most popular containers used in ASP.NET MVC apps include:

- [Autofac](https://www.autofac.org/)
- [Unity](https://unitycontainer.github.io/)
- [Ninject](http://www.ninject.org/)
- [StructureMap](http://structuremap.github.io/) *(deprecated)*
- [Castle Windsor](http://www.castleproject.org/projects/windsor/)

If your ASP.NET MVC application isn't using dependency injection, you will probably want to investigate the built-in support for DI in ASP.NET Core. Dependency injection helps keep modules in your app loosely coupled from one another, and enables better testability and adherence to principles like [SOLID](https://www.weeklydevtips.com/episodes/047).

If your app does use dependency injection, then probably your best course of action is to see if the container you're using supports ASP.NET Core. If so, you may be able to continue using it and your custom configuration rules describing your type mappings and lifetimes.

Either way, you should consider using the built-in support for dependency injection that ships with ASP.NET Core, as it may meet your app's needs.

## Dependency injection in ASP.NET Core

ASP.NET Core assumes apps will use dependency injection. It's not just built into the framework, but is required in order to bring support for framework features into your ASP.NET Core apps. In application startup, a call is made to `ConfigureServices` which is responsible for registering all of the types that the DI container (service collection/service provider) can create and inject in the app. Built-in ASP.NET Core features like Entity Framework Core, Identity, and even MVC are brought into the app by configuring them as services in the `ConfigureServices` method.

In addition to using the default implementation, apps can still use custom containers. The [documentation covers how to replace the default service container](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1#default-service-container-replacement).

Dependency injection is fundamental to ASP.NET Core. If your team is not already well-versed in this practice, you'll want to be sure you have a firm understanding of it before you port your app.

## References

- [Dependency Injection in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection)

>[!div class="step-by-step"]
>[Previous](serving-static-files.md)
>[Next](middleware-modules-handlers.md)
