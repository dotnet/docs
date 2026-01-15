---
title: Service lifetimes (dependency injection)
description: "Learn about the three different services lifetimes in dependency injection in .NET: transient, scoped, and singleton."
ms.date: 10/21/2025
---

# Service lifetimes

Services can be registered with a [transient](#transient), [scoped](#scoped), or [singleton](#singleton) lifetime. Choose an appropriate lifetime for each registered service.

## Transient

Transient-lifetime services are created each time they're requested from the service container. To register a service as _transient_, call <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient%2A>.

In apps that process requests, transient services are disposed at the end of the request. This lifetime incurs per-request allocations, as services are resolved and constructed every time. For more information, see [IDisposable guidance for transient and shared instances](guidelines.md#idisposable-guidance-for-transient-and-shared-instances).

## Scoped

For web applications, a scoped lifetime indicates that services are created once per client request (connection). Register scoped services with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped%2A>.

In apps that process requests, scoped services are disposed at the end of the request.

> [!NOTE]
> When using Entity Framework Core, the <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> extension method registers `DbContext` types with a scoped lifetime by default.

A scoped service should always be used from within a scope—either an implicit scope (such as ASP.NET Core's per-request scope) or an explicit scope created with <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory.CreateScope?displayProperty=nameWithType>.

Do **_not_** resolve a scoped service directly from a singleton using constructor injection or by requesting it from <xref:System.IServiceProvider> in the singleton. Doing so causes the scoped service to behave like a singleton, which can lead to incorrect state when processing subsequent requests.

It's acceptable to resolve a scoped service within a singleton if you create and use an explicit scope with <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory>.

It's also fine to:

- Resolve a singleton service from a scoped or transient service.
- Resolve a scoped service from another scoped or transient service.

By default, in the development environment, resolving a service from another service with a longer lifetime throws an exception. For more information, see [Scope validation](overview.md#scope-validation).

## Singleton

Singleton lifetime services are created either:

- The first time they're requested.
- By the developer, when providing an implementation instance directly to the container. This approach is rarely needed.

Every subsequent request of the service implementation from the dependency injection container uses the same instance. If the app requires singleton behavior, allow the service container to manage the service's lifetime. Don't implement the singleton design pattern and provide code to dispose of the singleton. Services should never be disposed by code that resolved the service from the container. If a type or factory is registered as a singleton, the container disposes the singleton automatically.

Register singleton services with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A>. Singleton services must be thread safe and are often used in stateless services.

In apps that process requests, singleton services are disposed when the <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> is disposed on application shutdown. Because memory isn't released until the app shuts down, consider memory use with a singleton service.
