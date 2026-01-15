---
title: Service registration (dependency injection)
description: Learn how to register services for dependency injection using different methods for different scenarios.
ms.date: 10/21/2025
---

# Service registration (dependency injection)

This article discusses registering groups of services and framework-provided services. It also provides details about the service-registration extension methods that .NET provides.

## Register groups of services with extension methods

.NET uses a convention for registering a group of related services. The convention is to use a single `Add{GROUP_NAME}` extension method to register all of the services required by a framework feature. For example, the <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions%2A> extension method registers all of the services required for using options.

## Framework-provided services

When using any of the available host or app builder patterns, defaults are applied and services are registered by the framework. Consider some of the most popular host and app builder patterns:

- <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.CreateDefault%2A?displayProperty=nameWithType>
- <xref:Microsoft.Maui.Hosting.MauiApp.CreateBuilder%2A?displayProperty=nameWithType>

After creating a builder from any of these APIs, the `IServiceCollection` has services defined by the framework, depending on [how you configured the host](../generic-host.md#host-configuration). For apps based on the .NET templates, the framework could register hundreds of services.

The following table lists a small sample of these framework-registered services:

| Service type                                                                       | Lifetime  |
|------------------------------------------------------------------------------------|-----------|
| <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory?displayProperty=fullName> | Singleton |
| <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime>                       | Singleton |
| <xref:Microsoft.Extensions.Logging.ILogger`1?displayProperty=fullName>             | Singleton |
| <xref:Microsoft.Extensions.Logging.ILoggerFactory?displayProperty=fullName>        | Singleton |
| <xref:Microsoft.Extensions.ObjectPool.ObjectPoolProvider?displayProperty=fullName> | Singleton |
| <xref:Microsoft.Extensions.Options.IConfigureOptions`1?displayProperty=fullName>   | Transient |
| <xref:Microsoft.Extensions.Options.IOptions`1?displayProperty=fullName>            | Singleton |
| <xref:System.Diagnostics.DiagnosticListener?displayProperty=fullName>              | Singleton |
| <xref:System.Diagnostics.DiagnosticSource?displayProperty=fullName>                | Singleton |

## Registration extension methods

The framework provides service-registration extension methods that are useful in specific scenarios:

| Method | Automatic<br>object<br>disposal | Multiple<br>implementations | Pass args |
|--------|:-------------------------------:|:---------------------------:|:---------:|
| `Add{LIFETIME}<{SERVICE}, {IMPLEMENTATION}>()`<br><br>Example:<br><br>`services.AddSingleton<IMyDep, MyDep>();` | Yes                             | Yes                         | No        |
| `Add{LIFETIME}<{SERVICE}>(sp => new {IMPLEMENTATION})`<br><br>Examples:<br><br>`services.AddSingleton<IMyDep>(sp => new MyDep());`<br>`services.AddSingleton<IMyDep>(sp => new MyDep(99));` | Yes | Yes | Yes |
| `Add{LIFETIME}<{IMPLEMENTATION}>()`<br><br>Example:<br><br>`services.AddSingleton<MyDep>();` | Yes | No | No |
| `AddSingleton<{SERVICE}>(new {IMPLEMENTATION})`<br><br>Examples:<br><br>`services.AddSingleton<IMyDep>(new MyDep());`<br>`services.AddSingleton<IMyDep>(new MyDep(99));` | No | Yes | Yes |
| `AddSingleton(new {IMPLEMENTATION})`<br><br>Examples:<br><br>`services.AddSingleton(new MyDep());`<br>`services.AddSingleton(new MyDep(99));` | No | No | Yes |

For more information on type disposal, see the [Disposal of services](guidelines.md#disposal-of-services) section.

Registering a service with only an implementation type is equivalent to registering that service with the same implementation and service type. For example, consider the following code:

```csharp
services.AddSingleton<ExampleService>();
```

This is equivalent to registering the service with both the service and implementation of the same types:

```csharp
services.AddSingleton<ExampleService, ExampleService>();
```

This equivalency is why multiple implementations of a service can't be registered using the methods that don't take an explicit service type. These methods can register multiple *instances* of a service, but they all have the same *implementation* type.

Any of the service registration methods can be used to register multiple service instances of the same service type. In the following example, `AddSingleton` is called twice with `IMessageWriter` as the service type. The second call to `AddSingleton` overrides the previous one when resolved as `IMessageWriter` and adds to the previous one when multiple services are resolved via `IEnumerable<IMessageWriter>`. Services appear in the order they were registered when resolved via `IEnumerable<{SERVICE}>`.

:::code language="csharp" source="snippets/configuration/console-di-ienumerable/Program.cs" highlight="11-16":::

The preceding sample source code registers two implementations of the `IMessageWriter`.

:::code language="csharp" source="snippets/configuration/console-di-ienumerable/ExampleService.cs" highlight="7-16":::

The `ExampleService` defines two constructor parameters; a single `IMessageWriter`, and an `IEnumerable<IMessageWriter>`. The single `IMessageWriter` is the last implementation to be registered, whereas the `IEnumerable<IMessageWriter>` represents all registered implementations.

The framework also provides `TryAdd{LIFETIME}` extension methods, which register the service only if there isn't already an implementation registered.

In the following example, the call to `AddSingleton` registers `ConsoleMessageWriter` as an implementation for `IMessageWriter`. The call to `TryAddSingleton` has no effect because `IMessageWriter` already has a registered implementation:

```csharp
services.AddSingleton<IMessageWriter, ConsoleMessageWriter>();
services.TryAddSingleton<IMessageWriter, LoggingMessageWriter>();
```

The `TryAddSingleton` has no effect, as it was already added and the "try" fails. The `ExampleService` asserts the following:

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

The [TryAddEnumerable(ServiceDescriptor)](xref:Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddEnumerable%2A) methods register the service only if there isn't already an implementation *of the same type*. Multiple services are resolved via `IEnumerable<{SERVICE}>`. When registering services, add an instance if one of the same types wasn't already added. Library authors use `TryAddEnumerable` to avoid registering multiple copies of an implementation in the container.

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

Service registration is order-independent except when registering multiple implementations of the same type.

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
