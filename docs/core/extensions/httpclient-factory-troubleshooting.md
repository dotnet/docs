---
title: Troubleshoot IHttpClientFactory issues
description: Learn how to troubleshoot common HttpClient and IHttpClientFactory problems.
author: CarnaViire
ms.author: knatalia
ms.date: 08/21/2024
---

# Common `IHttpClientFactory` usage issues

In this article, you'll learn some of the most common problems you can run into when using `IHttpClientFactory` to create `HttpClient` instances.

For an overview on how to use `IHttpClientFactory` in your .NET application, you can check out [IHttpClientFactory with .NET](../httpclient-factory.md).

## `HttpClient` doesn't respect `Scoped` lifetime

You can hit a problem if you need to access any scoped service, for example, `HttpContext`, or some scoped cache, from within the `HttpMessageHandler`. The data saved there can either "disappear", or, the other way around, "persist" when it should not. This is caused by the DI **scope mismatch** between the application context and the handler instance, and it is a known limitation in `IHttpClientFactory`.

`IHttpClientFactory` creates a separate DI scope per each `HttpMessageHandler` instance. These handler scopes are distinct from application context scopes (for example, ASP.NET incoming request scope, or a user-created manual DI scope), so they will not share scoped service instances.

It means that:

- Any data cached "externally" in a scoped service will NOT be available within the `HttpMessageHandler`
- Any data cached "internally" within the `HttpMessageHandler` or its scoped dependencies CAN be observed from multiple application DI scopes (for example, from different incoming requests) as they can share the same handler.

❌ DO NOT cache any scope-related information (such as data from `HttpContext`) inside `HttpMessageHandler` instances or its dependencies to avoid leaking sensitive information.

❌ DO NOT use cookies, as the `CookieContainer` will be shared together with the handler.

✔️ CONSIDER not storing the information, or only pass it within the `HttpRequestMessage` instance.

To pass arbitrary information alongside the `HttpRequestMessage`, you can use the <xref:System.Net.Http.HttpRequestMessage.Options?displayProperty=nameWithType> property.

✔️ CONSIDER incapsulating all the scope-related (for example, authentication) logic in a separate `DelegatingHandler`, that is NOT created by the `IHttpClientFactory`, and use it to wrap the `IHttpClientFactory`-created handler.

