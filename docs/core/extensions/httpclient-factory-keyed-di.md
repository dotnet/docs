---
title: Keyed DI Support in IHttpClientFactory
description: Learn how to integrate IHttpClientFactory with Keyed Services.
author: CarnaViire
ms.author: knatalia
ms.date: 01/27/2025
ms.topic: article
---

# Keyed DI support in `IHttpClientFactory`

In this article, you learn how to integrate `IHttpClientFactory` with Keyed Services.

[_Keyed Services_](dependency-injection.md#keyed-services) (also called _Keyed DI_) is a dependency injection (DI) feature that allows you to conveniently operate with multiple implementations of a single service. Upon registration, you can associate different _service keys_ with the specific implementations. At run time, this key is used in lookup in combination with a service type, which means you can retrieve a specific implementation by passing the matching key. For more information on Keyed Services, and DI in general, see [.NET dependency injection][di].

For an overview on how to use `IHttpClientFactory` in your .NET application, see [IHttpClientFactory with .NET][hcf].

## Background

`IHttpClientFactory` and Named `HttpClient` instances, unsurprisingly, align well with the Keyed Services idea. Historically, among other things, `IHttpClientFactory` was a way to overcome this long-missing DI feature. But plain Named clients require you to obtain, store, and query the `IHttpClientFactory` instance&mdash;instead of injecting a configured `HttpClient`&mdash;which might be inconvenient. While Typed clients attempt to simplify that part, it comes with a catch: Typed clients are easy to [misconfigure](httpclient-factory-troubleshooting.md#typed-client-has-the-wrong-httpclient-injected) and [misuse](httpclient-factory.md#avoid-typed-clients-in-singleton-services), and the supporting infrastructure can also be a tangible overhead in certain scenarios (for example, on mobile platforms).

Starting from .NET 9 (`Microsoft.Extensions.Http` and `Microsoft.Extensions.DependencyInjection` packages version `9.0.0+`), `IHttpClientFactory` can leverage Keyed DI directly, introducing a new "Keyed DI approach" (as opposed to "Named" and "Typed" approaches). "Keyed DI approach" pairs the convenient, highly configurable `HttpClient` registrations with the straightforward injection of the specific configured `HttpClient` instances.

## Basic Usage

As of .NET 9, you need to _opt in_ to the feature by calling the <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddAsKeyed%2A> extension method. If opted in, the Named client applying the configuration is added to the DI container as a Keyed `HttpClient` service, using the client's name as a service key, so you can use the standard Keyed Services APIs (for example, <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute>) to obtain the desired Named `HttpClient` instances (created and configured by `IHttpClientFactory`). By default, the clients are registered with _Scoped_ lifetime.

The following code illustrates the integration between `IHttpClientFactory`, Keyed DI, and ASP.NET Core 9.0 Minimal APIs:

:::code source="snippets/http/keyedservices/Program.cs" highlight="4,10,16":::

Endpoint response:

```sh
> ~  curl http://localhost:5000/
{"name":"runtime","url":"https://api.github.com/repos/dotnet/runtime"}
```

In the example, the configured `HttpClient` is injected into the request handler through the standard Keyed DI infrastructure, which is integrated into ASP.NET Core parameter binding. For more information on Keyed Services in ASP.NET Core, see [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection#keyed-services).

## Comparison of Keyed, Named, and Typed approaches

Consider only the `IHttpClientFactory`-related code from the [Basic Usage](#basic-usage) example:

```csharp
services.AddHttpClient("github", /* ... */).AddAsKeyed();                // (1)

app.MapGet("/", ([FromKeyedServices("github")] HttpClient httpClient) => // (2)
    //httpClient.Get....                                                 // (3)
```

This code snippet illustrates how the registration `(1)`, obtaining the configured `HttpClient` instance `(2)`, and using the obtained client instance as needed `(3)` can look when using the _Keyed DI approach_.

Compare how the same steps are achieved with the two "older" approaches.

First, with the _Named approach_:

```csharp
services.AddHttpClient("github", /* ... */);                          // (1)

app.MapGet("/github", (IHttpClientFactory httpClientFactory) =>
{
    HttpClient httpClient = httpClientFactory.CreateClient("github"); // (2)
    //return httpClient.Get....                                       // (3)
});
```

Second, with the _Typed approach_:

```csharp
services.AddHttpClient<GitHubClient>(/* ... */);          // (1)

app.MapGet("/github", (GitHubClient gitHubClient) =>
    gitHubClient.GetRepoAsync());

public class GitHubClient(HttpClient httpClient)          // (2)
{
    private readonly HttpClient _httpClient = httpClient;

    public Task<Repo> GetRepoAsync() =>
        //_httpClient.Get....                             // (3)
}
```

Out of the three, the Keyed DI approach offers the most succinct way to achieve the same behavior.

## Built-in DI container validation

If you enabled the Keyed registration for a specific Named client, you can access it with any existing Keyed DI APIs. But if you erroneously try to use a name that isn't enabled yet, you get the standard Keyed DI exception:

```csharp
services.AddHttpClient("keyed").AddAsKeyed();
services.AddHttpClient("not-keyed");

provider.GetRequiredKeyedService<HttpClient>("keyed"); // OK

// Throws: No service for type 'System.Net.Http.HttpClient' has been registered.
provider.GetRequiredKeyedService<HttpClient>("not-keyed");
```

Additionally, the Scoped lifetime of the clients can help catch cases of captive dependencies:

```csharp
services.AddHttpClient("scoped").AddAsKeyed();
services.AddSingleton<CapturingSingleton>();

// Throws: Cannot resolve scoped service 'System.Net.Http.HttpClient' from root provider.
rootProvider.GetRequiredKeyedService<HttpClient>("scoped");

using var scope = provider.CreateScope();
scope.ServiceProvider.GetRequiredKeyedService<HttpClient>("scoped"); // OK

// Throws: Cannot consume scoped service 'System.Net.Http.HttpClient' from singleton 'CapturingSingleton'.
public class CapturingSingleton([FromKeyedServices("scoped")] HttpClient httpClient)
//{ ...
```

## Service lifetime selection

By default, `AddAsKeyed()` registers `HttpClient` as a Keyed _Scoped_ service. You can also explicitly specify the lifetime by passing the `ServiceLifetime` parameter to the `AddAsKeyed()` method:

```csharp
services.AddHttpClient("explicit-scoped")
    .AddAsKeyed(ServiceLifetime.Scoped);

services.AddHttpClient("singleton")
    .AddAsKeyed(ServiceLifetime.Singleton);
```

If you call `AddAsKeyed()` within a Typed client registration, only the underlying Named client is registered as Keyed. The Typed client itself continues to be registered as a plain Transient service.

### Avoid transient HttpClient memory leak

> [!IMPORTANT]
> `HttpClient` is `IDisposable`, so we strongly recommend _avoiding_ Transient lifetime for Keyed `HttpClient` instances.
>
> Registering the client as a Keyed Transient service leads to the `HttpClient` and `HttpMessageHandler` instances being _captured by DI container_, as both implement `IDisposable`. This can result in _memory leaks_ if the client is resolved multiple times within Singleton services.

### Avoid captive dependency

> [!IMPORTANT]
> If `HttpClient` is registered either:
>
> - as a Keyed _Singleton_, -OR-
> - as a Keyed _Scoped_ or _Transient_, and injected within a _long-running_ (longer than `HandlerLifetime`) application Scope, -OR-
> - as a Keyed _Transient_, and injected into a _Singleton_ service,
>
> &mdash;the `HttpClient` instance becomes _captive_, and will likely outlive its expected `HandlerLifetime`. `IHttpClientFactory` has no control over captive clients, they're NOT able to participate in the handler rotation, and it can result in [the loss of DNS changes](httpclient-factory-troubleshooting.md#httpclient-doesnt-respect-dns-changes). A similar issue [already exists](httpclient-factory.md#avoid-typed-clients-in-singleton-services) for Typed clients, which are registered as Transient services.

In cases when client's longevity can't be avoided&mdash;or if it's consciously desired, for example, for a Keyed Singleton&mdash;it's advised to [leverage `SocketsHttpHandler`](httpclient-factory.md#using-ihttpclientfactory-together-with-socketshttphandler) by setting `PooledConnectionLifetime` to a reasonable value.

```csharp
services.AddHttpClient("shared")
    .AddAsKeyed(ServiceLifetime.Singleton) // explicit singleton
    .UseSocketsHttpHandler((h, _) => h.PooledConnectionLifetime = TimeSpan.FromMinutes(2))
    .SetHandlerLifetime(Timeout.InfiniteTimeSpan); // disable rotation
services.AddSingleton<MySingleton>();

public class MySingleton([FromKeyedServices("shared")] HttpClient shared) // { ...
```

### Beware of scope mismatch

While Scoped lifetime is much less problematic for the Named `HttpClient`s (compared to Singleton and Transient pitfalls), it has its own catch.

> [!IMPORTANT]
> Keyed Scoped lifetime of a specific `HttpClient` instance is bound&mdash;as expected&mdash;to the "ordinary" application scope (for example, incoming request scope) where it was resolved from. However, it does NOT apply to the underlying message handler chain, which is still managed by the `IHttpClientFactory`, in the same way it is for the Named clients created directly from factory. `HttpClient`s with the _same_ name, but resolved (within a `HandlerLifetime` timeframe) in two different scopes (for example, two concurrent requests to the same endpoint), can reuse the _same_ `HttpMessageHandler` instance. That instance, in turn, has its own separate scope, as illustrated in the [Message handler scopes](httpclient-factory.md#message-handler-scopes-in-ihttpclientfactory).

> [!NOTE]
> The [Scope Mismatch](httpclient-factory-troubleshooting.md#httpclient-doesnt-respect-scoped-lifetime) problem is nasty and long-existing one, and as of .NET 9 still remains [unsolved](https://github.com/dotnet/runtime/issues/47091). From a service injected through the regular DI infra, you would expect all the dependencies to be satisfied from the same scope&mdash;but for the Keyed Scoped `HttpClient` instances, that's unfortunately not the case.

## Keyed message handler chain

For some advanced scenarios, you might want to access `HttpMessageHandler` chain directly, instead of an `HttpClient` object. `IHttpClientFactory` provides `IHttpMessageHandlerFactory` interface to create the handlers; and if you enable Keyed DI, then not only `HttpClient`, but also the respective `HttpMessageHandler` chain is registered as a Keyed service:

```csharp
services.AddHttpClient("keyed-handler").AddAsKeyed();

var handler = provider.GetRequiredKeyedService<HttpMessageHandler>("keyed-handler");
var invoker = new HttpMessageInvoker(handler, disposeHandler: false);
```

## How to: Switch from Typed approach to Keyed DI

> [!NOTE]
> We currently recommend using Keyed DI approach instead of Typed clients.

A minimal-change switch from an existing Typed client to a Keyed dependency can look as follows:

```diff
- services.AddHttpClient<Service>(         // (1) Typed client
+ services.AddHttpClient(nameof(Service),  // (1) Named client
      c => { /* ... */ }                   // HttpClient configuration
  //).Configure....
- );
+ ).AddAsKeyed();                          // (1) + Keyed DI opt-in

+ services.AddTransient<Service>();        // (1) Plain Transient service

  public class Service(
-                                          // (2) "Hidden" Named dependency
+     [FromKeyedServices(nameof(Service))] // (2) Explicit Keyed dependency
      HttpClient httpClient) // { ...
```

In the example:

1. The registration of the Typed client `Service` is split into:
    - A registration of a Named client `nameof(Service)` with the same `HttpClient` configuration, and an opt-in to Keyed DI; and
    - Plain Transient service `Service`.
2. `HttpClient` dependency in `Service` is explicitly bound to a Keyed Service with a key `nameof(Service)`.

The name doesn't have to be `nameof(Service)`, but the example aimed to minimize the behavioral changes. Internally, typed clients use Named clients, and by default, such "hidden" Named clients go by the linked Typed client's type name. In this case, the "hidden" name was `nameof(Service)`, so the example preserved it.

Technically, the example "unwraps" the Typed client, so that the previously "hidden" Named client becomes "exposed," and the dependency is satisfied via the Keyed DI infra instead of the Typed client infra.

## How to: Opt in to Keyed DI by default

You don't have to call <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddAsKeyed%2A> for every single client&mdash;you can easily opt in "globally" (for any client name) via <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.ConfigureHttpClientDefaults%2A>. From Keyed Services perspective, it results in the <xref:Microsoft.Extensions.DependencyInjection.KeyedService.AnyKey?displayProperty=nameWithType> registration.

```csharp
services.ConfigureHttpClientDefaults(b => b.AddAsKeyed());

services.AddHttpClient("first", /* ... */);
services.AddHttpClient("second", /* ... */);
services.AddHttpClient("third", /* ... */);

public class MyController(
    [FromKeyedServices("first")] HttpClient first,
    [FromKeyedServices("second")] HttpClient second,
    [FromKeyedServices("third")] HttpClient third)
//{ ...
```

### Beware Of "Unknown" clients

> [!NOTE]
> `KeyedService.AnyKey` registrations define a mapping from _any_ key value to some service instance. However, as a result, the Container validation doesn't apply, and an _erroneous_ key value _silently_ leads to a _wrong instance_ being injected.

> [!IMPORTANT]
> For Keyed `HttpClient`s, a mistake in the client name can result in erroneously injecting an "unknown" client&mdash;meaning, a client whose name was never registered.

The same is true for the plain Named clients: `IHttpClientFactory` doesn't require the client name to be explicitly registered (aligning with the way the [Options pattern](options.md) works). The factory gives you an unconfigured&mdash;or, more precisely, default-configured&mdash;`HttpClient` for any unknown name.

> [!NOTE]
> Therefore, it's important to keep in mind: the "Keyed by default" approach covers not only all _registered_ `HttpClient`s, but all the clients that `IHttpClientFactory` is _able to create_.

```csharp
services.ConfigureHttpClientDefaults(b => b.AddAsKeyed());
services.AddHttpClient("known", /* ... */);

provider.GetRequiredKeyedService<HttpClient>("known");   // OK
provider.GetRequiredKeyedService<HttpClient>("unknown"); // OK (unconfigured instance)
```

### "Opt-in" strategy considerations

Even though the "global" opt-in is a one-liner, it's unfortunate that the feature still requires it, instead of just working "out of the box." For full context and reasoning on that decision, see [dotnet/runtime#89755](https://github.com/dotnet/runtime/issues/89755) and [dotnet/runtime#104943](https://github.com/dotnet/runtime/pull/104943). In short, the main blocker for "on by default" is the `ServiceLifetime` "controversy": for the current (`9.0.0`) state of the DI and `IHttpClientFactory` implementations, there's no single `ServiceLifetime` that would be reasonably safe for all `HttpClient`s in all possible situations. There's an intention, however, to address the caveats in the upcoming releases, and switch the strategy from "opt-in" to "opt-out".

## How to: Opt out from keyed registration

You can explicitly opt out from Keyed DI for `HttpClient`s by calling the <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.RemoveAsKeyed%2A> extension method, either per client name:

```csharp
services.ConfigureHttpClientDefaults(b => b.AddAsKeyed());      // opt IN by default
services.AddHttpClient("keyed", /* ... */);
services.AddHttpClient("not-keyed", /* ... */).RemoveAsKeyed(); // opt OUT per name

provider.GetRequiredKeyedService<HttpClient>("keyed");     // OK
provider.GetRequiredKeyedService<HttpClient>("not-keyed"); // Throws: No service for type 'System.Net.Http.HttpClient' has been registered.
provider.GetRequiredKeyedService<HttpClient>("unknown");   // OK (unconfigured instance)
```

Or "globally" with <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.ConfigureHttpClientDefaults%2A>:

```csharp
services.ConfigureHttpClientDefaults(b => b.RemoveAsKeyed()); // opt OUT by default
services.AddHttpClient("keyed", /* ... */).AddAsKeyed();      // opt IN per name
services.AddHttpClient("not-keyed", /* ... */);

provider.GetRequiredKeyedService<HttpClient>("keyed");     // OK
provider.GetRequiredKeyedService<HttpClient>("not-keyed"); // Throws: No service for type 'System.Net.Http.HttpClient' has been registered.
provider.GetRequiredKeyedService<HttpClient>("unknown");   // Throws: No service for type 'System.Net.Http.HttpClient' has been registered.
```

## Order of precedence

If called together or any of them more than once, `AddAsKeyed()` and `RemoveAsKeyed()` generally follow the rules of `IHttpClientFactory` configs and DI registrations:

1. If called for the same name, the last setting wins: the lifetime from the last `AddAsKeyed()` is used to create the Keyed registration (unless `RemoveAsKeyed()` was called last, in which case the name is excluded).
2. If used only within `ConfigureHttpClientDefaults`, the last setting wins.
3. If both `ConfigureHttpClientDefaults` and specific client name were used, all defaults are considered to "happen" before all per-name settings. Thus, defaults can be disregarded, and the last of the per-name settings wins.

## See also

- [IHttpClientFactory with .NET][hcf]
- [Dependency injection in .NET][di]
- <xref:System.Net.Http.IHttpClientFactory>
- [Common `IHttpClientFactory` usage issues][hcf-troubleshooting]

[hcf]: httpclient-factory.md
[di]: dependency-injection.md
[hcf-troubleshooting]: httpclient-factory-troubleshooting.md
