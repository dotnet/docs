---
title: Dependency injection guidelines
description: Learn various dependency injection guidelines and best practices for .NET application development.
author: IEvangelist
ms.author: dapine
ms.date: 09/23/2020
ms.topic: guide
---

# Dependency injection guidelines

This article provides general guidelines and best practices for implementing dependency injection in .NET applications.

## Design services for dependency injection

When designing services for dependency injection:

- Avoid stateful, static classes and members. Avoid creating global state by designing apps to use singleton services instead.
- Avoid direct instantiation of dependent classes within services. Direct instantiation couples the code to a particular implementation.
- Make services small, well-factored, and easily tested.

If a class has many injected dependencies, it might be a sign that the class has too many responsibilities and violates the [Single Responsibility Principle (SRP)](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#single-responsibility). Attempt to refactor the class by moving some of its responsibilities into new classes.

### Disposal of services

The container is responsible for cleanup of types it creates, and calls <xref:System.IDisposable.Dispose%2A> on <xref:System.IDisposable> instances. Services resolved from the container should never be disposed by the developer. If a type or factory is registered as a singleton, the container disposes the singleton automatically.

In the following example, the services are created by the service container and disposed automatically:

:::code language="csharp" source="snippets/configuration/console-di-disposable/TransientDisposable.cs":::

:::code language="csharp" source="snippets/configuration/console-di-disposable/ScopedDisposable.cs":::

:::code language="csharp" source="snippets/configuration/console-di-disposable/SingletonDisposable.cs":::

:::code language="csharp" source="snippets/configuration/console-di-disposable/Program.cs" range="1-21,41-60":::

The debug console shows the following sample output after running:

```console
Scope 1...
ScopedDisposable.Dispose()
TransientDisposable.Dispose()

Scope 2...
ScopedDisposable.Dispose()
TransientDisposable.Dispose()

info: Microsoft.Hosting.Lifetime[0]
      Application started.Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
     Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
     Content root path: .\configuration\console-di-disposable\bin\Debug\net5.0
info: Microsoft.Hosting.Lifetime[0]
     Application is shutting down...
SingletonDisposable.Dispose()
```

### Services not created by the service container

Consider the following code:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton(new ExampleService());

    // ...
}
```

In the preceding code:

- The `ExampleService` instance is **not** created by the service container.
- The framework does **not** dispose of the services automatically.
- The developer is responsible for disposing the services.

### IDisposable guidance for Transient and shared instances

#### Transient, limited lifetime

**Scenario**

The app requires an <xref:System.IDisposable> instance with a transient lifetime for either of the following scenarios:

- The instance is resolved in the root scope (root container).
- The instance should be disposed before the scope ends.

**Solution**

Use the factory pattern to create an instance outside of the parent scope. In this situation, the app would generally have a `Create` method that calls the final type's constructor directly. If the final type has other dependencies, the factory can:

- Receive an <xref:System.IServiceProvider> in its constructor.
- Use <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> to instantiate the instance outside of the container, while using the container for its dependencies.

#### Shared instance, limited lifetime

**Scenario**

The app requires a shared <xref:System.IDisposable> instance across multiple services, but the <xref:System.IDisposable> instance should have a limited lifetime.

**Solution**

Register the instance with a scoped lifetime. Use <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory.CreateScope%2A?displayProperty=nameWithType> to create a new <xref:Microsoft.Extensions.DependencyInjection.IServiceScope>. Use the scope's <xref:System.IServiceProvider> to get required services. Dispose the scope when it's no longer needed.

#### General `IDisposable` guidelines

- Don't register <xref:System.IDisposable> instances with a transient lifetime. Use the factory pattern instead.
- Don't resolve <xref:System.IDisposable> instances with a transient or scoped lifetime in the root scope. The only exception to this is if the app creates/recreates and disposes <xref:System.IServiceProvider>, but this isn't an ideal pattern.
- Receiving an <xref:System.IDisposable> dependency via DI doesn't require that the receiver implement <xref:System.IDisposable> itself. The receiver of the <xref:System.IDisposable> dependency shouldn't call <xref:System.IDisposable.Dispose%2A> on that dependency.
- Use scopes to control the lifetimes of services. Scopes aren't hierarchical, and there's no special connection among scopes.

For more information on resource cleanup, see [Implement a Dispose method](../../standard/garbage-collection/implementing-dispose.md)

## Default service container replacement

The built-in service container is designed to serve the needs of the framework and most consumer apps. We recommend using the built-in container unless you need a specific feature that it doesn't support, such as:

- Property injection
- Injection based on name
- Child containers
- Custom lifetime management
- `Func<T>` support for lazy initialization
- Convention-based registration

The following third-party containers can be used with ASP.NET Core apps:

- [Autofac](https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html)
- [DryIoc](https://www.nuget.org/packages/DryIoc.Microsoft.DependencyInjection)
- [Grace](https://www.nuget.org/packages/Grace.DependencyInjection.Extensions)
- [LightInject](https://github.com/seesharper/LightInject.Microsoft.DependencyInjection)
- [Lamar](https://jasperfx.github.io/lamar/)
- [Stashbox](https://github.com/z4kn4fein/stashbox-extensions-dependencyinjection)
- [Unity](https://www.nuget.org/packages/Unity.Microsoft.DependencyInjection)

## Thread safety

Create thread-safe singleton services. If a singleton service has a dependency on a transient service, the transient service may also require thread safety depending on how it's used by the singleton.

The factory method of single service, such as the second argument to [AddSingleton\<TService>(IServiceCollection, Func\<IServiceProvider,TService>)](xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A), doesn't need to be thread-safe. Like a type (`static`) constructor, it's guaranteed to be called only once by a single thread.

## Recommendations

- `async/await` and `Task` based service resolution isn't supported. Because C# doesn't support asynchronous constructors, use asynchronous methods after synchronously resolving the service.
- Avoid storing data and configuration directly in the service container. For example, a user's shopping cart shouldn't typically be added to the service container. Configuration should use the options pattern. Similarly, avoid "data holder" objects that only exist to allow access to another object. It's better to request the actual item via DI.
- Avoid static access to services. For example, avoid capturing [IApplicationBuilder.ApplicationServices](xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.ApplicationServices) as a static field or property for use elsewhere.
- Keep DI factories fast and synchronous.
- Avoid using the *service locator pattern*. For example, don't invoke <xref:System.IServiceProvider.GetService%2A> to obtain a service instance when you can use DI instead.
- Another service locator variation to avoid is injecting a factory that resolves dependencies at runtime. Both of these practices mix [Inversion of Control](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#dependency-inversion) strategies.
- Avoid calls to <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> in `ConfigureServices`. Calling `BuildServiceProvider` typically happens when the developer wants to resolve a service in `ConfigureServices`.
- Disposable transient services are captured by the container for disposal. This can turn into a memory leak if resolved from the top-level container.
- Enable scope validation to make sure the app doesn't have singletons that capture scoped services. For more information, see [Scope validation](dependency-injection.md#scope-validation).

Like all sets of recommendations, you may encounter situations where ignoring a recommendation is required. Exceptions are rare, mostly special cases within the framework itself.

DI is an *alternative* to static/global object access patterns. You may not be able to realize the benefits of DI if you mix it with static object access.

## See also

- [Dependency injection in .NET](dependency-injection.md)
