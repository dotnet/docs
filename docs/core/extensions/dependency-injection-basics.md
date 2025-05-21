---
title: Dependency injection basics
description: Learn how to use dependency injection (DI) in your .NET apps with this simple example. Follow along with this pragmatic guide to understand DI basics in C#.
author: IEvangelist
ms.author: dapine
ms.date: 01/22/2025
no-loc: [Transient, Scoped, Singleton, Example]
ms.topic: concept-article
---

# Understand dependency injection basics in .NET

In this article, you create a .NET console app that manually creates a <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> and corresponding <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider>. You learn how to register services and resolve them using dependency injection (DI). This article uses the [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) NuGet package to demonstrate the basics of DI in .NET.

> [!NOTE]
> This article doesn't take advantage of the [Generic Host](generic-host.md) features. For a more comprehensive guide, see [Use dependency injection in .NET](dependency-injection-usage.md).

## Get started

To get started, create a new .NET console application named **DI.Basics**. Some of the most common approaches for creating a console project are referenced in the following list:

- [Visual Studio: **File > New > Project**](/visualstudio/get-started/csharp/tutorial-console) menu.
- [Visual Studio Code](https://code.visualstudio.com/) and the [C# Dev Kit extension's](https://code.visualstudio.com/docs/csharp/project-management): **Solution Explorer** menu option.
- [.NET CLI: `dotnet new console`](../tools/dotnet-new-sdk-templates.md#console) command in the terminal.

You need to add the package reference to the [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) in the project file. Regardless of the approach, ensure the project resembles the following XML of the _DI.Basics.csproj_ file:

:::code language="XML" source="snippets/di/di-basics/di-basics.csproj":::

## Dependency injection basics

Dependency injection is a design pattern that allows you to remove hard-coded dependencies and make your application more maintainable and testable. DI is a technique for achieving [Inversion of Control (IoC)](../../architecture/modern-web-apps-azure/architectural-principles.md#dependency-inversion) between classes and their dependencies.

The abstractions for DI in .NET are defined in the [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions) NuGet package:

- <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>: Defines a contract for a collection of service descriptors.
- <xref:System.IServiceProvider>: Defines a mechanism for retrieving a service object.
- <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor>: Describes a service with its service type, implementation, and lifetime.

In .NET, DI is managed by adding services and configuring them in an `IServiceCollection`. After services are registered, an `IServiceProvider` instance is built by calling the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> method. The `IServiceProvider` acts as a container of all the registered services, and it's used to resolve services.

## Create example services

Not all services are created equally. Some services require a new instance each time that the service container gets them (_transient_), while others should be shared across requests (_scoped_) or for the entire lifetime of the app (_singleton_). For more information on service lifetimes, see [Service lifetimes](dependency-injection.md#service-lifetimes).

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

Then add a new C# file named _DefaultGreetingService.cs_ and add the following code:

:::code source="snippets/di/di-basics/DefaultGreetingService.cs":::

The preceding code represents the default implementation of the `IGreetingService` interface. The service implementation requires an `IConsole` as a primary constructor parameter. The `Greet` method:

- Creates a `greeting` given the `name`.
- Calls the `WriteLine` method on the `IConsole` instance.
- Returns the `greeting` to the caller.

The last service to create is the _FarewellService.cs_ file, add the following C# code before continuing:

:::code source="snippets/di/di-basics/FarewellService.cs":::

The `FarewellService` represents a concrete type, not an interface. It should be declared as `public` to make it accessible to consumers. Unlike other service implementation types that were declared as `internal` and `sealed`, this code demonstrates that not all services need to be interfaces. It also shows that service implementations can be `sealed` to prevent inheritance and `internal` to restrict access to the assembly.

## Update the `Program` class

Open the _Program.cs_ file and replace the existing code with the following C# code:

:::code source="snippets/di/di-basics/Program.cs":::

The preceding updated code demonstrates the how-to:

- Create a new `ServiceCollection` instance.
- Register and configure services in the `ServiceCollection`:
  - The `IConsole` using the implementation factory overload, return a `DefaultConsole` type with the `IsEnabled` set to `true`.
  - The `IGreetingService` is added with a corresponding implementation type of `DefaultGreetingService` type.
  - The `FarewellService` is added as a concrete type.
- Build the `ServiceProvider` from the `ServiceCollection`.
- Resolve the `IGreetingService` and `FarewellService` services.
- Use the resolved services to greet and say goodbye to a person named `David`.

If you update the `IsEnabled` property of the `DefaultConsole` to `false`, the `Greet` and `SayGoodbye` methods omit writing to the resulting messages to console. A change like this, helps to demonstrate that the `IConsole` service is _injected_ into the `IGreetingService` and `FarewellService` services as a _dependency_ that influences that apps behavior.

All of these services are registered as singletons, although for this sample, it works identically if they were registered as _transient_ or _scoped_ services.

> [!IMPORTANT]
> In this contrived example, the service lifetimes don't matter, but in a real-world application, you should carefully consider the lifetime of each service.

## Run the sample app

To run the sample app, either press <kbd>F5</kbd> in Visual Studio, Visual Studio Code, or run the `dotnet run` command in the terminal. When the app completes, you should see the following output:

```console
Hello, David!
Goodbye, David!
```

### Service descriptors

The most commonly used APIs for adding services to the `ServiceCollection` are lifetime-named generic extension methods, such as:

- `AddSingleton<TService>`
- `AddTransient<TService>`
- `AddScoped<TService>`

These methods are convenience methods that create a <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor> instance and add it to the `ServiceCollection`. The `ServiceDescriptor` is a simple class that describes a service with its service type, implementation type, and lifetime. It can also describe implementation factories and instances.

For each of the services that you registered in the `ServiceCollection`, you could instead call the `Add` method with a `ServiceDescriptor` instance directly. Consider the following examples:

:::code source="snippets/di/di-basics/Program.ServiceDescriptors.cs" id="console":::

The preceding code is equivalent to how the `IConsole` service was registered in the `ServiceCollection`. The `Add` method is used to add a `ServiceDescriptor` instance that describes the `IConsole` service. The static method `ServiceDescriptor.Describe` delegates to various `ServiceDescriptor` constructors. Consider the equivalent code for the `IGreetingService` service:

:::code source="snippets/di/di-basics/Program.ServiceDescriptors.cs" id="greeting":::

The preceding code describes the `IGreetingService` service with its service type, implementation type, and lifetime. Finally, consider the equivalent code for the `FarewellService` service:

:::code source="snippets/di/di-basics/Program.ServiceDescriptors.cs" id="farewell":::

The preceding code describes the concrete `FarewellService` type as both the service and implementation types. The service is registered as a singleton service.

## See also

- [.NET dependency injection](dependency-injection.md)
- [Dependency injection guidelines](dependency-injection-guidelines.md)
- [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection)
