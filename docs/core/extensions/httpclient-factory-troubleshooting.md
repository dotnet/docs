---
title: Troubleshoot IHttpClientFactory issues
description: Learn how to troubleshoot common HttpClient and IHttpClientFactory problems.
author: CarnaViire
ms.author: knatalia
ms.date: 08/21/2024
ms.topic: troubleshooting-general
---

# Common `IHttpClientFactory` usage issues

In this article, you'll learn some of the most common problems you can run into when using `IHttpClientFactory` to create `HttpClient` instances.

`IHttpClientFactory` is a convenient way to set up multiple `HttpClient` configurations in the DI container, configure logging, set up resilience strategies, and more. `IHttpClientFactory` also encapsulates the lifetime management of `HttpClient` and `HttpMessageHandler` instances, to prevent problems like socket exhaustion and losing DNS changes. For an overview on how to use `IHttpClientFactory` in your .NET application, see [IHttpClientFactory with .NET](httpclient-factory.md).

Due to a complex nature of `IHttpClientFactory` integration with DI, you can hit some issues that might be hard to catch and troubleshoot. The scenarios listed in this article also contain recommendations, which you can apply proactively to avoid potential problems.

## `HttpClient` doesn't respect `Scoped` lifetime

You can hit a problem if you need to access any scoped service, for example, `HttpContext`, or some scoped cache, from within the `HttpMessageHandler`. The data saved there can either "disappear", or, the other way around, "persist" when it shouldn't. This is caused by the Dependency Injection (DI) **scope mismatch** between the application context and the handler instance, and it's a known limitation in `IHttpClientFactory`.

`IHttpClientFactory` creates a separate DI scope per each `HttpMessageHandler` instance. These handler scopes are distinct from application context scopes (for example, ASP.NET Core incoming request scope, or a user-created manual DI scope), so they will not share scoped service instances.

As a result of this limitation:

- Any data cached "externally" in a scoped service will **not** be available within the `HttpMessageHandler`.
- Any data cached "internally" within the `HttpMessageHandler` or its scoped dependencies **can** be observed from multiple application DI scopes (for example, from different incoming requests) as they can share the same handler.

Consider the following recommendations to help alleviate this known limitation:

❌ DO NOT cache any scope-related information (such as data from `HttpContext`) inside `HttpMessageHandler` instances or its dependencies to avoid leaking sensitive information.

❌ DO NOT use cookies, as the `CookieContainer` will be shared together with the handler.

✔️ CONSIDER not storing the information, or only pass it within the `HttpRequestMessage` instance.

To pass arbitrary information alongside the `HttpRequestMessage`, you can use the <xref:System.Net.Http.HttpRequestMessage.Options?displayProperty=nameWithType> property.

✔️ CONSIDER encapsulating all the scope-related (for example, authentication) logic in a separate `DelegatingHandler` that's **not** created by the `IHttpClientFactory`, and use it to wrap the `IHttpClientFactory`-created handler.

