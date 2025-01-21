---
title: Keyed DI Support in IHttpClientFactory
description: Learn how to integrate IHttpClientFactory with Keyed Services.
author: CarnaViire
ms.author: knatalia
ms.date: 01/03/2025
---

# Keyed DI Support in `IHttpClientFactory`

In this article, you'll learn how to integrate `IHttpClientFactory` with Keyed Services.

[_Keyed Services_](dependency-injection.md#keyed-services) (also called _Keyed DI_) is a DI feature that allows you to conveniently operate with multiple implementations of a single service. Upon registration, you can assign different _service keys_ to the implementations. In runtime, this key is used in lookup in combination with a service type, which means you can retrieve a specific implementation by passing the matching key. For more information on Keyed Services, and DI in general, see [.NET dependency injection](dependency-injection.md).

For an overview on how to use `IHttpClientFactory` in your .NET application, see [IHttpClientFactory with .NET](httpclient-factory.md).

## Background

`IHttpClientFactory` and Named `HttpClient` instances, unsurprisingly, align well with the Keyed Services idea. Among other things, `IHttpClientFactory` historically was a way to overcome this long-missing DI feature. But plain Named clients require you to obtain, store and query the `IHttpClientFactory` instance &mdash; instead of injecting a configured `HttpClient` &mdash; which might be inconvenient. While Typed clients attempt to simplify that part, it comes with a catch: Typed clients are quite easy to [misconfigure](httpclient-factory-troubleshooting.md#typed-client-has-the-wrong-httpclient-injected) and [misuse](httpclient-factory.md#avoid-typed-clients-in-singleton-services), and the supporting infra can also be a tangible overhead in certain scenarios (for example, om mobile platforms).

Starting from .NET 9 (package-provided), `IHttpClientFactory` can leverage Keyed DI directly, introducing a new "Keyed DI approach" (as opposed to "Named" and "Typed" approaches). "Keyed DI approach" pairs the convenient, highly configurable `HttpClient` registrations with the straightforward injection of the specific configured `HttpClient` instances.

## Basic Usage

As of .NET 9 (package-provided), you need to _opt in_ to the feature by calling the [`AddAsKeyed()`](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.httpclientbuilderextensions.addaskeyed) extension method. This will register a Named `HttpClient` as a Keyed service, using the client's name as a service key &mdash; and enable you to leverage the Keyed Services APIs (e.g. [`[FromKeyedServices(...)]`](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.fromkeyedservicesattribute)) to obtain the required `HttpClient` instances. By default, the clients are registered with Scoped lifetime.

Below is a full runnable example of the integration between `HttpClientFactory`, Keyed DI and ASP.NET Core 9.0 Minimal APIs:

:::code source="snippets/http/keyedservices/Program.cs" highlight="4,10,16":::

Endpoint response:

```sh
> ~  curl http://localhost:5000/
{"name":"runtime","url":"https://api.github.com/repos/dotnet/runtime"}
```

In the example above, the configured `HttpClient` is directly injected into the request handler via the Keyed DI infra and ASP.NET Core parameter binding. For more information on Keyed Services in ASP.NET Core, see [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection#keyed-services)

## Approach Comparison

Stripping away the code unrelated to `IHttpClientFactory`, you can compare the _Keyed DI approach_

```csharp
services.AddHttpClient("github", /* ... */).AddAsKeyed();                // (1)

app.MapGet("/", ([FromKeyedServices("github")] HttpClient httpClient) => // (2)
    //httpClient.Get....                                                 // (3)
```

with how the same is achieved the two "older" ones: first with the _Named approach_

```csharp
services.AddHttpClient("github", /* ... */);                          // (1)

app.MapGet("/github", (IHttpClientFactory httpClientFactory) =>
{
    HttpClient httpClient = httpClientFactory.CreateClient("github"); // (2)
    //return httpClient.Get....                                       // (3)
});
```

and second, the _Typed approach_.

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

## Built-In DI Container Validation

If you enabled the Keyed registration for a specific Named client, you can access it with any existing Keyed DI APIs. But if you erroneously try to use a name which was not enabled yet, you will get the standard Keyed DI exception:

```c#
services.AddHttpClient("keyed").AddAsKeyed();
services.AddHttpClient("not-keyed");

provider.GetRequiredKeyedService<HttpClient>("keyed"); // OK

// Throws: No service for type 'System.Net.Http.HttpClient' has been registered.
provider.GetRequiredKeyedService<HttpClient>("not-keyed");
```

Additionaly, the Scoped lifetime of the clients can help catching cases of captive dependencies:

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

## Service Lifetime Selection

By default, `AddAsKeyed()` registers `HttpClient` as a Keyed _Scoped_ service. You can also explicitly specify the lifetime by passing the `ServiceLifetime` parameter to the `AddAsKeyed()` method:

```csharp
services.AddHttpClient("explicit-scoped")
    .AddAsKeyed(ServiceLifetime.Scoped);

services.AddHttpClient("singleton")
    .AddAsKeyed(ServiceLifetime.Singleton);
```

### ⚠️ Avoid Transient HttpClient Memory Leak ⚠️

We strongly recommend _avoiding_ Transient lifetime for Keyed `HttpClient`s.

Registering the client as a Keyed Transient service will lead to the `HttpClient` and `HttpMessageHandler` instances being _captured by DI container_, as both implement `IDisposable`. This can result in _memory leaks_ if the client is resolved multiple times within Singleton services.

### ⚠️ Avoid Captive Dependency ⚠️

If `HttpClient` is registered either:
  - as a Keyed _Singleton_, -OR-
  - as a Keyed _Scoped_ or _Transient_, and injected within a _long-running_ (longer than `HandlerLifetime`) application Scope, -OR-
  - as a Keyed _Transient_, and injected into a _Singleton_ service,

the `HttpClient` instance will become _captive_, and will most possibly outlive way beyond its expected `HandlerLifetime`. `HttpClientFactory` has no control over captive clients, they are NOT able to participate in the handler rotation, and this can result in [the loss of DNS changes](httpclient-factory-troubleshooting.md#httpclient-doesnt-respect-dns-changes). A similar issue [already exists](httpclient-factory.md#avoid-typed-clients-in-singleton-services) for Typed clients, which are registered as Transient services.

In cases when client's longevity cannot be avoided &mdash; or if it is concsiously desired, e.g. for a Keyed Singleton &mdash; it is advised to [leverage `SocketsHttpHandler`](httpclient-factory.md#using-ihttpclientfactory-together-with-socketshttphandler) by setting `PooledConnectionLifetime` to a reasonable value.

```csharp
services.AddHttpClient("shared")
    .AddAsKeyed(ServiceLifetime.Singleton) // explicit singleton
    .UseSocketsHttpHandler((h, _) => h.PooledConnectionLifetime = TimeSpan.FromMinutes(2))
    .SetHandlerLifetime(Timeout.InfiniteTimeSpan); // disable rotation
services.AddSingleton<MySingleton>();

public class MySingleton([FromKeyedServices("shared")] HttpClient shared) // { ...
```

### ⚠️ Beware Of Scope Mismatch ⚠️

While Scoped lifetime is much less problematic for the Named `HttpClient`s (compared to Singleton and Transient pitfalls), it has its own catch. 

Keyed Scoped lifetime of a specific `HttpClient` instance will be bound &mdash; as expected &mdash; to the "ordinary" application scope (e.g. incoming request scope) where it was resolved from. However, it does NOT apply to the underlying message handler chain, which is still managed by the `HttpClientFactory`, in the same way it is for the Named clients created directly from factory. `HttpClient`s with the _same_ name, but resolved (within a `HandlerLifetime` timeframe) in two different scopes (e.g. two concurrent requests to the same endpoint), can reuse the _same_ `HttpMessageHandler` instance. Which in turn will have it's own separate scope, as illustrated in the [docs](httpclient-factory.md#message-handler-scopes-in-ihttpclientfactory).

The [Scope Mismatch](httpclient-factory-troubleshooting.md#httpclient-doesnt-respect-scoped-lifetime) problem is nasty and long-existing one, and as of .NET 9 (package-provided) is still remains [unsolved](https://github.com/dotnet/runtime/issues/47091). From a service injected through the regular DI infra, you would expect all the dependencies to be satisfied from the same scope &mdash; but be aware that for the Keyed Scoped `HttpClient`s it is, unfortunately, not the case.

## Keyed Message Handler Chain

For some advanced scenarios, you might want to access `HttpMessageHandler` chain directly, instead of an `HttpClient` object. `HttpClientFactory` provides `IHttpMessageHandlerFactory` interface for that; and if you enable Keyed DI, then not only `HttpClient`, but also the respective `HttpMessageHandler` chain will be registered as a Keyed service:

```csharp
services.AddHttpClient("foo").AddAsKeyed();

var handler = provider.GetRequiredKeyedService<HttpMessageHandler>("foo");
var invoker = new HttpMessageInvoker(handler, disposeHandler: false);
```

## HOW-TO: Switch from Typed approach to Keyed DI

> [!NOTE]
> We currently recommend using Keyed DI approach instead of Typed clients.

A minimal-change switch from an existing Typed client to a Keyed dependency can look as follows:

```diff
- services.AddHttpClient<Foo>(        // (1) Typed client
+ services.AddHttpClient(nameof(Foo), // (1) Named client
      c => { /* ... */ }              // HttpClient configuration
  //).Configure....
- );
+ ).AddAsKeyed();                     // (1) + Keyed DI opt-in

+ services.AddTransient<Foo>();       // (1) Plain Transient service

  public class Foo(
-                                      // (2) Implicit ("hidden" Named) dependency
+     [FromKeyedServices(nameof(Foo))] // (2) Explicit Keyed Service dependency
      HttpClient httpClient) // { ...
```

In the example above:
1. The registration of the Typed client `Foo` is split into:
    - A registration of a Named client `nameof(Foo)` with the same `HttpClient` configuration, and opt-in to Keyed DI; and
    - Plain Transient service `Foo`.
2. `HttpClient` dependency in `Foo` is explicitly bound to a Keyed Service with a key `nameof(Foo)`.

The name doesn't have to be `nameof(Foo)`, but the example aimed to minimize the behavioral changes. Typed clients use Named clients "under the hood", and by default, such "hidden" Named clients go by the linked Typed client's type name. In this case, the "hidden" name was `nameof(Foo)`, so the example preserved it.

Technically, the example "unwraps" the Typed client, so that the previously "hidden" Named client becomes "exposed", and the dependency is satisfied via the Keyed DI infra instead of the Typed client infra.

## HOW-TO: Opt-In To Keyed DI By Default

You don't have to call `AddAsKeyed` for every single client &mdash; you can easily opt in "globally" (for any client name) via `ConfigureHttpClientDefaults`. From Keyed Services perspective, it will result in the [`KeyedService.AnyKey`](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.keyedservice.anykey) registration.

```csharp
services.ConfigureHttpClientDefaults(b => b.AddAsKeyed());

services.AddHttpClient("foo", /* ... */);
services.AddHttpClient("bar", /* ... */);
services.AddHttpClient("baz", /* ... */);

public class FooBarBazController(
    [FromKeyedServices("foo")] HttpClient foo,
    [FromKeyedServices("bar")] HttpClient bar,
    [FromKeyedServices("baz")] HttpClient baz)
//{ ...
```

### ⚠️ Beware Of "Unknown" Clients ⚠️

`KeyedService.AnyKey` registrations define a mapping from _any_ key value to some service instance. However, as a result, the Container validation will not apply, and an _erroneous_ key value will _silently_ lead to a _wrong instance_ being injected.

> [!IMPORTANT]
> In case of Keyed `HttpClient`s, a mistake in the client name can result in erroneously injecting an "unknown" client &mdash; meaning, a client which name was never registered.

Actually, in the first place, same is true for the plain Named clients: `IHttpClientFactory` doesn't require the client name to be explicitly registered (aligning with the way the [Options pattern](options.md) work). The factory will give you an unconfigured &mdash; or, more precisely, default-configured &mdash; `HttpClient` for any unknown name.

> [!NOTE]
> Therefore, it is important to keep in mind: the "Keyed by default" approach covers not only all _registered_ `HttpClient`s, but all the clients that `HttpClientFactory` is _able to create_.

```csharp
services.ConfigureHttpClientDefaults(b => b.AddAsKeyed());
services.AddHttpClient("known", /* ... */);

provider.GetRequiredKeyedService<HttpClient>("known");   // OK
provider.GetRequiredKeyedService<HttpClient>("unknown"); // OK (unconfigured instance)
```

### "Opt-In" Strategy Considerations

Even though the "global" opt-in is a one-liner, it is unfortunate that the feature still requires it, instead of just working "out of the box". For full context and reasoning on that decision, see [dotnet/runtime#89755](https://github.com/dotnet/runtime/issues/89755) and [dotnet/runtime#104943](https://github.com/dotnet/runtime/pull/104943). In short, the main blocker for "on by default" is the `ServiceLifetime` "controversy": for the current (`9.0.0`) state of the DI and `HttpClientFactory` implementations, there is no single `ServiceLifetime` that would be reasonably safe for all `HttpClient`s in all possible situations. There is an intention, however, to address the caveats in the upcoming releases, and switch the strategy from "opt-in" to "opt-out".

## HOW-TO: Opt-Out From Keyed Registration

You can explicitly opt out from Keyed DI for `HttpClient`s by calling [`RemoveAsKeyed()`](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.httpclientbuilderextensions.removeaskeyed), either per client name: 

```csharp
services.ConfigureHttpClientDefaults(b => b.AddAsKeyed());      // opt IN by default
services.AddHttpClient("keyed", /* ... */);
services.AddHttpClient("not-keyed", /* ... */).RemoveAsKeyed(); // opt OUT per name

provider.GetRequiredKeyedService<HttpClient>("keyed");     // OK
provider.GetRequiredKeyedService<HttpClient>("not-keyed"); // Throws: No service for type 'System.Net.Http.HttpClient' has been registered.
provider.GetRequiredKeyedService<HttpClient>("unknown");   // OK (unconfigured instance)
```

or "globally" with `ConfigureHttpClientDefaults`:

```csharp
services.ConfigureHttpClientDefaults(b => b.RemoveAsKeyed()); // opt OUT by default
services.AddHttpClient("keyed", /* ... */).AddAsKeyed();      // opt IN per name
services.AddHttpClient("not-keyed", /* ... */);

provider.GetRequiredKeyedService<HttpClient>("keyed");     // OK
provider.GetRequiredKeyedService<HttpClient>("not-keyed"); // Throws: No service for type 'System.Net.Http.HttpClient' has been registered.
provider.GetRequiredKeyedService<HttpClient>("unknown");   // Throws: No service for type 'System.Net.Http.HttpClient' has been registered.
```


## Order Of Precedence

If called together or any of them more then once, `AddAsKeyed()` and `RemoveAsKeyed()` generally follow the rules of `HttpClientFactory` configs and DI registrations:

1. If called for the same name, the last one wins: the lifetime from the last `AddAsKeyed()` is used to create the Keyed registration (unless `RemoveAsKeyed()` was called last, in which case the name is excluded).
2. If used only within `ConfigureHttpClientDefaults`, the last one wins.
3. If both `ConfigureHttpClientDefaults` and specific client name were used, all defaults are considered to "happen" before all per-name ones. Thus, defaults can be disregarded, and the last of the per-name ones wins.

Note that if `AddAsKeyed()` is called within a Typed client registration, only the underlying Named client  will be registered as Keyed. The Typed client itself will continue to be registered as a plain Transient service.

## See also

- [IHttpClientFactory with .NET][hcf]
- [Common `IHttpClientFactory` usage issues][hcf-troubleshooting]
- <xref:System.Net.Http.IHttpClientFactory>

[hcf]: httpclient-factory.md
[hcf-troubleshooting]: httpclient-factory-troubleshooting.md
[httpclient]: ../../fundamentals/networking/http/httpclient.md

