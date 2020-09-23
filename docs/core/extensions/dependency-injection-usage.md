---
title: Use dependency injection in .NET
description: Learn how to use dependency injection in your .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 09/23/2020
ms.topic: tutorial
---

# Tutorial: Use dependency injection in .NET

To use [dependency injection (DI) in .NET](dependency-injection.md), you first must consider the workload and type of application you're developing. With *Microsoft Extensions*, DI is a first-class citizen where services are added and configured in an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. Later, an <xref:Microsoft.Extensions.Hosting.IHost> is created that exposes the <xref:System.IServiceProvider> instance, which acts as a container of all the registered services. From this, you as a developer have an extensive application programming interface (API) for all types of .NET workloads that can leverage DI.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create a .NET console app that uses dependency injection
> - Build and configure a [Generic Host](generic-host.md)
> - Write several interfaces and corresponding implementations
> - Use service lifetime and scoping for DI

## Prerequisites

This tutorial uses:

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core) or a later version.
- An Integrated Developer Environment (IDE), [Visual Studio, Visual Studio Code, or Visual Studio for Mac](https://visualstudio.microsoft.com) are all valid choices
- Ability to create new .NET applications
- Familiarity with NuGet packages

## Create a new console application

Using either the [dotnet new](../tools/dotnet-new.md) command or the available IDE new project wizard, create a new .NET console application named **ConsoleDI.Example**. Add the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package to the project.

## Add interfaces

Add the following interfaces to the project root directory:

*IOperation.cs*

:::code language="csharp" source="snippets/configuration/console-di/IOperation.cs":::

The `IOperation` interface defines a single `OperationId` property.

*ITransientOperation.cs*

:::code language="csharp" source="snippets/configuration/console-di/ITransientOperation.cs":::

*IScopedOperation.cs*

:::code language="csharp" source="snippets/configuration/console-di/IScopedOperation.cs":::

*ISingletonOperation.cs*

:::code language="csharp" source="snippets/configuration/console-di/ISingletonOperation.cs":::

All of the subinterfaces of `IOperation` name their intended service lifetime. For example, "Transient" or "Singleton".

## Add default implementation

Add the following default implementation for the various operations:

*DefaultOperation.cs*

:::code language="csharp" source="snippets/configuration/console-di/DefaultOperation.cs":::

The `DefaultOperation` implements all of the named/marker interfaces and initializes the `OperationId` property to the last four characters of a new globally unique identifier (GUID).

## Add service that requires DI

Add the following operation logger object, which acts as a service to your console application:

*OperationLogger.cs*

:::code language="csharp" source="snippets/configuration/console-di/OperationLogger.cs":::

The `OperationLogger` defines a constructor that requires each of the aforementioned marker interfaces, that is; `ITransientOperation`, `IScopedOperation`, and `ISingletonOperation`. The object exposes a single method that allows the consumer to log the operations with a given `scope` parameter. When invoked, the `LogOperations` method will log each operation's unique identifier with the scope string and message.

## Register services for DI

Finally, update the *Program.cs* file to match following:

:::code language="csharp" source="snippets/configuration/console-di/Program.cs" range="1-18,35-60" highlight="22-26":::

The application starts by:

- Creating an <xref:Microsoft.Extensions.Hosting.IHostBuilder> instance with the [default binder settings](generic-host.md#default-builder-settings).
- Services are configured and added with their corresponding service lifetime.
- The host builder instance calls <xref:Microsoft.Extensions.Hosting.IHostBuilder.Build>, and assigns an instance of <xref:Microsoft.Extensions.Hosting.IHost>.
- The `host` instance calls `ExemplifyScoping` passing in the <xref:Microsoft.Extensions.Hosting.IHost.Services?displayProperty=nameWithType>.

## Conclusion

When running the application, you could expect to see similar output to the following:

```console
Scope 1-Call 1 .GetRequiredService<OperationLogger>(): ITransientOperation [ 80f4...Always different        ]
Scope 1-Call 1 .GetRequiredService<OperationLogger>(): IScopedOperation    [ c878...Changes only with scope ]
Scope 1-Call 1 .GetRequiredService<OperationLogger>(): ISingletonOperation [ 1586...Always the same         ]
...
Scope 1-Call 2 .GetRequiredService<OperationLogger>(): ITransientOperation [ f3c0...Always different        ]
Scope 1-Call 2 .GetRequiredService<OperationLogger>(): IScopedOperation    [ c878...Changes only with scope ]
Scope 1-Call 2 .GetRequiredService<OperationLogger>(): ISingletonOperation [ 1586...Always the same         ]

Scope 2-Call 1 .GetRequiredService<OperationLogger>(): ITransientOperation [ f9af...Always different        ]
Scope 2-Call 1 .GetRequiredService<OperationLogger>(): IScopedOperation    [ 2bd0...Changes only with scope ]
Scope 2-Call 1 .GetRequiredService<OperationLogger>(): ISingletonOperation [ 1586...Always the same         ]
...
Scope 2-Call 2 .GetRequiredService<OperationLogger>(): ITransientOperation [ fa65...Always different        ]
Scope 2-Call 2 .GetRequiredService<OperationLogger>(): IScopedOperation    [ 2bd0...Changes only with scope ]
Scope 2-Call 2 .GetRequiredService<OperationLogger>(): ISingletonOperation [ 1586...Always the same         ]
```

From the application output, you can see that:

- Transient operations are always different, meaning a new instance is created with every retrieval of the service.
- Scoped operations change only with a new scope, but are the same instance within a scope.
- Singleton operations are always the same, meaning a new instance is only created once.

## Next steps

> [!div class="nextstepaction"]
> [Dependency injection guidelines](dependency-injection-guidelines.md)
