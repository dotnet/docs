---
title: Asynchronous state management
description: Learn how to efficiently manage ambient state in asynchronous contexts using Microsoft.Extensions.AsyncState in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 10/20/2025
ms.topic: concept-article
ai-usage: ai-assisted
---

# Asynchronous state management

The [`Microsoft.Extensions.AsyncState`](https://www.nuget.org/packages/Microsoft.Extensions.AsyncState) NuGet package provides functionality to store and retrieve objects within the current asynchronous context. This package offers performance and usability improvements over using <xref:System.Threading.AsyncLocal%601> directly, particularly when multiple objects need to be shared across asynchronous operations.

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
<PackageReference Include="Microsoft.Extensions.AsyncState" Version="9.8.0" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Register async state services

Register the async state services with your dependency injection container using the <xref:Microsoft.Extensions.DependencyInjection.AsyncStateExtensions.AddAsyncState%2A> extension method:

```csharp
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddAsyncState();

var provider = services.BuildServiceProvider();
```

This registration makes the <xref:Microsoft.Extensions.AsyncState.IAsyncContext%601> and <xref:Microsoft.Extensions.AsyncState.IAsyncState%601> interfaces available for dependency injection.

## Use IAsyncContext

The <xref:Microsoft.Extensions.AsyncState.IAsyncContext%601> interface provides methods to get and set values in the current asynchronous context:

```csharp
using Microsoft.Extensions.AsyncState;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddAsyncState();

var provider = services.BuildServiceProvider();
var context = provider.GetRequiredService<IAsyncContext<UserContext>>();

// Set a value in the async context
var userContext = new UserContext { UserId = "12345", UserName = "Alice" };
context.Set(userContext);

// Retrieve the value
if (context.TryGet(out var retrievedContext))
{
    Console.WriteLine($"User: {retrievedContext.UserName}");
}

public class UserContext
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
```

The value set in the context flows through asynchronous operations, making it available to all code executing within the same async context.

## Use IAsyncState

The <xref:Microsoft.Extensions.AsyncState.IAsyncState%601> interface provides a simpler property-based API for accessing async state:

```csharp
using Microsoft.Extensions.AsyncState;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddAsyncState();

var provider = services.BuildServiceProvider();
var asyncState = provider.GetRequiredService<IAsyncState<RequestInfo>>();

// Initialize the state
asyncState.Initialize();

// Set a value
asyncState.Value = new RequestInfo 
{ 
    RequestId = Guid.NewGuid().ToString(),
    Timestamp = DateTimeOffset.UtcNow
};

// Access the value
Console.WriteLine($"Request ID: {asyncState.Value.RequestId}");

// Reset the state
asyncState.Reset();

public class RequestInfo
{
    public string RequestId { get; set; } = string.Empty;
    public DateTimeOffset Timestamp { get; set; }
}
```

## Practical example: Request correlation

A common use case for async state is maintaining correlation information across an HTTP request:

```csharp
using Microsoft.Extensions.AsyncState;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddAsyncState();
builder.Services.AddSingleton<RequestProcessor>();

var host = builder.Build();

var processor = host.Services.GetRequiredService<RequestProcessor>();
await processor.ProcessRequestAsync("ABC-123");

public class RequestProcessor
{
    private readonly IAsyncContext<CorrelationContext> _asyncContext;

    public RequestProcessor(IAsyncContext<CorrelationContext> asyncContext)
    {
        _asyncContext = asyncContext;
    }

    public async Task ProcessRequestAsync(string correlationId)
    {
        // Set correlation context at the beginning of request processing
        _asyncContext.Set(new CorrelationContext { CorrelationId = correlationId });

        // The correlation ID flows through all async operations
        await Step1Async();
        await Step2Async();
    }

    private async Task Step1Async()
    {
        await Task.Delay(100);
        
        if (_asyncContext.TryGet(out var context))
        {
            Console.WriteLine($"Step 1 - Correlation ID: {context.CorrelationId}");
        }
    }

    private async Task Step2Async()
    {
        await Task.Delay(100);
        
        if (_asyncContext.TryGet(out var context))
        {
            Console.WriteLine($"Step 2 - Correlation ID: {context.CorrelationId}");
        }
    }
}

public class CorrelationContext
{
    public string CorrelationId { get; set; } = string.Empty;
}
```

In this example, the correlation ID is set once at the beginning of request processing and is automatically available in all subsequent async operations without needing to pass it as a parameter.

## ASP.NET Core integration

In ASP.NET Core applications, you can use async state to flow request-specific information through your application:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.AsyncState;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAsyncState();
builder.Services.AddScoped<RequestHandler>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var asyncContext = context.RequestServices.GetRequiredService<IAsyncContext<RequestMetadata>>();
    
    // Set request metadata at the beginning of the pipeline
    asyncContext.Set(new RequestMetadata
    {
        RequestId = context.TraceIdentifier,
        RequestPath = context.Request.Path,
        StartTime = DateTimeOffset.UtcNow
    });

    await next();
});

app.MapGet("/api/data", async (RequestHandler handler) =>
{
    return await handler.GetDataAsync();
});

app.Run();

public class RequestHandler
{
    private readonly IAsyncContext<RequestMetadata> _asyncContext;

    public RequestHandler(IAsyncContext<RequestMetadata> asyncContext)
    {
        _asyncContext = asyncContext;
    }

    public async Task<object> GetDataAsync()
    {
        await Task.Delay(50);
        
        if (_asyncContext.TryGet(out var metadata))
        {
            var duration = DateTimeOffset.UtcNow - metadata.StartTime;
            return new
            {
                RequestId = metadata.RequestId,
                RequestPath = metadata.RequestPath,
                Duration = duration.TotalMilliseconds
            };
        }

        return new { Error = "No request metadata available" };
    }
}

public class RequestMetadata
{
    public string RequestId { get; set; } = string.Empty;
    public string RequestPath { get; set; } = string.Empty;
    public DateTimeOffset StartTime { get; set; }
}
```

## Best practices

When using async state, consider the following best practices:

- **Limit state size**: Keep async state objects small to minimize memory overhead and serialization costs in scenarios where async state might need to be serialized.
- **Initialize state early**: Set async state values as early as possible in your async operation to ensure they're available throughout the execution flow.
- **Clean up state**: Reset or clear async state when it's no longer needed to avoid memory leaks in long-running applications.
- **Use appropriate interfaces**: Use `IAsyncContext<T>` when you need explicit control over state initialization and reset. Use `IAsyncState<T>` for simpler property-based access.
- **Type safety**: Create specific context types rather than using generic dictionaries to maintain type safety and improve code clarity.

## See also

- [Dependency injection in .NET](dependency-injection.md)
- <xref:System.Threading.AsyncLocal%601>
- [ASP.NET Core middleware](/aspnet/core/fundamentals/middleware/)
