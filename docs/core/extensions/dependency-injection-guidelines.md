---
title: Dependency injection guidelines
description: Learn various dependency injection guidelines and best practices for .NET application development.
author: IEvangelist
ms.author: dapine
ms.date: 11/12/2021
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

The preceding disposable is intended to have a transient lifetime.

:::code language="csharp" source="snippets/configuration/console-di-disposable/ScopedDisposable.cs":::

The preceding disposable is intended to have a scoped lifetime.

:::code language="csharp" source="snippets/configuration/console-di-disposable/SingletonDisposable.cs":::

The preceding disposable is intended to have a singleton lifetime.

:::code language="csharp" source="snippets/configuration/console-di-disposable/Program.cs" range="1-20,42-60":::

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

### IDisposable guidance for transient and shared instances

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

For more information on resource cleanup, see [Implement a `Dispose` method](../../standard/garbage-collection/implementing-dispose.md), or [Implement a `DisposeAsync` method](../../standard/garbage-collection/implementing-disposeasync.md). Additionally, consider the [Disposable transient services captured by container](#disposable-transient-services-captured-by-container) scenario as it relates to resource cleanup.

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
- [Simple Injector](https://docs.simpleinjector.org/en/latest/aspnetintegration.html)

## Thread safety

Create thread-safe singleton services. If a singleton service has a dependency on a transient service, the transient service may also require thread safety depending on how it's used by the singleton.

The factory method of a singleton service, such as the second argument to [AddSingleton\<TService>(IServiceCollection, Func\<IServiceProvider,TService>)](xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A), doesn't need to be thread-safe. Like a type (`static`) constructor, it's guaranteed to be called only once by a single thread.

## Recommendations

- `async/await` and `Task` based service resolution isn't supported. Because C# doesn't support asynchronous constructors, use asynchronous methods after synchronously resolving the service.
- Avoid storing data and configuration directly in the service container. For example, a user's shopping cart shouldn't typically be added to the service container. Configuration should use the options pattern. Similarly, avoid "data holder" objects that only exist to allow access to another object. It's better to request the actual item via DI.
- Avoid static access to services. For example, avoid capturing [IApplicationBuilder.ApplicationServices](xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.ApplicationServices) as a static field or property for use elsewhere.
- Keep [DI factories](#async-di-factories-can-cause-deadlocks) fast and synchronous.
- Avoid using the [*service locator pattern*](#scoped-service-as-singleton). For example, don't invoke <xref:System.IServiceProvider.GetService%2A> to obtain a service instance when you can use DI instead.
- Another service locator variation to avoid is injecting a factory that resolves dependencies at run time. Both of these practices mix [Inversion of Control](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#dependency-inversion) strategies.
- Avoid calls to <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> in `ConfigureServices`. Calling `BuildServiceProvider` typically happens when the developer wants to resolve a service in `ConfigureServices`.
- [Disposable transient services are captured](#disposable-transient-services-captured-by-container) by the container for disposal. This can turn into a memory leak if resolved from the top-level container.
- Enable scope validation to make sure the app doesn't have singletons that capture scoped services. For more information, see [Scope validation](dependency-injection.md#scope-validation).

Like all sets of recommendations, you may encounter situations where ignoring a recommendation is required. Exceptions are rare, mostly special cases within the framework itself.

DI is an *alternative* to static/global object access patterns. You may not be able to realize the benefits of DI if you mix it with static object access.

## Example anti-patterns

In addition to the guidelines in this article, there are several anti-patterns *you **should** avoid*. Some of these anti-patterns are learnings from developing the runtimes themselves.

> [!WARNING]
> These are example anti-patterns, *do not* copy the code, *do not* use these patterns, and avoid these patterns at all costs.

### Disposable transient services captured by container

When you register *Transient* services that implement <xref:System.IDisposable>, by default the DI container will hold onto these references, and not <xref:System.IDisposable.Dispose> of them until the container is disposed when application stops if they were resolved from the container, or until the scope is disposed if they were resolved from a scope. This can turn into a memory leak if resolved from container level.

:::code language="csharp" source="snippets/configuration/di-anti-patterns/Program.cs" id="TransientDisposable":::

In the preceding anti-pattern, 1,000 `ExampleDisposable` objects are instantiated and rooted. They will not be disposed of until the `serviceProvider` instance is disposed.

For more information on debugging memory leaks, see [Debug a memory leak in .NET](../diagnostics/debug-memory-leak.md).

### Async DI factories can cause deadlocks

The term "DI factories" refers to the overload methods that exist when calling `Add{LIFETIME}`. There are overloads accepting a `Func<IServiceProvider, T>` where `T` is the service being registered, and the parameter is named `implementationFactory`. The `implementationFactory` can be provided as a lambda expression, local function, or method. If the factory is asynchronous, and you use <xref:System.Threading.Tasks.Task%601.Result?displayProperty=nameWithType>, this will cause a deadlock.

:::code language="csharp" source="snippets/configuration/di-anti-patterns/Program.cs" id="AsyncDeadlockOne" highlight="4-8":::

In the preceding code, the `implementationFactory` is given a lambda expression where the body calls <xref:System.Threading.Tasks.Task%601.Result?displayProperty=nameWithType> on a `Task<Bar>` returning method. This ***causes a deadlock***. The `GetBarAsync` method simply emulates an asynchronous work operation with <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType>, and then calls <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%60%601(System.IServiceProvider)>.

:::code language="csharp" source="snippets/configuration/di-anti-patterns/Program.cs" id="AsyncDeadlockTwo":::

For more information on asynchronous guidance, see [Asynchronous programming: Important info and advice](../../csharp/async.md#important-info-and-advice). For more information debugging deadlocks, see [Debug a deadlock in .NET](../diagnostics/debug-deadlock.md).

When you're running this anti-pattern and the deadlock occurs, you can view the two threads waiting from Visual Studio's Parallel Stacks window. For more information, see [View threads and tasks in the Parallel Stacks window](/visualstudio/debugger/using-the-parallel-stacks-window).

### Captive dependency

The term ["captive dependency"](https://blog.ploeh.dk/2014/06/02/captive-dependency) was coined by [Mark Seemann](https://blog.ploeh.dk/about), and refers to the misconfiguration of service lifetimes, where a longer-lived service holds a shorter-lived service captive.

:::code language="csharp" source="snippets/configuration/di-anti-patterns/Program.cs" id="CaptiveDependency":::

In the preceding code, `Foo` is registered as a singleton and `Bar` is scoped - which on the surface seems valid. However, consider the implementation of `Foo`.

:::code language="csharp" source="snippets/configuration/di-anti-patterns/Foo.cs" highlight="5":::

The `Foo` object requires a `Bar` object, and since `Foo` is a singleton, and `Bar` is scoped - this is a misconfiguration. As is, `Foo` would only be instantiated once, and it would hold onto `Bar` for its lifetime, which is longer than the intended scoped lifetime of `Bar`. You should consider validating scopes, by passing `validateScopes: true` to the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Boolean)>. When you validate the scopes, you'd get an <xref:System.InvalidOperationException> with a message similar to "Cannot consume scoped service 'Bar' from singleton 'Foo'.".

For more information, see [Scope validation](dependency-injection.md#scope-validation).

### Scoped service as singleton

When using scoped services, if you're not creating a scope or within an existing scope - the service becomes a singleton.

:::code language="csharp" source="snippets/configuration/di-anti-patterns/Program.cs" id="ScopedServiceBecomesSingleton" highlight="13-14":::

In the preceding code, `Bar` is retrieved within an <xref:Microsoft.Extensions.DependencyInjection.IServiceScope>, which is correct. The anti-pattern is the retrieval of `Bar` outside of the scope, and the variable is named `avoid` to show which example retrieval is incorrect.

## See also

- [Dependency injection in .NET](dependency-injection.md)
- [Tutorial: Use dependency injection in .NET](dependency-injection-usage.md)
