---
title: Dependency injection basics
description: Learn how to use dependency injection (DI) in your .NET apps with this simple example. Follow along with this pragmatic guide to understand DI basics in C#.
author: IEvangelist
ms.author: dapine
ms.date: 07/18/2024
no-loc: [Transient, Scoped, Singleton, Example]
---

# Understand dependency injection basics in .NET

In this article, you create a .NET console app that manually creates a `ServiceCollection` and corresponding `ServiceProvider`. You learn how to register services and resolve them using dependency injection (DI). This article uses the [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) NuGet package to demonstrate the basics of DI in .NET.

> [!NOTE]
> This article doesn't take advantage of the [Generic Host](generic-host.md) features. For a more comprehensive guide, see the [Use dependency injection](dependency-injection-usage.md) tutorial.

## Get started

To get started, create a new .NET console application named **DI.Basics**. This can be done in a number of ways, some of the most common approaches are listed in the following:

- [Visual Studio: **File > New > Project**](/visualstudio/get-started/csharp/tutorial-console) menu.
- [Visual Studio Code](https://code.visualstudio.com/) and the [C# Dev Kit extension's](https://code.visualstudio.com/docs/csharp/project-management): **Solution Explorer** menu option.
- [.NET CLI: `dotnet new console`](/dotnet/core/tools/dotnet-new-sdk-templates#console) command in the terminal.

Then add the package reference to the [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) in the project file. Regardless of the approach, ensure the project XML resemembles the following:

:::code language="XML" source="snippets/di/di-basics/di-basics.csproj":::

## Dependency injection basics

Dependency injection is a design pattern that allows you to remove hard-coded dependencies and make your application more maintainable and testable. DI is a technique for achieving [Inversion of Control (IoC)](../../architecture/modern-web-apps-azure/architectural-principles.md#dependency-inversion) between classes and their dependencies.

The abstractions for DI in .NET are defined in the [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions) NuGet package:

- `IServiceCollection`: Defines a contract for a collection of service descriptors.
- `IServiceProvider`: Defines a mechanism for retrieving a service object.
- `ServiceDescriptor`: Describes a service with its service type, implementation, and lifetime.

In .NET, DI is managed by adding services and configuring them in an `IServiceCollection`. After services are registered, the `IServiceProvider` instance is created by the `BuildServiceProvider` method. The `IServiceProvider` acts as a container of all the registered services, and it's used to resolve services.

## Create services

Not all services are created equally. Some services require a new instance each time they're retrieved (_transient_), while others should be shared across requests (_scoped_) or for the entire lifetime of the app (_singleton_). For more information on service lifetimes, see [Service lifetimes](dependency-injection.md#service-lifetimes).

Likewise, some services only expose a concrete type, while others are expressed as a contract between an interface and an implementation type. You create several variations of services to help demonstrate these concepts.

Create a new C# file named _IConsole.cs_ and add the following code:

:::code source="snippets/di/di-basics/IConsole.cs":::

This file defines an `IConsole` interface that exposes a single method, `WriteLine`. Next, create a new C# file named _DefaultConsole.cs_ and add the following code:

:::code source="snippets/di/di-basics/DefaultConsole.cs":::

The preceding code represents the default implementation of the `IConsole` interface. The `WriteLine` method conditionally writes to the console based on the `IsEnabled` property.

> [!TIP]
> The naming of an implementation is a choice that your dev-team should agree on. The `Default` prefix is a common convention to indicate a _default_ implementation of an interface, but it's _not_ required.

Next, create an _IGreetingService.cs_ file and add the following C# code:

:::code source="snippets/di/di-basics/IGreetingService.cs":::

Then add a new C# file named _DeafultGreetingService.cs_ and add the following code:

:::code source="snippets/di/di-basics/DefaultGreetingService.cs":::

The preceding code represents the default implementation of the `IGreetingService` interface. The service implementation requires an `IConsole` as a primary constructor parameter. The `Greet` method:

- Creates a `greeting` given the `name`.
- Calls the `WriteLine` method on the `IConsole` instance.
- Returns the `greeting` to the caller.

The last service to create is the _FarewellService.cs_ file, add the following C# code before continuing:

:::code source="snippets/di/di-basics/FarewellService.cs":::

The preceding code is a concrete type, it's not an interface. Also, it needs to be `public` so that it's accessible to consumers, whereas other service implementation types were declared as `internal` and `sealed`. This is a means by which to demonstrate that not all services need to be interfaces, and that concrete types can be registered as services. It alsos demonstrates that service implementations can be `sealed` to prevent inheritance, and `internal` to restrict access to the assembly.

## Update the Program.cs file

Open the _Program.cs_ file and replace the existing code with the following:

:::code source="snippets/di/di-basics/Program.cs":::

The preceding updated code demonstrates the following:

- Creates a new `ServiceCollection` instance.
- Registers and configures the:
  - The `IConsole` using the implemenation factory overload, return a `DefaultConsole` type with the `IsEnabled` set to `true.
  - The `IGreetingService` is added with a corresponding implementation type of `DefaultGreetingService` type.
  - The `FarewellService` is added as a concrete type.
- Builds the `ServiceProvider` from the `ServiceCollection`.
- Resolves the `IGreetingService` and `FarewellService` services.
- Uses the resolved services to greet and say goodbye to a person named `David`.

If you update the `IsEnabled` property of the `DefaultConsole` to `false`, the `Greet` and `Goodbye` methods won't write to the console. This demonstrates that the `IConsole` service is _injected_ into the `IGreetingService` and `FarewellService` services.

All of these services are registered as singletons, although for this sample, it would have worked identically if they were registered as transient or scoped services. In this contrived example, the service lifetimes don't matter, but in a real-world application, you should carefully consider the lifetime of each service.

### Service descriptors

The most commonly used APIs for adding services to the `ServiceCollection` are actually lifetime-named generic extension methods, such as, `AddSingleton`, `AddTransient`, and `AddScoped`. These methods are convenience methods that create a `ServiceDescriptor` instance and add it to the `ServiceCollection`. The `ServiceDescriptor` class is a simple class that describes a service with its service type, implementation, and lifetime.

For each of the services that you registered in the `ServiceCollection`, you could have used the `Add` method to add a `ServiceDescriptor` instance directly. Consider the following examples:

:::code source="snippets/di/di-basics/Program.ServiceDescriptors.cs" id="console":::

The preceding code is equivalent to how the `IConsole` service was registered in the `ServiceCollection`. The `Add` method is used to add a `ServiceDescriptor` instance that describes the `IConsole` service. The static method `ServiceDescriptor.Describe` delegates to various `ServiceDescriptor` constructors. Consider the equivalent code for the `IGreetingService` service:

:::code source="snippets/di/di-basics/Program.ServiceDescriptors.cs" id="greeting":::

The preceding code describes the `IGreetingService` service with its service type, implementation type, and lifetime. Finally, consider the equivalent code for the `FarewellService` service:

:::code source="snippets/di/di-basics/Program.ServiceDescriptors.cs" id="farewell":::

The preceding code describes the concrete `FarewellService` type as both the service type and implementation type. The service is registered as a singleton service.

## See also

* [Dependency injection guidelines](dependency-injection-guidelines.md)
* [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection)