To create just an `HttpMessageHandler` without `HttpClient`, call <xref:System.Net.Http.IHttpMessageHandlerFactory.CreateHandler%2A?displayProperty=nameWithType> for any registered _named client_. In that case, you will need to create an `HttpClient` instance yourself using the combined handler. You can find a fully runnable example for this workaround on [GitHub](https://github.com/dotnet/docs/tree/main/docs/core/extensions/snippets/http/scopeworkaround).

For more information, see the [Message Handler Scopes in IHttpClientFactory](httpclient-factory.md#message-handler-scopes-in-ihttpclientfactory) section in the `IHttpClientFactory` guidelines.

## `HttpClient` doesn't respect DNS changes

Even if `IHttpClientFactory` is used, it's still possible to hit the stale DNS problem. This can usually happen if an `HttpClient` instance gets captured in a `Singleton` service, or, in general, stored somewhere for a period of time that's longer than the specified `HandlerLifetime`. `HttpClient` will also get captured if the respective _typed client_ is captured by a singleton.

❌ DO NOT cache `HttpClient` instances created by `IHttpClientFactory` for prolonged periods of time.

❌ DO NOT inject _typed client_ instances into `Singleton` services.

✔️ CONSIDER requesting a client from `IHttpClientFactory` in a timely manner or each time you need one. Factory-created clients are safe to dispose.

`HttpClient` instances created by `IHttpClientFactory` are intended to be **short-lived**.

- Recycling and recreating `HttpMessageHandler`'s when their lifetime expires is essential for `IHttpClientFactory` to ensure the handlers react to DNS changes. `HttpClient` is tied to a specific handler instance upon its creation, so new `HttpClient` instances should be requested in a timely manner to ensure the client will get the updated handler.

- Disposing of such `HttpClient` instances **created by the factory** will not lead to socket exhaustion, as its disposal **does not** trigger disposal of the `HttpMessageHandler`. `IHttpClientFactory` tracks and disposes of resources used to create `HttpClient` instances, specifically the `HttpMessageHandler` instances, as soon their lifetime expires and there's no `HttpClient` using them anymore.

_Typed clients_ are intended to be **short-lived** as well, as an `HttpClient` instance is injected into the constructor, so it will share the _typed client_ lifetime.

For more information, see the [`HttpClient` lifetime management](httpclient-factory.md#httpclient-lifetime-management) and [Avoid _typed clients_ in singleton services](httpclient-factory.md#avoid-typed-clients-in-singleton-services) sections in the `IHttpClientFactory` guidelines.

## `HttpClient` uses too many sockets

Even if `IHttpClientFactory` is used, it's still possible to hit the socket exhaustion issue with a specific usage scenario. By default, `HttpClient` doesn't limit the number of concurrent requests. If a large number of HTTP/1.1 requests are started concurrently at the same time, each of them will end up triggering a new HTTP connection attempt, because there is no free connection in the pool and no limit is set.

❌ DO NOT start a large number of HTTP/1.1 requests concurrently at the same time without specifying the limits.

✔️ CONSIDER setting <xref:System.Net.Http.HttpClientHandler.MaxConnectionsPerServer?displayProperty=nameWithType> (or <xref:System.Net.Http.SocketsHttpHandler.MaxConnectionsPerServer?displayProperty=nameWithType>, if you use it as a primary handler) to a reasonable value. Note that these limits only apply to the specific handler instance.

✔️ CONSIDER using HTTP/2, which allows multiplexing requests over a single TCP connection.

## _Typed client_ has the wrong `HttpClient` injected

There can be various situations in which it is possible to get an unexpected `HttpClient` injected into a _typed client_. Most of the time, the root cause will be in an erroneous configuration, as, by DI design, any subsequent registration of a service overrides the previous one.

_Typed clients_ use _named clients_ "under the hood": adding a _typed client_ implicitly registers and links it to a _named client_. The client name, unless explicitly provided, will be set to the type name of `TClient`. This would be the **first** one from the `TClient,TImplementation` pair if `AddHttpClient<TClient,TImplementation>` overloads are used.

Therefore, registering a _typed client_ does two separate things:

1. Registers a _named client_ (in a simple default case, the name is `typeof(TClient).Name`).
1. Registers a `Transient` service using the `TClient` or `TClient,TImplementation` provided.

The following two statements are technically the same:

```csharp
services.AddHttpClient<ExampleClient>(c => c.BaseAddress = new Uri("http://example.com"));

// -OR-

services.AddHttpClient(nameof(ExampleClient), c => c.BaseAddress = new Uri("http://example.com")) // register named client
    .AddTypedClient<ExampleClient>(); // link the named client to a typed client
```

In a simple case, it will also be similar to the following:

```csharp
services.AddHttpClient(nameof(ExampleClient), c => c.BaseAddress = new Uri("http://example.com")); // register named client

// register plain Transient service and link it to the named client
services.AddTransient<ExampleClient>(s =>
    new ExampleClient(
        s.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(ExampleClient))));
```

Consider the following examples of how the link between _typed_ and _named_ clients can get broken.

### _Typed client_ is registered a second time

❌ DO NOT register the _typed client_ separately — it is already registered automatically by the `AddHttpClient<T>` call.

If a _typed client_ is erroneously registered a second time as a plain Transient service, this will overwrite the registration added by the `HttpClientFactory`, breaking the link to the _named client_. It will manifest as if the `HttpClient`'s configuration is lost, as an unconfigured `HttpClient` will get injected into the _typed client_ instead.

It might be confusing that, instead of throwing an exception, a "wrong" `HttpClient` is used. This happens because the "default" unconfigured `HttpClient` — the client with the <xref:Microsoft.Extensions.Options.Options.DefaultName?displayProperty=nameWithType> name (`string.Empty`) — is registered as a plain Transient service, to enable the most basic `HttpClientFactory` usage scenario. That's why after the link gets broken and the _typed client_ becomes just an ordinary service, this "default" `HttpClient` will naturally get injected into the respective constructor parameter.

### Different _typed clients_ are registered on a common interface

In case two different _typed clients_ are registered on a common interface, they both would reuse the same _named client_. This can seem like the first _typed client_ getting the second _named client_ "wrongly" injected.

❌ DO NOT register multiple _typed clients_ on a single interface without explicitly specifying the name.

✔️ CONSIDER registering and configuring a _named client_ separately, and then linking it to one or multiple _typed clients_, either by specifying the name in `AddHttpClient<T>` call or by calling `AddTypedClient` during the _named client_ setup.

By design, registering and configuring a _named client_ with the same name several times just appends the configuration actions to the list of existing ones. This behavior of `HttpClientFactory` might not be obvious, but it is the same approach that is used by the [Options pattern](options.md) and configuration APIs like <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A>.

This is mostly useful for advanced handler configurations, for example, adding a custom handler to a _named client_ defined externally, or mocking a primary handler for tests, but it works for `HttpClient` instance configuration as well. For example, the three following examples will result in an `HttpClient` configured in the **same** way (both `BaseAddress` and `DefaultRequestHeaders` are set):

```csharp
// one configuration callback
services.AddHttpClient("example", c =>
    {
        c.BaseAddress = new Uri("http://example.com");
        c.DefaultRequestHeaders.UserAgent.ParseAdd("HttpClient/8.0");
    });

// -OR-

// two configuration callbacks
services.AddHttpClient("example", c => c.BaseAddress = new Uri("http://example.com"))
    .ConfigureHttpClient(c => c.DefaultRequestHeaders.UserAgent.ParseAdd("HttpClient/8.0"));

// -OR-

// two configuration callbacks in separate AddHttpClient calls
services.AddHttpClient("example", c => c.BaseAddress = new Uri("http://example.com"));
services.AddHttpClient("example")
    .ConfigureHttpClient(c => c.DefaultRequestHeaders.UserAgent.ParseAdd("HttpClient/8.0"));
```

This enables linking a _typed client_ to an already defined _named client_, and also linking several _typed clients_ to a single _named client_. It is more obvious when overloads with a `name` parameter are used:

```csharp
services.AddHttpClient("LogClient", c => c.BaseAddress = new Uri(LogServerAddress));

services.AddHttpClient<FooLogger>("LogClient");
services.AddHttpClient<BarLogger>("LogClient");
```

The same thing can also be achieved by calling <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddTypedClient%2A> during the _named client_ configuration:

```csharp
services.AddHttpClient("LogClient", c => c.BaseAddress = new Uri(LogServerAddress))
    .AddTypedClient<FooLogger>()
    .AddTypedClient<BarLogger>();
```

However, if you _don't_ want to reuse the same _named client_, you but you still wish to register the clients on the same interface, you can do so by explicitly specifying different names for them:

```csharp
services.AddHttpClient<ITypedClient, ExampleClient>(nameof(ExampleClient),
    c => c.BaseAddress = new Uri("http://example.com"));
services.AddHttpClient<ITypedClient, GithubClient>(nameof(GithubClient),
    c => c.BaseAddress = new Uri("https://github.com"));
```

## See also

- [IHttpClientFactory with .NET][hcf]
- <xref:System.Net.Http.IHttpClientFactory>
- <xref:System.Net.Http.IHttpMessageHandlerFactory>
- <xref:System.Net.Http.HttpClient>
- [Make HTTP requests with the HttpClient][httpclient]

[hcf]: httpclient-factory.md
[httpclient]: ../../fundamentals/networking/http/httpclient.md
