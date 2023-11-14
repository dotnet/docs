---
title: Service discovery in .NET
description: Learn how to use the Microsoft.Extensions.ServiceDiscovery library to simplify the integration of service discovery patterns in .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 11/13/2023
ms.topic: overview
---

# Service discovery in .NET

In this article, you learn how to use the `Microsoft.Extensions.ServiceDiscovery` library. Service discovery is a way for developers to use logical names instead of physical addresses (IP address and port) to refer to external services.

## Get Started

To get started with service discovery in .NET, install the [Microsoft.Extensions.ServiceDiscovery](https://www.nuget.org/packages/Microsoft.Extensions.ServiceDiscovery) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.ServiceDiscovery --prerelease
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.ServiceDiscovery"
                  Version="[SelectVersion]" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Example usage

In the _Program.cs_ file of your project, call the `AddServiceDiscovery` extension method to add service discovery to the host, configuring default service endpoint resolvers:

```csharp
builder.Services.AddServiceDiscovery();
```

Add service discovery to an individual <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> by calling the `UseServiceDiscovery` extension method:

```csharp
builder.Services.AddHttpClient<CatalogServiceClient>(static client =>
    {
        client.BaseAddress = new("http://catalog");
    })
    .UseServiceDiscovery();
```

Alternatively, you can add service discovery to all <xref:System.Net.Http.HttpClient> instances by default:

```csharp
builder.Services.ConfigureHttpClientDefaults(static http =>
{
    // Turn on service discovery by default
    http.UseServiceDiscovery();
});
```

## Resolve service endpoints from configuration

The `AddServiceDiscovery` extension method adds a configuration-based endpoint resolver by default.
This resolver reads endpoints from the [.NET configuration system](configuration.md). The library supports configuration through _appsettings.json_, environment variables, or any other <xref:Microsoft.Extensions.Configuration.IConfiguration> source.

Here's an example demonstrating how to configure endpoints for the service named _catalog_ via `appsettings.json`:

```json
{
  "Services": {
      "catalog": [
        "localhost:8080",
        "10.46.24.90:80",
      ]
    }
}
```

The preceding example adds two endpoints for the service named _catalog_: `localhost:8080`, and `"10.46.24.90:80"`. Each time the _catalog_ is resolved, one of these endpoints will be selected.

If service discovery was added to the host using the `AddServiceDiscoveryCore` extension method on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>, the configuration-based endpoint resolver can be added by calling the `AddConfigurationServiceEndPointResolver` extension method on `IServiceCollection`.

### Configuration

The configuration resolver is configured using the `ConfigurationServiceEndPointResolverOptions` class, which offers these configuration options:

- **SectionName**: The name of the configuration section that contains service endpoints. It defaults to `"Services"`.

- **ApplyHostNameMetadata**: A delegate used to determine if host name metadata should be applied to resolved endpoints. It defaults to a function that returns `false`.

To configure these options, you can use the `Configure` extension method on the `IServiceCollection` within your application's `Startup` class or `Program` file:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConfigurationServiceEndPointResolverOptions>(
    static options =>
    {
        options.SectionName = "MyServiceEndpoints";
    
        // Configure the logic for applying host name metadata
        options.ApplyHostNameMetadata = endpoint =>
        {
            // Your custom logic here. For example:
            return endpoint.EndPoint is DnsEndPoint dnsEp
                && dnsEp.Host.StartsWith("internal");
        };
    });
```

The preceding example demonstrates setting a custom section name for your service endpoints and providing a custom logic for applying host name metadata based on a condition.

## Resolve service endpoints using platform-provided service discovery

Certain platforms, like Azure Container Apps and Kubernetes (when configured accordingly), offer service discovery capabilities without necessitating a service discovery client library. In cases where an application is deployed in such environments, using the platform's built-in functionality can be advantageous. The pass-through resolver is designed to facilitate this scenario. It enables the utilization of alternative resolvers, such as configuration, in different environments, such as a developer's machine. Importantly, this flexibility is achieved without the need for any code modifications or the implementation of conditional guards.

The pass-through resolver performs no external resolution and instead resolves endpoints by returning the input service name represented as a `DnsEndPoint`.

The pass-through provider is configured by-default when adding service discovery via the `AddServiceDiscovery` extension method.

If service discovery was added to the host using the `AddServiceDiscoveryCore` extension method on `IServiceCollection`, the pass-through provider can be added by calling the `AddPassThroughServiceEndPointResolver` extension method on `IServiceCollection`.

## Load-balancing with endpoint selectors

Each time an endpoint is resolved via the `HttpClient` pipeline, a single endpoint is selected from the set of all known endpoints for the requested service. If multiple endpoints are available, it may be desirable to balance traffic across all such endpoints. To accomplish this, a customizable _endpoint selector_ can be used. By default, endpoints are selected in round-robin order. To use a different endpoint selector, provide an `IServiceEndPointSelector` instance to the `UseServiceDiscovery` method call. For example, to select a random endpoint from the set of resolved endpoints, specify `RandomServiceEndPointSelector.Instance` as the endpoint selector:

```csharp
builder.Services.AddHttpClient<CatalogServiceClient>(
        static client => client.BaseAddress = new("http://catalog")
    )
    .UseServiceDiscovery(RandomServiceEndPointSelector.Instance);
```

The `Microsoft.Extensions.ServiceDiscovery` package includes the following endpoint selector providers:

- Pick-first, which always selects the first endpoint: `PickFirstServiceEndPointSelectorProvider.Instance`
- Round-robin, which cycles through endpoints: `RoundRobinServiceEndPointSelectorProvider.Instance`
- Random, which selects endpoints randomly: `RandomServiceEndPointSelectorProvider.Instance`
- Power-of-two-choices, which attempt to pick the least heavily loaded endpoint based on the _Power of Two Choices_ algorithm for distributed load balancing, degrading to randomly selecting an endpoint when either of the provided endpoints don't have the `IEndPointLoadFeature` feature: `PowerOfTwoChoicesServiceEndPointSelectorProvider.Instance`

Endpoint selectors are created via an `IServiceEndPointSelectorProvider` instance, such as the providers previously listed. The provider's `CreateSelector()` method is called to create a selector, which is an instance of `IServiceEndPointSelector`. The `IServiceEndPointSelector` instance is given the set of known endpoints when they're resolved, using the `SetEndPoints(ServiceEndPointCollection collection)` method. To choose an endpoint from the collection, the `GetEndPoint(object? context)` method is called, returning a single `ServiceEndPoint`. The `context` value passed to `GetEndPoint` is used to provide extra context that may be useful to the selector. For example, in the `HttpClient` case, the `HttpRequestMessage` is passed. None of the provided implementations of `IServiceEndPointSelector` inspect the context, and it can be ignored unless you're using a selector, which does make use of it.

### Resolution order

When service endpoints are being resolved, each registered resolver is called in the order of registration and given the opportunity to modify the collection of `ServiceEndPoint`s which are returned back to the caller. The providers included in the `Microsoft.Extensions.ServiceDiscovery` series of packages skip resolution if there are existing endpoints in the collection when they're called. For example, consider a case where the following providers are registered: _Configuration_, _DNS SRV_, _Pass-through_. When resolution occurs, the providers are called in-order. If the _Configuration_ providers discover no endpoints, the _DNS SRV_ provider performs resolution and may add one or more endpoints. If the _DNS SRV_ provider adds an endpoint to the collection, the _Pass-through_ provider skips its resolution and returns immediately instead.

## See also

- [Service discovery in .NET Aspire](/dotnet/aspire/service-discovery/overview.md)
