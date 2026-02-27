---
title: Dependency injection
description: Learn how to use dependency injection within your .NET apps. Discover how to define service lifetimes and express dependencies in C#.
ms.date: 01/26/2026
ms.topic: overview
ai-usage: ai-assisted
---

# .NET dependency injection

.NET supports the *dependency injection* (DI) software design pattern, which is a technique for achieving [Inversion of Control (IoC)](../../../architecture/modern-web-apps-azure/architectural-principles.md#dependency-inversion) between classes and their dependencies. Dependency injection in .NET is a built-in part of the framework, along with configuration, logging, and the options pattern.

> [!IMPORTANT]
> The examples in this article use the `Microsoft.NET.Sdk.Worker` SDK. For more information, see [Worker services in .NET](../workers.md).

A *dependency* is an object that another object depends on. The following `MessageWriter` class has a `Write` method that other classes might depend on:

:::code language="csharp" source="snippets/overview/Program.cs" id="SnippetMW":::

A class can create an instance of the `MessageWriter` class to use its `Write` method. In the following example, the `MessageWriter` class is a *dependency* of the `Worker` class:

:::code language="csharp" source="snippets/overview/StandaloneWorker.cs" id="WorkerClass":::

In this case, the `Worker` class creates and directly depends on the `MessageWriter` class. Hard-coded dependencies like this are problematic and should be avoided for the following reasons:

- To replace `MessageWriter` with a different implementation, you must modify the `Worker` class.
- If `MessageWriter` has dependencies, the `Worker` class must also configure them. In a large project with multiple classes depending on `MessageWriter`, the configuration code becomes scattered across the app.
- This implementation is difficult to unit test. The app should use a mock or stub `MessageWriter` class, which isn't possible with this approach.

## The concept

Dependency injection addresses hard-coded dependency problems through:

- The use of an interface or base class to abstract the dependency implementation.
- Registration of the dependency in a *service container*.

  .NET provides a built-in service container, <xref:System.IServiceProvider>. Services are typically registered at the app's start-up and appended to an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. Once all services are added, use <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> to create the service container.

  > [!IMPORTANT]
  > Desktop apps control their own lifetime. Frameworks like WPF and Windows Forms require you to integrate the host lifetime with the application lifetime events.

- Injection of the service into the constructor of the class where it's used.

  The framework takes on the responsibility of creating an instance of the dependency and disposing of it when it's no longer needed.

> [!TIP]
> In dependency injection terminology, a *service* is typically an object that provides a service to other objects, such as the `IMessageWriter` service. The service isn't related to a web service, although it might use a web service.

As an example, assume the `IMessageWriter` interface defines the `Write` method. This interface is implemented by a concrete type, `MessageWriter`, shown previously. The following sample code registers the `IMessageWriter` service with the concrete type `MessageWriter`. The <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A> method registers the service with a [*singleton* lifetime](service-lifetimes.md#singleton), which means it isn't disposed until the app shuts down.

> [!IMPORTANT]
> The `Microsoft.Extensions.Hosting` NuGet package provides the types used in this article.

:::code language="csharp" source="snippets/overview/Program.cs" highlight="3-6" id="All":::

In the preceding code example, the highlighted lines:

- Create a host app builder instance.
- Configure the services by registering the `Worker` as a [hosted service](../workers.md) and the `IMessageWriter` interface as a singleton service with a corresponding implementation of the `MessageWriter` class.
- Build the host and run it.

The host contains the dependency injection service provider. It also contains all the other relevant services required to automatically instantiate the `Worker` and provide the corresponding `IMessageWriter` implementation as an argument.

By using the DI pattern, the worker service doesn't use the concrete type `MessageWriter`, only the `IMessageWriter` interface that it implements. This design makes it easy to change the implementation that the worker service uses without modifying the worker service. The worker service also doesn't *create an instance* of `MessageWriter`. The DI container creates the instance.

Now, imagine you want to switch out `MessageWriter` with a type that uses the [framework-provided logging service](service-registration.md#framework-provided-services). Create a class `LoggingMessageWriter` that depends on <xref:Microsoft.Extensions.Logging.ILogger`1> by requesting it in the constructor.

:::code language="csharp" source="snippets/overview/LoggingMessageWriter.cs":::

To switch from `MessageWriter` to `LoggingMessageWriter`, simply update the call to `AddSingleton` to register this new `IMessageWriter` implementation:

```csharp
builder.Services.AddSingleton<IMessageWriter, LoggingMessageWriter>();
```

> [!TIP]
> The container resolves `ILogger<TCategoryName>` by taking advantage of [(generic) open types](/dotnet/csharp/language-reference/language-specification/types#843-open-and-closed-types), which eliminates the need to register every [(generic) constructed type](/dotnet/csharp/language-reference/language-specification/types#84-constructed-types).

## Constructor injection behavior

Services can be resolved using <xref:System.IServiceProvider> (the built-in service container) or <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities>. `ActivatorUtilities` creates objects that aren't registered in the container and is used with some framework features.

Constructors can accept arguments that aren't provided by dependency injection, but the arguments must assign default values.

When `IServiceProvider` or `ActivatorUtilities` resolve services, constructor injection requires a *public* constructor.

When `ActivatorUtilities` resolves services, constructor injection requires that only one applicable constructor exists. Constructor overloads are supported, but only one overload can exist whose arguments can all be fulfilled by dependency injection.

## Constructor selection rules

When a type defines more than one constructor, the service provider has logic for determining which constructor to use. The constructor with the most parameters where the types are DI-resolvable is selected. Consider the following example service:

```csharp
public class ExampleService
{
    public ExampleService()
    {
    }

    public ExampleService(ILogger<ExampleService> logger)
    {
        // ...
    }

    public ExampleService(ServiceA serviceA, ServiceB serviceB)
    {
        // ...
    }
}
```

In the preceding code, assume that logging has been added and is resolvable from the service provider but the `ServiceA` and `ServiceB` types aren't. The constructor with the `ILogger<ExampleService>` parameter resolves the `ExampleService` instance. Even though there's a constructor that defines more parameters, the `ServiceA` and `ServiceB` types aren't DI-resolvable.

If there's ambiguity when discovering constructors, an exception is thrown. Consider the following C# example service:

> [!WARNING]
> This `ExampleService` code with ambiguous DI-resolvable type parameters throws an exception. **Don't** do this&mdash;it's intended to show what is meant by "ambiguous DI-resolvable types".

```csharp
public class ExampleService
{
    public ExampleService()
    {
    }

    public ExampleService(ILogger<ExampleService> logger)
    {
        // ...
    }

    public ExampleService(IOptions<ExampleOptions> options)
    {
        // ...
    }
}
```

In the preceding example, there are three constructors. The first constructor is parameterless and requires no services from the service provider. Assume that both logging and options have been added to the DI container and are DI-resolvable services. When the DI container attempts to resolve the `ExampleService` type, it throws an exception, as the two constructors are ambiguous.

Avoid ambiguity by defining a constructor that accepts both DI-resolvable types instead:

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
        // ...
    }
}
```

## Scope validation

[Scoped services](service-lifetimes.md#scoped) are disposed by the container that created them. If a scoped service is created in the root container, the service's lifetime is effectively promoted to [singleton](service-lifetimes.md#singleton) because it's only disposed by the root container when the app shuts down. Validating service scopes catches these situations when `BuildServiceProvider` is called.

When an app runs in the development environment and calls [CreateApplicationBuilder](../generic-host.md#host-builder-settings) to build the host, the default service provider performs checks to verify that:

- Scoped services aren't resolved from the root service provider.
- Scoped services aren't injected into singletons.

## Scope scenarios

The <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory> is always registered as a singleton, but the <xref:System.IServiceProvider> can vary based on the lifetime of the containing class. For example, if you resolve services from a scope, and any of those services take an <xref:System.IServiceProvider>, it's a scoped instance.

To achieve scoping services within implementations of <xref:Microsoft.Extensions.Hosting.IHostedService>, such as the <xref:Microsoft.Extensions.Hosting.BackgroundService>, *don't* inject the service dependencies via constructor injection. Instead, inject <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory>, create a scope, then resolve dependencies from the scope to use the appropriate service lifetime.

:::code language="csharp" source="../snippets/configuration/worker-scope/Worker.cs":::

In the preceding code, while the app is running, the background service:

- Depends on the <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory>.
- Creates an <xref:Microsoft.Extensions.DependencyInjection.IServiceScope> for resolving other services.
- Resolves scoped services for consumption.
- Works on processing objects and then relaying them, and finally marks them as processed.

From the sample source code, you can see how implementations of <xref:Microsoft.Extensions.Hosting.IHostedService> can benefit from scoped service lifetimes.

## Keyed services

You can register services and perform lookups based on a key. In other words, it's possible to register multiple services with different keys and use this key for the lookup.

For example, consider the case where you have different implementations of the interface `IMessageWriter`: `MemoryMessageWriter` and `QueueMessageWriter`.

You can register these services using the overload of the service registration methods (seen earlier) that supports a key as a parameter:

```csharp
services.AddKeyedSingleton<IMessageWriter, MemoryMessageWriter>("memory");
services.AddKeyedSingleton<IMessageWriter, QueueMessageWriter>("queue");
```

The `key` isn't limited to `string`. The `key` can be any `object` you want, as long as the type correctly implements `Equals`.

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

### KeyedService.AnyKey property

The <xref:Microsoft.Extensions.DependencyInjection.KeyedService.AnyKey?displayProperty=nameWithType> property provides a special key for working with keyed services.

#### Service registration

You can register a service using `KeyedService.AnyKey` as a fallback that matches any key. This is useful when you want to provide a default implementation for any key that doesn't have an explicit registration.

:::code language="csharp" source="snippets/anykey/Program.cs" id="FallbackRegistration":::

In the preceding example:

- Requesting `ICache` with key `"premium"` returns the `PremiumCache` instance.
- Requesting `ICache` with any other key (like `"basic"` or `"standard"`) creates a new `DefaultCache` using the `AnyKey` fallback.

#### Query for services

You can query for all services that were registered *using a specific key* (that is, not with `KeyedService.AnyKey`), by passing `KeyedService.AnyKey` to <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderKeyedServiceExtensions.GetKeyedServices``1(System.IServiceProvider,System.Object)>.

:::code language="csharp" source="snippets/anykey/Program.cs" id="AnyKeyQuery":::

In the preceding example, calling `GetKeyedServices<T>(KeyedService.AnyKey)` returns only the `PremiumCache` instance since it's the only cache that was registered using a specific key in the [service registration](#service-registration) code example.

> [!IMPORTANT]
> Starting in .NET 10, calling `GetKeyedService()` (singular) with `KeyedService.AnyKey` throws an <xref:System.InvalidOperationException> because `AnyKey` shouldn't be used to resolve a single service. For more information, see [Fix issues in GetKeyedService() and GetKeyedServices() with AnyKey](../../compatibility/extensions/10.0/getkeyedservice-anykey.md).

## See also

- [Quickstart: Dependency injection basics](basics.md)
- [Tutorial: Use dependency injection in .NET](usage.md)
- [Dependency injection guidelines](guidelines.md)
- [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection)
- [NDC Conference Patterns for DI app development](https://www.youtube.com/watch?v=x-C-CNBVTaY)
- [Explicit dependencies principle](../../../architecture/modern-web-apps-azure/architectural-principles.md#explicit-dependencies)
- [Inversion of control containers and the dependency injection pattern (Martin Fowler)](https://www.martinfowler.com/articles/injection.html)