To create just an `HttpMessageHandler` without `HttpClient`, call <xref:System.Net.Http.IHttpMessageHandlerFactory.CreateHandler%2A?displayProperty=nameWithType> for any registered _named client_. In that case, you will need to create an `HttpClient` instance yourself using the combined handler. You can find a fully runnable example for this workaround on [GitHub](https://github.com/dotnet/docs/tree/main/docs/core/extensions/snippets/http/scopeworkaround).

For more information, see the [Message Handler Scopes in IHttpClientFactory](../httpclient-factory.md#message-handler-scopes-in-ihttpclientfactory) section in the `IHttpClientFactory` guidelines.

## `HttpClient` doesn't respect DNS changes

Even if `IHttpClientFactory` is used, it is still possible to hit the stale DNS problem. This can usually happen if an `HttpClient` instance gets captured in a `Singleton` service, or, in general, stored somewhere for the time longer than the specified `HandlerLifetime`. `HttpClient` will also get captured if the respective _typed client_ gets captured by a singleton.

❌ DO NOT cache `HttpClient` instances created by `IHttpClientFactory`

❌ DO NOT inject _typed client_ instances into `Singleton` services

✔️ CONSIDER requesting a client from `IHttpClientFactory` in a timely manner or each time you need one. Factory-created clients are are safe to dispose.

`HttpClient` instances created by `IHttpClientFactory` are intended to be **short-lived**.

- Recycling and recreating `HttpMessageHandler`'s when their lifetime expires is essential for `IHttpClientFactory` to ensure the handlers react to DNS changes. `HttpClient` is tied to a specific handler instance upon its creation, so new `HttpClient` instances should be requested in a timely manner to ensure the client will get the updated handler.

- Disposing of such `HttpClient` instances **created by the factory** will not lead to socket exhaustion, as its disposal **will not** trigger disposal of the `HttpMessageHandler`. `IHttpClientFactory` tracks and disposes of resources used to create `HttpClient` instances, specifically the `HttpMessageHandler` instances, as soon their lifetime expires and there's no `HttpClient` using them anymore.

_Typed clients_ are intended to be **short-lived** as well, as an `HttpClient` instance is injected into the constructor, so it will share the _typed client_ lifetime.

For more information, see the [`HttpClient` lifetime management](../httpclient-factory.md#httpclient-lifetime-management) and [Avoid typed clients in singleton services](../httpclient-factory.md#avoid-typed-clients-in-singleton-services) sections in the `IHttpClientFactory` guidelines.

## `HttpClient` uses too many sockets

Even if `IHttpClientFactory` is used, it is still possible to hit the socket exhaustion issue with a specific usage scenario. By default, `HttpClient` doesn't limit the amount of concurrent requests. If a large amount of HTTP/1.1 requests are started concurrently at the same time, each of them will end up triggering a new HTTP connection attempt, because there is no free connection in the pool and no limit is set.

❌ DO NOT start a large amount of HTTP/1.1 requests concurrently at the same time without specifying the limits.

✔️ CONSIDER setting <xref:System.Net.Http.HttpClientHandler.MaxConnectionsPerServer?displayProperty=nameWithType> (or <xref:System.Net.Http.SocketsHttpHandler.MaxConnectionsPerServer?displayProperty=nameWithType>, if you use it as a primary handler) to a reasonable value. Note that these limits only apply to the specific handler instance.

✔️ CONSIDER using HTTP/2 which allows multiplexing requests over a single TCP conneciton.

## _Typed client_ gets a wrong `HttpClient` injected

There can be various situations in which it is possible to get an unexpected `HttpClient` injected into a _typed client_. Most of the time, the root cause will be in an erroneous configuration, as, by DI design, any subsequent registration of a service overrides the previous one.

_Typed clients_ use _named clients_ "under the hood": adding a _Typed client_ implicitly registers and links it to a _Named client_. The client name, unless explicitly provided, will be set to the type name of `TClient`. Note that this would be the first one from the pair in case `AddHttpClient<TClient,TImplementation>` overloads are used.

Therefore, registering a _Typed client_ technically does two separate things:
1) registers a _Named client_ (in a simple default case, the name is `typeof(TClient).Name`), and
2) registers a `Transient` service using the `TClient` or `TClient,TImplementation` provided.

The following statement

```csharp
services.AddHttpClient<ITypedClient, TypedClient1>(c => c.BaseAddress = new Uri("http://example.com"));
```

would be technically the same as

```csharp
services.AddHttpClient("ITypedClient", c => c.BaseAddress = new Uri("http://example.com")) // register Named client
    .AddTypedClient<ITypedClient, TypedClient1>(); // link the Named client to a Typed client
```

and even -- in this simple case -- same as

```csharp
services.AddHttpClient("ITypedClient", c => c.BaseAddress = new Uri("http://example.com")); // register Named client

// register plain Transient and link it to the Named client
Services.AddTransient<ITypedClient, TypedClient1>(s =>
    new TypedClient1(
        s.GetRequiredService<IHttpClientFactory>().CreateClient("ITypedClient")));
```

Let's consider several examples of how this link can get broken.

### _Typed client_ is registered a second time 

If a _typed client_ is erroneously registered a second time as a plain Transient service, this will overwrite the registration added by the `HttpClientFactory`, breaking the link to the _named client_. It will manifest as if the `HttpClient`'s configuration is lost, as an unconfigured `HttpClient` will get injected into _typed client_ instead.

This might be confusing, that instead of throwing an exception, a "wrong" `HttpClient` is used. Unfortunatly, the "default" unconfigured `HttpClient` (the one auto-added with `string.Empty` name) -- is registered as a plain Transient service, to enable the most basic `HttpClientFactory` usage scenario. That's why after the link gets broken and the _typed client_ becomes just an ordinary service, this "default" `HttpClient` will naturally get injected into the respective constructor parameter.

### Different _typed clients_ are registered on a common interface 

In case two different _typed clients_ are registered on a common interface, they both would reuse the same _named client_. This can seem like the first _typed client_ getting the second _named client_ "wrongly" injected.



The non-obvious part of `HttpClientFactory` is that, by design, registering/configuring a _Named client_ with the same name several times would just **append** the configuration actions to the list of existing ones. This is the approach used by configuration APIs like `ConfigureNamedOptions`.

This is mostly useful for handler configurations, for example, adding some custom handler to a client defined externally, substituting something for tests etc, but it works for `HttpClient` actions as well. For example, this

```csharp
services.AddHttpClient("ITypedClient", c =>
    {
        c.BaseAddress = new Uri("http://example.com");
        c.DefaultRequestHeaders.UserAgent.ParseAdd("HttpClient/8.0");
    });
```

and this

```csharp
services.AddHttpClient("ITypedClient", c => c.BaseAddress = new Uri("http://example.com"));
services.AddHttpClient("ITypedClient")
    .ConfigureHttpClient(c => c.DefaultRequestHeaders.UserAgent.ParseAdd("HttpClient/8.0"));
```

will result in a client configured in the same way (both `BaseAddress` and `DefaultRequestHeaders` are set).

This enables linking a _Typed client_ to an already defined _Named client_, and/or, linking several _Typed clients_ to a single _Named client_. It is more obvious when overloads with a `name` parameter are used:

```csharp
services.AddHttpClient("LogClient", c => c.BaseAddress = new Uri(LogServerAddress));

services.AddHttpClient<FooLogger>("LogClient");
services.AddHttpClient<BarLogger>("LogClient");
```

However, if you _don't_ need to reuse the _Named client_, you need to explicitly specify different names for them:

```csharp
hostBuilder.Services.AddHttpClient<ITypedClient,TypedClient1>("example", x => x.BaseAddress = new Uri("http://example.com"));
hostBuilder.Services.AddHttpClient<ITypedClient,TypedClient2>("github", x => x.BaseAddress = new Uri("https://github.com"));
```

## See also

- [IHttpClientFactory with .NET][hcf]
- <xref:System.Net.Http.IHttpClientFactory>
- <xref:System.Net.Http.IHttpMessageHandlerFactory>
- <xref:System.Net.Http.HttpClient>
- [Make HTTP requests with the HttpClient][httpclient]

[hcf]: httpclient-factory.md
[httpclient]: ../../fundamentals/networking/http/httpclient.md
