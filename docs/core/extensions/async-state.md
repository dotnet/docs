---
title: Asynchronous state management
description: Learn how to efficiently manage ambient state in asynchronous contexts using Microsoft.Extensions.AsyncState in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 02/26/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Asynchronous state management

The [📦 `Microsoft.Extensions.AsyncState`](https://www.nuget.org/packages/Microsoft.Extensions.AsyncState) NuGet package provides functionality to store and retrieve objects within the current asynchronous context. This package offers performance and usability improvements over using <xref:System.Threading.AsyncLocal%601> directly, particularly when multiple objects need to be shared across asynchronous operations.

## Why use AsyncState

While .NET provides `AsyncLocal<T>` for managing ambient data in asynchronous contexts, using it directly can have drawbacks:

- **Performance**: Each `AsyncLocal<T>` instance adds overhead. When multiple objects need to flow through async contexts, managing many `AsyncLocal<T>` instances can impact performance.
- **Abstraction**: Direct use of `AsyncLocal<T>` couples your code to a specific implementation, making it harder to optimize or change in the future.
- **Lifetime management**: The AsyncState package provides better control over the lifetime of ambient data through explicit APIs.

The `Microsoft.Extensions.AsyncState` package addresses these concerns by providing:

- An optimized implementation that reduces the number of `AsyncLocal<T>` instances needed.
- A clean abstraction for storing and retrieving ambient data.
- Integration with dependency injection for easier testing and configuration.

## Get started

To get started with asynchronous state management, install the [`Microsoft.Extensions.AsyncState`](https://www.nuget.org/packages/Microsoft.Extensions.AsyncState) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.AsyncState
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.AsyncState" Version="10.0.0" />
```

---

For more information, see [dotnet add package](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Register async state services

Register the async state services with your dependency injection container using the <xref:Microsoft.Extensions.DependencyInjection.AsyncStateExtensions.AddAsyncState%2A> extension method:

```csharp
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddAsyncState();

var provider = services.BuildServiceProvider();
```

This registration makes the <xref:Microsoft.Extensions.AsyncState.IAsyncContext%601> and <xref:Microsoft.Extensions.AsyncState.IAsyncState> interfaces available for dependency injection.

## Use IAsyncContext

The <xref:Microsoft.Extensions.AsyncState.IAsyncContext%601> interface provides methods to get and set values in the current asynchronous context:

:::code language="csharp" source="snippets/async-state/csharp/IAsyncContextExample/Program.cs" id="snippet":::

:::code language="csharp" source="snippets/async-state/csharp/IAsyncContextExample/Program.cs" id="UserContext":::

The value set in the context flows through asynchronous operations, making it available to all code executing within the same async context.

## Use IAsyncState

The <xref:Microsoft.Extensions.AsyncState.IAsyncState> interface is the base lifecycle interface that `IAsyncContext<T>` extends. It provides `Initialize()` and `Reset()` methods for managing the async state lifecycle. For typed access to async state values, use `IAsyncContext<T>` instead.

## Practical example: Request correlation

A common use case for async state is maintaining correlation information across an HTTP request:

:::code language="csharp" source="snippets/async-state/csharp/RequestCorrelation/Program.cs" id="RequestProcessor":::

:::code language="csharp" source="snippets/async-state/csharp/RequestCorrelation/Program.cs" id="CorrelationContext":::

In this example, the correlation ID is set once at the beginning of request processing and is automatically available in all subsequent async operations without needing to pass it as a parameter.

## ASP.NET Core integration

In ASP.NET Core applications, you can use async state to flow request-specific information through your application:

:::code language="csharp" source="snippets/async-state/csharp/AspNetCoreIntegration/Program.cs" id="RequestHandler":::

:::code language="csharp" source="snippets/async-state/csharp/AspNetCoreIntegration/Program.cs" id="RequestMetadata":::

## Best practices

When using async state, consider the following best practices:

- **Limit state size**: Keep async state objects small to reduce memory overhead and maintain performance.
- **Initialize state early**: Set async state values as early as possible to ensure they're available to all downstream async operations.
- **Clean up state**: Reset or clear async state when it's no longer needed to avoid memory leaks in long-running applications.
- **Use appropriate interfaces**: Use `IAsyncContext<T>` to get and set typed values within the current async context. Use `IAsyncState` when you need to directly manage the initialization and reset lifecycle.
- **Type safety**: Create specific context types rather than using generic dictionaries to maintain type safety and improve code clarity.

## See also

- [Dependency injection in .NET](dependency-injection/overview.md)
- <xref:System.Threading.AsyncLocal%601>
- [ASP.NET Core middleware](/aspnet/core/fundamentals/middleware/)
