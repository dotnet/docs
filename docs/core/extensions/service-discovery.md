---
title: Service discovery in .NET
description: Learn how to use the Microsoft.Extensions.ServiceDiscovery library to simplify the integration of service discovery patterns in .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 04/10/2024
ms.topic: overview
---

# Service discovery in .NET

In this article, you learn how to use the `Microsoft.Extensions.ServiceDiscovery` library. Service discovery is a way for developers to use logical names instead of physical addresses (IP address and port) to refer to external services.

## Get started

To get started with service discovery in .NET, install the [Microsoft.Extensions.ServiceDiscovery](https://www.nuget.org/packages/Microsoft.Extensions.ServiceDiscovery) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet package add Microsoft.Extensions.ServiceDiscovery --prerelease
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.ServiceDiscovery"
                  Version="[SelectVersion]" />
```

---

For more information, see [dotnet package add](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Example usage

In the _Program.cs_ file of your project, call the <xref:Microsoft.Extensions.DependencyInjection.ServiceDiscoveryHttpClientBuilderExtensions.AddServiceDiscovery%2A> extension method to add service discovery to the host, configuring default service endpoint resolvers:

```csharp
builder.Services.AddServiceDiscovery();
```

Add service discovery to an individual <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> by calling the `AddServiceDiscovery` extension method:

```csharp
builder.Services.AddHttpClient<CatalogServiceClient>(static client =>
    {
        client.BaseAddress = new("https://catalog");
    })
    .AddServiceDiscovery();
```

Alternatively, you can add service discovery to all <xref:System.Net.Http.HttpClient> instances by default:

```csharp
builder.Services.ConfigureHttpClientDefaults(static http =>
{
    // Turn on service discovery by default
    http.AddServiceDiscovery();
});
```

## Scheme selection when resolving HTTP(S) endpoints

It is common to use HTTP while developing and testing a service locally and HTTPS when the service is deployed. Service Discovery supports this by allowing for a priority list of URI schemes to be specified in the input string given to Service Discovery. Service Discovery will attempt to resolve the services for the schemes in order and will stop after an endpoint is found. URI schemes are separated by a `+` character, for example: `"https+http://basket"`. Service Discovery will first try to find HTTPS endpoints for the `"basket"` service and will then fall back to HTTP endpoints. If any HTTPS endpoint is found, Service Discovery will not include HTTP endpoints.

Schemes can be filtered by configuring the `AllowedSchemes` and `AllowAllSchemes` properties on `ServiceDiscoveryOptions`. The `AllowAllSchemes` property is used to indicate that all schemes are allowed. By default, `AllowAllSchemes` is `true` and all schemes are allowed. Schemes can be restricted by setting `AllowAllSchemes` to `false` and adding allowed schemes to the `AllowedSchemes` property. For example, to allow only HTTPS:

```csharp
services.Configure<ServiceDiscoveryOptions>(options =>
{
    options.AllowAllSchemes = false;
    options.AllowedSchemes = ["https"];
});
```

To explicitly allow all schemes, set the `ServiceDiscoveryOptions.AllowAllSchemes` property to `true`:

```csharp
services.Configure<ServiceDiscoveryOptions>(
    options => options.AllowAllSchemes = true);
```

## Resolve service endpoints from configuration

The `AddServiceDiscovery` extension method adds a configuration-based endpoint resolver by default.
This resolver reads endpoints from the [.NET configuration system](configuration.md). The library supports configuration through _appsettings.json_, environment variables, or any other <xref:Microsoft.Extensions.Configuration.IConfiguration> source.

Here's an example demonstrating how to configure endpoints for the service named _catalog_ via `appsettings.json`:

```json
{
  "Services": {
    "catalog": {
      "https": [
        "localhost:8080",
        "10.46.24.90:80"
      ]
    }
  }
}
```

The preceding example adds two endpoints for the service named _catalog_: `https://localhost:8080`, and `"https://10.46.24.90:80"`. Each time the _catalog_ is resolved, one of these endpoints is selected.

If service discovery was added to the host using the <xref:Microsoft.Extensions.DependencyInjection.ServiceDiscoveryServiceCollectionExtensions.AddServiceDiscoveryCore%2A> extension method on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>, the configuration-based endpoint resolver can be added by calling the <xref:Microsoft.Extensions.DependencyInjection.ServiceDiscoveryServiceCollectionExtensions.AddConfigurationServiceEndpointProvider%2A> extension method on `IServiceCollection`.

### Configuration

The configuration resolver is configured using the <xref:Microsoft.Extensions.ServiceDiscovery.ConfigurationServiceEndpointProviderOptions> class, which offers these configuration options:

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
        options.ApplyHostNameMetadata = static endpoint =>
        {
            // Your custom logic here. For example:
            return endpoint.EndPoint is DnsEndPoint dnsEp
                && dnsEp.Host.StartsWith("internal");
        };
    });
```

The preceding example demonstrates setting a custom section name for your service endpoints and providing custom conditional logic for applying host name metadata.

## Resolve service endpoints using platform-provided service discovery

Certain platforms, like Azure Container Apps and Kubernetes (when configured accordingly), offer service discovery capabilities without necessitating a service discovery client library. In cases where an application is deployed in such environments, using the platform's built-in functionality can be advantageous. The pass-through resolver is designed to facilitate this scenario. It enables the utilization of alternative resolvers, such as configuration, in different environments, such as a developer's machine. Importantly, this flexibility is achieved without the need for any code modifications or the implementation of conditional guards.

The pass-through resolver performs no external resolution and instead resolves endpoints by returning the input service name represented as a <xref:System.Net.DnsEndPoint>.

The pass-through provider is configured by-default when adding service discovery via the `AddServiceDiscovery` extension method.

If service discovery was added to the host using the `AddServiceDiscoveryCore` extension method on `IServiceCollection`, the pass-through provider can be added by calling the <xref:Microsoft.Extensions.DependencyInjection.ServiceDiscoveryServiceCollectionExtensions.AddPassThroughServiceEndpointProvider%2A> extension method on `IServiceCollection`.

## See also

- [Service discovery in .NET Aspire](/dotnet/aspire/service-discovery/overview)
