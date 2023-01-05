---
title: Use dependency injection
description: Learn how to use dependency injection in your .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 01/05/2023
ms.topic: tutorial
no-loc: [Transient, Scoped, Singleton, Example]
---

# Tutorial: Use dependency injection in .NET

This tutorial shows how to use [dependency injection (DI) in .NET](dependency-injection.md). With *Microsoft Extensions*, DI is managed by adding services and configuring them in an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. The <xref:Microsoft.Extensions.Hosting.IHost> interface exposes the <xref:System.IServiceProvider> instance, which acts as a container of all the registered services.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create a .NET console app that uses dependency injection
> - Build and configure a [Generic Host](generic-host.md)
> - Write several interfaces and corresponding implementations
> - Use service lifetime and scoping for DI

## Prerequisites

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or later.
- Familiarity with creating new .NET applications and installing NuGet packages.

## Create a new console application

Using either the [dotnet new](../tools/dotnet-new.md) command or an IDE new project wizard, create a new .NET console application named **ConsoleDI.Example**. Add the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package to the project.

Your new console app project file should resemble the following:

:::code language="xml" source="snippets/configuration/console-di/console-di.csproj":::

> [!IMPORTANT]
> In this example, the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package is required to build and run the app. Some metapackages might contain the `Microsoft.Extensions.Hosting` package, in those scenarios and explicit package reference isn't required.

## Add interfaces

In this sample app, you'll learn how dependency injection handles service lifetime. You'll create several interfaces that represent different service lifetimes. Add the following interfaces to the project root directory:

*IReportServiceLifetime.cs*

:::code source="snippets/configuration/console-di/IReportServiceLifetime.cs":::

The `IReportServiceLifetime` interface defines:

- A `Guid Id` property that represents the unique identifier of the service.
- The <xref:Microsoft.Extensions.DependencyInjection.ServiceLifetime> property that represents the service lifetime.

*IExampleTransientService.cs*

:::code source="snippets/configuration/console-di/IExampleTransientService.cs":::

*IExampleScopedService.cs*

:::code source="snippets/configuration/console-di/IExampleScopedService.cs":::

*IExampleSingletonService.cs*

:::code source="snippets/configuration/console-di/IExampleSingletonService.cs":::

All of the subinterfaces of `IReportServiceLifetime` explicitly implement the `IReportServiceLifetime.Lifetime` with a default. For example, `IExampleTransientService` explicitly implements `IReportServiceLifetime.Lifetime` with the `ServiceLifetime.Transient` value.

## Add default implementations

The example implementations all initialize their `Id` property with the result of <xref:System.Guid.NewGuid?displayProperty=nameWithType>. Add the following default implementation classes for the various services to the project root directory:

*ExampleTransientService.cs*

:::code source="snippets/configuration/console-di/ExampleTransientService.cs":::

*ExampleScopedService.cs*

:::code source="snippets/configuration/console-di/ExampleScopedService.cs":::

*ExampleSingletonService.cs*

:::code source="snippets/configuration/console-di/ExampleSingletonService.cs":::

Each implementation is defined as `internal sealed` and implements its corresponding interface. For example, `ExampleSingletonService` implements `IExampleSingletonService`.

## Add a service that requires DI

Add the following service lifetime reporter class, which acts as a service to the console app:

*ServiceLifetimeReporter.cs*

:::code source="snippets/configuration/console-di/ServiceLifetimeReporter.cs":::

The `ServiceLifetimeReporter` defines a constructor that requires each of the aforementioned marker interfaces, that is, `IExampleTransientService`, `IExampleScopedService`, and `IExampleSingletonService`. The object exposes a single method that allows the consumer to report on the service with a given `lifetimeDetails` parameter. When invoked, the `ReportServiceLifetimeDetails` method logs each service's unique identifier with the service lifetime message.

## Register services for DI

Update *Program.cs* with the following code:

:::code source="snippets/configuration/console-di/Program.cs" id="Program" highlight="8-11":::

Each `services.Add{LIFETIME}<{SERVICE}>` extension method adds (and potentially configures) services. We recommend that apps follow this convention. Place extension methods in the <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> namespace to encapsulate groups of service registrations. Including the namespace portion `Microsoft.Extensions.DependencyInjection` for DI extension methods also:

- Allows them to be displayed in [IntelliSense](/visualstudio/ide/using-intellisense) without adding additional `using` blocks.
- Prevents excessive `using` statements in the `Program` or `Startup` classes where these extension methods are typically called.

The app:

- Creates an <xref:Microsoft.Extensions.Hosting.IHostBuilder> instance with the [default binder settings](generic-host.md#default-builder-settings).
- Configures services and adds them with their corresponding service lifetime.
- Calls <xref:Microsoft.Extensions.Hosting.IHostBuilder.Build> and assigns an instance of <xref:Microsoft.Extensions.Hosting.IHost>.
- Calls `ExemplifyScoping`, passing in the <xref:Microsoft.Extensions.Hosting.IHost.Services?displayProperty=nameWithType>.

## Conclusion

In this sample app, you created several interfaces and corresponding implementations. Each of these services is uniquely identified and paired with a <xref:Microsoft.Extensions.DependencyInjection.ServiceLifetime>. The sample app demonstrates registering service implementations against an interface, and how to register pure classes without backing interfaces. The sample app then demonstrates how dependencies defined as constructor parameters are resolved during runtime.

When the app is ran, it will display output similar to the following:

:::code source="snippets/configuration/console-di/Program.cs" id="Output":::

From the app output, you can see that:

- Transient services are always different, a new instance is created with every retrieval of the service.
- Scoped services change only with a new scope, but are the same instance within a scope.
- Singleton services are always the same, a new instance is only created once.

## See also

* [Dependency injection guidelines](dependency-injection-guidelines.md)
* [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection)
