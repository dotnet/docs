---
title: Dependency injection
description: Learn how to use dependency injection within your .NET apps. Discover how to registration services, define service lifetimes, and express dependencies in C#.
author: IEvangelist
ms.author: dapine
ms.date: 07/18/2024
ms.topic: overview
---

# .NET dependency injection

.NET supports the dependency injection (DI) software design pattern, which is a technique for achieving [Inversion of Control (IoC)](../../architecture/modern-web-apps-azure/architectural-principles.md#dependency-inversion) between classes and their dependencies. Dependency injection in .NET is a built-in part of the framework, along with configuration, logging, and the options pattern.

A *dependency* is an object that another object depends on. Examine the following `MessageWriter` class with a `Write` method that other classes depend on:

```csharp
public class MessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
    }
}
```

A class can create an instance of the `MessageWriter` class to make use of its `Write` method. In the following example, the `MessageWriter` class is a dependency of the `Worker` class:

```csharp
public class Worker : BackgroundService
{
    private readonly MessageWriter _messageWriter = new();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _messageWriter.Write($"Worker running at: {DateTimeOffset.Now}");
            await Task.Delay(1_000, stoppingToken);
        }
    }
}
```

The class creates and directly depends on the `MessageWriter` class. Hard-coded dependencies, such as in the previous example, are problematic and should be avoided for the following reasons:

- To replace `MessageWriter` with a different implementation, the `Worker` class must be modified.
- If `MessageWriter` has dependencies, they must also be configured by the `Worker` class. In a large project with multiple classes depending on `MessageWriter`, the configuration code becomes scattered across the app.
- This implementation is difficult to unit test. The app should use a mock or stub `MessageWriter` class, which isn't possible with this approach.

Dependency injection addresses these problems through:

- The use of an interface or base class to abstract the dependency implementation.
- Registration of the dependency in a service container. .NET provides a built-in service container, <xref:System.IServiceProvider>. Services are typically registered at the app's start-up and appended to an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. Once all services are added, you use <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> to create the service container.
- *Injection* of the service into the constructor of the class where it's used. The framework takes on the responsibility of creating an instance of the dependency and disposing of it when it's no longer needed.

As an example, the `IMessageWriter` interface defines the `Write` method:

:::code language="csharp" source="snippets/configuration/dependency-injection/IMessageWriter.cs":::

This interface is implemented by a concrete type, `MessageWriter`:

:::code language="csharp" source="snippets/configuration/dependency-injection/MessageWriter.cs":::

The sample code registers the `IMessageWriter` service with the concrete type `MessageWriter`. The <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A> method registers the service with a singleton lifetime, the lifetime of the app. [Service lifetimes](#service-lifetimes) are described later in this article.

:::code language="csharp" source="snippets/configuration/dependency-injection/Program.cs" highlight="5-8":::

In the preceding code, the sample app:

- Creates a host app builder instance.
- Configures the services by registering:

  - The `Worker` as a hosted service. For more information, see [Worker Services in .NET](workers.md).
  - The `IMessageWriter` interface as a singleton service with a corresponding implementation of the `MessageWriter` class.

- Builds the host and runs it.

The host contains the dependency injection service provider. It also contains all the other relevant services required to automatically instantiate the `Worker` and provide the corresponding `IMessageWriter` implementation as an argument.

:::code language="csharp" source="snippets/configuration/dependency-injection/Worker.cs":::

By using the DI pattern, the worker service:

- Doesn't use the concrete type `MessageWriter`, only the `IMessageWriter` interface that implements it. That makes it easy to change the implementation that the worker service uses without modifying the worker service.
- Doesn't create an instance of `MessageWriter`. The instance is created by the DI container.

The implementation of the `IMessageWriter` interface can be improved by using the built-in logging API:

:::code language="csharp" source="snippets/configuration/dependency-injection/LoggingMessageWriter.cs":::

The updated `AddSingleton` method registers the new `IMessageWriter` implementation:

```csharp
builder.Services.AddSingleton<IMessageWriter, LoggingMessageWriter>();
```

The <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder> (`builder`) type is part of the `Microsoft.Extensions.Hosting` NuGet package.

`LoggingMessageWriter` depends on <xref:Microsoft.Extensions.Logging.ILogger%601>, which it requests in the constructor. `ILogger<TCategoryName>` is a [framework-provided service](#framework-provided-services).

It's not unusual to use dependency injection in a chained fashion. Each requested dependency in turn requests its own dependencies. The container resolves the dependencies in the graph and returns the fully resolved service. The collective set of dependencies that must be resolved is typically referred to as a *dependency tree*, *dependency graph*, or *object graph*.

The container resolves `ILogger<TCategoryName>` by taking advantage of [(generic) open types](/dotnet/csharp/language-reference/language-specification/types#843-open-and-closed-types), eliminating the need to register every [(generic) constructed type](/dotnet/csharp/language-reference/language-specification/types#84-constructed-types).

With dependency injection terminology, a service:

- Is typically an object that provides a service to other objects, such as the `IMessageWriter` service.
- Is not related to a web service, although the service may use a web service.

The framework provides a robust logging system. The `IMessageWriter` implementations shown in the preceding examples were written to demonstrate basic DI, not to implement logging. Most apps shouldn't need to write loggers. The following code demonstrates using the default logging, which only requires the `Worker` to be registered as a hosted service <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A>:

```csharp
public sealed class Worker(ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            await Task.Delay(1_000, stoppingToken);
        }
    }
}
```

Using the preceding code, there is no need to update _Program.cs_, because logging is provided by the framework.

## Multiple constructor discovery rules

When a type defines more than one constructor, the service provider has logic for determining which constructor to use. The constructor with the most parameters where the types are DI-resolvable is selected. Consider the following C# example service:

```csharp
public class ExampleService
{
    public ExampleService()
    {
    }

    public ExampleService(ILogger<ExampleService> logger)
    {
        // omitted for brevity
    }

    public ExampleService(FooService fooService, BarService barService)
    {
        // omitted for brevity
    }
}
```

In the preceding code, assume that logging has been added and is resolvable from the service provider but the `FooService` and `BarService` types are not. The constructor with the `ILogger<ExampleService>` parameter is used to resolve the `ExampleService` instance. Even though there's a constructor that defines more parameters, the `FooService` and `BarService` types are not DI-resolvable.

If there's ambiguity when discovering constructors, an exception is thrown. Consider the following C# example service:

```csharp
public class ExampleService
{
    public ExampleService()
    {
    }

    public ExampleService(ILogger<ExampleService> logger)
    {
        // omitted for brevity
    }

    public ExampleService(IOptions<ExampleOptions> options)
    {
        // omitted for brevity
    }
}
```

> [!WARNING]
> The `ExampleService` code with ambiguous DI-resolvable type parameters would throw an exception. Do **not** do this&mdash;it's intended to show what is meant by "ambiguous DI-resolvable types".

In the preceding example, there are three constructors. The first constructor is parameterless and requires no services from the service provider. Assume that both logging and options have been added to the DI container and are DI-resolvable services. When the DI container attempts to resolve the `ExampleService` type, it will throw an exception, as the two constructors are ambiguous.

You can avoid ambiguity by defining a constructor that accepts both DI-resolvable types instead:

```csharp
public class ExampleService
{
    public ExampleService()
    {
    }

    public ExampleService(
        ILogger<ExampleService> logger,
        IOptions<ExampleOptions> options)
    {
        // omitted for brevity
    }
}
```

## Register groups of services with extension methods

Microsoft Extensions uses a convention for registering a group of related services. The convention is to use a single `Add{GROUP_NAME}` extension method to register all of the services required by a framework feature. For example, the <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions%2A> extension method registers all of the services required for using options.

## Framework-provided services

When using any of the available host or app builder patterns, defaults are applied and services are registered by the framework. Consider some of the most popular host and app builder patterns:

- <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.CreateDefault%2A?displayProperty=nameWithType>
- <xref:Microsoft.Maui.Hosting.MauiApp.CreateBuilder%2A?displayProperty=nameWithType>

After creating a builder from any of these APIs, the `IServiceCollection` has services defined by the framework, depending on [how the host was configured](generic-host.md#host-configuration). For apps based on the .NET templates, the framework could register hundreds of services.

The following table lists a small sample of these framework-registered services:

| Service Type | Lifetime |
|--|--|
| <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory?displayProperty=fullName> | Singleton |
| <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> | Singleton |
| <xref:Microsoft.Extensions.Logging.ILogger%601?displayProperty=fullName> | Singleton |
| <xref:Microsoft.Extensions.Logging.ILoggerFactory?displayProperty=fullName> | Singleton |
| <xref:Microsoft.Extensions.ObjectPool.ObjectPoolProvider?displayProperty=fullName> | Singleton |
| <xref:Microsoft.Extensions.Options.IConfigureOptions%601?displayProperty=fullName> | Transient |
| <xref:Microsoft.Extensions.Options.IOptions%601?displayProperty=fullName> | Singleton |
| <xref:System.Diagnostics.DiagnosticListener?displayProperty=fullName> | Singleton |
| <xref:System.Diagnostics.DiagnosticSource?displayProperty=fullName> | Singleton |

## Service lifetimes

Services can be registered with one of the following lifetimes:

- [Transient](#transient)
- [Scoped](#scoped)
- [Singleton](#singleton)

The following sections describe each of the preceding lifetimes. Choose an appropriate lifetime for each registered service.

### Transient

Transient lifetime services are created each time they're requested from the service container. To register a service as _transient_, call <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient%2A>.

In apps that process requests, transient services are disposed at the end of the request. This lifetime incurs per/request allocations, as services are resolved and constructed every time. For more information, see [Dependency Injection Guidelines: IDisposable guidance for transient and shared instances](dependency-injection-guidelines.md#idisposable-guidance-for-transient-and-shared-instances).

### Scoped

For web applications, a scoped lifetime indicates that services are created once per client request (connection). Register scoped services with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped%2A>.

In apps that process requests, scoped services are disposed at the end of the request.

> [!NOTE]
> When using Entity Framework Core, the <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> extension method registers `DbContext` types with a scoped lifetime by default.

A scoped service should always be used from within a scope—either an implicit scope (such as ASP.NET Core's per-request scope) or an explicit scope created with <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory.CreateScope?displayProperty=nameWithType>.

Do ***not*** resolve a scoped service directly from a singleton using constructor injection or by requesting it from <xref:System.IServiceProvider> in the singleton. Doing so causes the scoped service to behave like a singleton, which can lead to incorrect state when processing subsequent requests.

It's acceptable to resolve a scoped service within a singleton if you create and use an explicit scope with <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory>.

It's also fine to:

- Resolve a singleton service from a scoped or transient service.
- Resolve a scoped service from another scoped or transient service.

By default, in the development environment, resolving a service from another service with a longer lifetime throws an exception. For more information, see [Scope validation](#scope-validation).

### Singleton

Singleton lifetime services are created either:

- The first time they're requested.
- By the developer, when providing an implementation instance directly to the container. This approach is rarely needed.

Every subsequent request of the service implementation from the dependency injection container uses the same instance. If the app requires singleton behavior, allow the service container to manage the service's lifetime. Don't implement the singleton design pattern and provide code to dispose of the singleton. Services should never be disposed by code that resolved the service from the container. If a type or factory is registered as a singleton, the container disposes the singleton automatically.

Register singleton services with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A>. Singleton services must be thread safe and are often used in stateless services.

In apps that process requests, singleton services are disposed when the <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> is disposed on application shutdown. Because memory is not released until the app is shut down, consider memory use with a singleton service.

## Service registration methods

The framework provides service registration extension methods that are useful in specific scenarios:

| Method | Automatic<br>object<br>disposal | Multiple<br>implementations | Pass args |
|--|:-:|:-:|:-:|
| `Add{LIFETIME}<{SERVICE}, {IMPLEMENTATION}>()`<br><br>Example:<br><br>`services.AddSingleton<IMyDep, MyDep>();` | Yes | Yes | No |
| `Add{LIFETIME}<{SERVICE}>(sp => new {IMPLEMENTATION})`<br><br>Examples:<br><br>`services.AddSingleton<IMyDep>(sp => new MyDep());`<br>`services.AddSingleton<IMyDep>(sp => new MyDep(99));` | Yes | Yes | Yes |
| `Add{LIFETIME}<{IMPLEMENTATION}>()`<br><br>Example:<br><br>`services.AddSingleton<MyDep>();` | Yes | No | No |
| `AddSingleton<{SERVICE}>(new {IMPLEMENTATION})`<br><br>Examples:<br><br>`services.AddSingleton<IMyDep>(new MyDep());`<br>`services.AddSingleton<IMyDep>(new MyDep(99));` | No | Yes | Yes |
| `AddSingleton(new {IMPLEMENTATION})`<br><br>Examples:<br><br>`services.AddSingleton(new MyDep());`<br>`services.AddSingleton(new MyDep(99));` | No | No | Yes |

For more information on type disposal, see the [Disposal of services](dependency-injection-guidelines.md#disposal-of-services) section.

Registering a service with only an implementation type is equivalent to registering that service with the same implementation and service type. For example, consider the following code:

```csharp
services.AddSingleton<ExampleService>();
```

This is equivalent to registering the service with both the service and implementation of the same types:

```csharp
services.AddSingleton<ExampleService, ExampleService>();
```

This equivalency is why multiple implementations of a service can't be registered using the methods that don't take an explicit service type. These methods can register multiple *instances* of a service, but they will all have the same *implementation* type.

Any of the above service registration methods can be used to register multiple service instances of the same service type. In the following example, `AddSingleton` is called twice with `IMessageWriter` as the service type. The second call to `AddSingleton` overrides the previous one when resolved as `IMessageWriter` and adds to the previous one when multiple services are resolved via `IEnumerable<IMessageWriter>`. Services appear in the order they were registered when resolved via `IEnumerable<{SERVICE}>`.

:::code language="csharp" source="snippets/configuration/console-di-ienumerable/Program.cs" highlight="11-16":::

The preceding sample source code registers two implementations of the `IMessageWriter`.

:::code language="csharp" source="snippets/configuration/console-di-ienumerable/ExampleService.cs" highlight="7-16":::

The `ExampleService` defines two constructor parameters; a single `IMessageWriter`, and an `IEnumerable<IMessageWriter>`. The single `IMessageWriter` is the last implementation to have been registered, whereas the `IEnumerable<IMessageWriter>` represents all registered implementations.

The framework also provides `TryAdd{LIFETIME}` extension methods, which register the service only if there isn't already an implementation registered.

In the following example, the call to `AddSingleton` registers `ConsoleMessageWriter` as an implementation for `IMessageWriter`. The call to `TryAddSingleton` has no effect because `IMessageWriter` already has a registered implementation:

```csharp
services.AddSingleton<IMessageWriter, ConsoleMessageWriter>();
services.TryAddSingleton<IMessageWriter, LoggingMessageWriter>();
```

The `TryAddSingleton` has no effect, as it was already added and the "try" will fail. The `ExampleService` would assert the following:

```csharp
public class ExampleService
{
    public ExampleService(
        IMessageWriter messageWriter,
        IEnumerable<IMessageWriter> messageWriters)
    {
        Trace.Assert(messageWriter is ConsoleMessageWriter);
        Trace.Assert(messageWriters.Single() is ConsoleMessageWriter);
    }
}
```

For more information, see:

- <xref:Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAdd%2A>
- <xref:Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddTransient%2A>
- <xref:Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddScoped%2A>
- <xref:Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddSingleton%2A>

The [TryAddEnumerable(ServiceDescriptor)](xref:Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddEnumerable%2A) methods register the service only if there isn't already an implementation *of the same type*. Multiple services are resolved via `IEnumerable<{SERVICE}>`. When registering services, add an instance if one of the same types hasn't already been added. Library authors use `TryAddEnumerable` to avoid registering multiple copies of an implementation in the container.

In the following example, the first call to `TryAddEnumerable` registers `MessageWriter` as an implementation for `IMessageWriter1`. The second call registers `MessageWriter` for `IMessageWriter2`. The third call has no effect because `IMessageWriter1` already has a registered implementation of `MessageWriter`:

```csharp
public interface IMessageWriter1 { }
public interface IMessageWriter2 { }

public class MessageWriter : IMessageWriter1, IMessageWriter2
{
}

services.TryAddEnumerable(ServiceDescriptor.Singleton<IMessageWriter1, MessageWriter>());
services.TryAddEnumerable(ServiceDescriptor.Singleton<IMessageWriter2, MessageWriter>());
services.TryAddEnumerable(ServiceDescriptor.Singleton<IMessageWriter1, MessageWriter>());
```

Service registration is generally order-independent except when registering multiple implementations of the same type.

`IServiceCollection` is a collection of <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor> objects. The following example shows how to register a service by creating and adding a `ServiceDescriptor`:

```csharp
string secretKey = Configuration["SecretKey"];
var descriptor = new ServiceDescriptor(
    typeof(IMessageWriter),
    _ => new DefaultMessageWriter(secretKey),
    ServiceLifetime.Transient);

services.Add(descriptor);
```

The built-in `Add{LIFETIME}` methods use the same approach. For example, see the [AddScoped source code](https://github.com/dotnet/extensions/blob/v3.1.8/src/DependencyInjection/DI.Abstractions/src/ServiceCollectionServiceExtensions.cs#L216-L237).

### Constructor injection behavior

Services can be resolved by using:

- <xref:System.IServiceProvider>
- <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities>:
  - Creates objects that aren't registered in the container.
  - Used with some framework features.

Constructors can accept arguments that aren't provided by dependency injection, but the arguments must assign default values.

When services are resolved by `IServiceProvider` or `ActivatorUtilities`, constructor injection requires a *public* constructor.

When services are resolved by `ActivatorUtilities`, constructor injection requires that only one applicable constructor exists. Constructor overloads are supported, but only one overload can exist whose arguments can all be fulfilled by dependency injection.

## Scope validation

When the app runs in the `Development` environment and calls [CreateApplicationBuilder](generic-host.md#host-builder-settings) to build the host, the default service provider performs checks to verify that:

- Scoped services aren't resolved from the root service provider.
- Scoped services aren't injected into singletons.

The root service provider is created when <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> is called. The root service provider's lifetime corresponds to the app's lifetime when the provider starts with the app and is disposed when the app shuts down.

Scoped services are disposed by the container that created them. If a scoped service is created in the root container, the service's lifetime is effectively promoted to singleton because it's only disposed by the root container when the app shuts down. Validating service scopes catches these situations when `BuildServiceProvider` is called.

## Scope scenarios

The <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory> is always registered as a singleton, but the <xref:System.IServiceProvider> can vary based on the lifetime of the containing class. For example, if you resolve services from a scope, and any of those services take an <xref:System.IServiceProvider>, it'll be a scoped instance.

To achieve scoping services within implementations of <xref:Microsoft.Extensions.Hosting.IHostedService>, such as the <xref:Microsoft.Extensions.Hosting.BackgroundService>, do *not* inject the service dependencies via constructor injection. Instead, inject <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory>, create a scope, then resolve dependencies from the scope to use the appropriate service lifetime.

:::code language="csharp" source="snippets/configuration/worker-scope/Worker.cs":::

In the preceding code, while the app is running, the background service:

- Depends on the <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory>.
- Creates an <xref:Microsoft.Extensions.DependencyInjection.IServiceScope> for resolving additional services.
- Resolves scoped services for consumption.
- Works on processing objects and then relaying them, and finally marks them as processed.

From the sample source code, you can see how implementations of <xref:Microsoft.Extensions.Hosting.IHostedService> can benefit from scoped service lifetimes.

## Keyed services

Starting with .NET 8, there is support for service registrations and lookups based on a key, meaning it's possible to register multiple services with a different key, and use this key for the lookup.

For example, consider the case where you have different implementations of the interface `IMessageWriter`: `MemoryMessageWriter` and `QueueMessageWriter`.

You can register these services using the overload of the service registration methods (seen earlier) that supports a key as a parameter:

```csharp
services.AddKeyedSingleton<IMessageWriter, MemoryMessageWriter>("memory");
services.AddKeyedSingleton<IMessageWriter, QueueMessageWriter>("queue");
```

The `key` isn't limited to `string`, it can be any `object` you want, as long as the type correctly implements `Equals`.

In the constructor of the class that uses `IMessageWriter`, you add the <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute> to specify the key of the service to resolve:

```csharp
public class ExampleService
{
    public ExampleService(
        [FromKeyedServices("queue")] IMessageWriter writer)
    {
        // Omitted for brevity...
    }
}
```

## See also

- [Understand dependency injection basics in .NET](dependency-injection-basics.md)
- [Use dependency injection in .NET](dependency-injection-usage.md)
- [Dependency injection guidelines](dependency-injection-guidelines.md)
- [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection)
- [NDC Conference Patterns for DI app development](https://www.youtube.com/watch?v=x-C-CNBVTaY)
- [Explicit dependencies principle](../../architecture/modern-web-apps-azure/architectural-principles.md#explicit-dependencies)
- [Inversion of control containers and the dependency injection pattern (Martin Fowler)](https://www.martinfowler.com/articles/injection.html)
- DI bugs should be created in the [github.com/dotnet/extensions](https://github.com/dotnet/extensions/issues) repo
