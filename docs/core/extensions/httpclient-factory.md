---
title: Use the IHttpClientFactory
description: Learn how to use the HttpClient and IHttpClientFactory implementations with dependency injection in your .NET workloads.
author: IEvangelist
ms.author: dapine
ms.date: 08/13/2024
---

# IHttpClientFactory with .NET

In this article, you'll learn how to use the `IHttpClientFactory` interface to create `HttpClient` types with various .NET fundamentals, such as dependency injection (DI), logging, and configuration. The <xref:System.Net.Http.HttpClient> type was introduced in .NET Framework 4.5, which was released in 2012. In other words, it's been around for a while. `HttpClient` is used for making HTTP requests and handling HTTP responses from web resources identified by a <xref:System.Uri>. The HTTP protocol makes up the vast majority of all internet traffic.

With modern application development principles driving best practices, the <xref:System.Net.Http.IHttpClientFactory> serves as a factory abstraction that can create `HttpClient` instances with custom configurations. <xref:System.Net.Http.IHttpClientFactory> was introduced in .NET Core 2.1. Common HTTP-based .NET workloads can take advantage of resilient and transient-fault-handling third-party middleware with ease.

> [!WARNING]
> If your app requires cookies, it's recommended to avoid using <xref:System.Net.Http.IHttpClientFactory>. Pooling the <xref:System.Net.Http.HttpMessageHandler> instances results in sharing of <xref:System.Net.CookieContainer> objects. Unanticipated <xref:System.Net.CookieContainer> sharing might leak cookies between unrelated parts of the application. Moreover, when <xref:Microsoft.Extensions.Http.HttpClientFactoryOptions.HandlerLifetime> expires, the handler is recycled, meaning that all cookies stored in its <xref:System.Net.CookieContainer> are lost.
> For alternative ways of managing clients, see [Guidelines for using HTTP clients](../../fundamentals/networking/http/httpclient-guidelines.md).

> [!IMPORTANT]
> Lifetime management of `HttpClient` instances created by `IHttpClientFactory` is completely different from instances created manually. The strategies are to use either **short-lived** clients created by `IHttpClientFactory` or **long-lived** clients with `PooledConnectionLifetime` set up. For more information, see the [HttpClient lifetime management](#httpclient-lifetime-management) section and [Guidelines for using HTTP clients](../../fundamentals/networking/http/httpclient-guidelines.md).

## The `IHttpClientFactory` type

All of the sample source code provided in this article requires the installation of the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/microsoft.extensions.http) NuGet package. Furthermore, the code examples demonstrate the usage of HTTP `GET` requests to retrieve user `Todo` objects from the free [{JSON} Placeholder](https://jsonplaceholder.typicode.com/) API.

When you call any of the <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> extension methods, you're adding the `IHttpClientFactory` and related services to the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. The `IHttpClientFactory` type offers the following benefits:

- Exposes the `HttpClient` class as a DI-ready type.
- Provides a central location for naming and configuring logical `HttpClient` instances.
- Codifies the concept of outgoing middleware via delegating handlers in `HttpClient`.
- Provides extension methods for Polly-based middleware to take advantage of delegating handlers in `HttpClient`.
- Manages the caching and lifetime of underlying <xref:System.Net.Http.HttpClientHandler> instances. Automatic management avoids common Domain Name System (DNS) problems that occur when manually managing `HttpClient` lifetimes.
- Adds a configurable logging experience (via <xref:Microsoft.Extensions.Logging.ILogger>) for all requests sent through clients created by the factory.

## Consumption patterns

There are several ways `IHttpClientFactory` can be used in an app:

* [Basic usage](#basic-usage)
* [Named clients](#named-clients)
* [Typed clients](#typed-clients)
* [Generated clients](#generated-clients)

The best approach depends upon the app's requirements.

### Basic usage

To register the `IHttpClientFactory`, call `AddHttpClient`:

:::code source="snippets/http/basic/Program.cs" range="1-12" highlight="9":::

Consuming services can require the `IHttpClientFactory` as a constructor parameter with [DI][di]. The following code uses `IHttpClientFactory` to create an `HttpClient` instance:

:::code source="snippets/http/basic/TodoService.cs" highlight="9,15,21-23":::

Using `IHttpClientFactory` like in the preceding example is a good way to refactor an existing app. It has no impact on how `HttpClient` is used. In places where `HttpClient` instances are created in an existing app, replace those occurrences with calls to <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A>.

### Named clients

Named clients are a good choice when:

- The app requires many distinct uses of `HttpClient`.
- Many `HttpClient` instances have different configurations.

Configuration for a named `HttpClient` can be specified during registration on the `IServiceCollection`:

:::code source="snippets/http/named/Program.cs" range="1-21" highlight="9-21":::

In the preceding code, the client is configured with:

- A name that's pulled from the configuration under the `"TodoHttpClientName"`.
- The base address `https://jsonplaceholder.typicode.com/`.
- A `"User-Agent"` header.

You can use configuration to specify HTTP client names, which is helpful to avoid misnaming clients when adding and creating. In this example, the *appsettings.json* file is used to configure the HTTP client name:

:::code language="json" source="snippets/http/named/appsettings.json":::

It's easy to extend this configuration and store more details about how you'd like your HTTP client to function. For more information, see [Configuration in .NET][config].

#### Create client

Each time <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A> is called:

- A new instance of `HttpClient` is created.
- The configuration action is called.

To create a named client, pass its name into `CreateClient`:

:::code source="snippets/http/named/TodoService.cs" highlight="11,16,19-20,25-26,32-34":::

In the preceding code, the HTTP request doesn't need to specify a hostname. The code can pass just the path, since the base address configured for the client is used.

### Typed clients

Typed clients:

- Provide the same capabilities as named clients without the need to use strings as keys.
- Provide [IntelliSense](/visualstudio/ide/using-intellisense) and compiler help when consuming clients.
- Provide a single location to configure and interact with a particular `HttpClient`. For example, a single typed client might be used:
  - For a single backend endpoint.
  - To encapsulate all logic dealing with the endpoint.
- Work with DI and can be injected where required in the app.

A typed client accepts an `HttpClient` parameter in its constructor:

:::code source="snippets/http/typed/TodoService.cs" highlight="9,18-20":::

In the preceding code:

- The configuration is set when the typed client is added to the service collection.
- The `HttpClient` is assigned as a class-scoped variable (field), and used with exposed APIs.

API-specific methods can be created that expose `HttpClient` functionality. For example, the `GetUserTodosAsync` method encapsulates code to retrieve user-specific `Todo` objects.

The following code calls <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> to register a typed client class:

:::code source="snippets/http/typed/Program.cs" range="1-17" highlight="9-17":::

The typed client is registered as transient with DI. In the preceding code, `AddHttpClient` registers `TodoService` as a transient service. This registration uses a factory method to:

1. Create an instance of `HttpClient`.
1. Create an instance of `TodoService`, passing in the instance of `HttpClient` to its constructor.

> [!IMPORTANT]
> Using typed clients in singleton services can be dangerous. For more information, see the [Avoid Typed clients in singleton services](#avoid-typed-clients-in-singleton-services) section.

> [!NOTE]
> When registering a typed client with the `AddHttpClient<TClient>` method, the `TClient` type must have a constructor that accepts an `HttpClient` as a parameter. Additionally, the `TClient` type shouldn't be registered with the DI container separately, as this will lead to the later registration overwriting the former.

### Generated clients

`IHttpClientFactory` can be used in combination with third-party libraries such as [Refit](https://www.nuget.org/packages/Refit/). Refit is a REST library for .NET. It allows for declarative REST API definitions, mapping interface methods to endpoints. An implementation of the interface is generated dynamically by the `RestService`, using `HttpClient` to make the external HTTP calls.

Consider the following `record` type:

:::code source="snippets/http/shared/Todo.cs":::

The following example relies on the [`Refit.HttpClientFactory`](https://www.nuget.org/packages/refit.httpclientfactory) NuGet package, and is a simple interface:

:::code source="snippets/http/generated/ITodoService.cs":::

The preceding C# interface:

- Defines a method named `GetUserTodosAsync` that returns a `Task<Todo[]>` instance.
- Declares a `Refit.GetAttribute` attribute with the path and query string to the external API.

A typed client can be added, using Refit to generate the implementation:

:::code source="snippets/http/generated/Program.cs" range="1-18" highlight="10-18":::

The defined interface can be consumed where necessary, with the implementation provided by DI and Refit.

## Make POST, PUT, and DELETE requests

In the preceding examples, all HTTP requests use the `GET` HTTP verb. `HttpClient` also supports other HTTP verbs, including:

- `POST`
- `PUT`
- `DELETE`
- `PATCH`

For a complete list of supported HTTP verbs, see <xref:System.Net.Http.HttpMethod>. For more information on making HTTP requests, see [Send a request using HttpClient](../../fundamentals/networking/http/httpclient.md).

The following example shows how to make an HTTP `POST` request:

:::code source="snippets/http/basic/ItemService.cs" id="Create":::

In the preceding code, the `CreateItemAsync` method:

- Serializes the `Item` parameter to JSON using `System.Text.Json`. This uses an instance of <xref:System.Text.Json.JsonSerializerOptions> to configure the serialization process.
- Creates an instance of <xref:System.Net.Http.StringContent> to package the serialized JSON for sending in the HTTP request's body.
- Calls <xref:System.Net.Http.HttpClient.PostAsync%2A> to send the JSON content to the specified URL. This is a relative URL that gets added to the [HttpClient.BaseAddress](xref:System.Net.Http.HttpClient.BaseAddress).
- Calls <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode%2A> to throw an exception if the response status code does not indicate success.

`HttpClient` also supports other types of content. For example, <xref:System.Net.Http.MultipartContent> and <xref:System.Net.Http.StreamContent>. For a complete list of supported content, see <xref:System.Net.Http.HttpContent>.

The following example shows an HTTP `PUT` request:

:::code source="snippets/http/basic/ItemService.cs" id="Update":::

The preceding code is very similar to the `POST` example. The `UpdateItemAsync` method calls <xref:System.Net.Http.HttpClient.PutAsync%2A> instead of `PostAsync`.

The following example shows an HTTP `DELETE` request:

:::code source="snippets/http/basic/ItemService.cs" id="Delete":::

In the preceding code, the `DeleteItemAsync` method calls <xref:System.Net.Http.HttpClient.DeleteAsync%2A>. Because HTTP DELETE requests typically contain no body, the `DeleteAsync` method doesn't provide an overload that accepts an instance of `HttpContent`.

To learn more about using different HTTP verbs with `HttpClient`, see <xref:System.Net.Http.HttpClient>.

## `HttpClient` lifetime management

A new `HttpClient` instance is returned each time `CreateClient` is called on the `IHttpClientFactory`. One <xref:System.Net.Http.HttpClientHandler> instance is created per client name. The factory manages the lifetimes of the `HttpClientHandler` instances.

`IHttpClientFactory` caches the `HttpClientHandler` instances created by the factory to reduce resource consumption. An `HttpClientHandler` instance may be reused from the cache when creating a new `HttpClient` instance if its lifetime hasn't expired.

Caching of handlers is desirable as each handler typically manages its own underlying HTTP connection pool. Creating more handlers than necessary can result in socket exhaustion and connection delays. Some handlers also keep connections open indefinitely, which can prevent the handler from reacting to DNS changes.

The default handler lifetime is two minutes. To override the default value, call <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.SetHandlerLifetime%2A> for each client, on the `IServiceCollection`:

```csharp
services.AddHttpClient("Named.Client")
    .SetHandlerLifetime(TimeSpan.FromMinutes(5));
```

> [!IMPORTANT]
> `HttpClient` instances created by `IHttpClientFactory` are intended to be **short-lived**.
>
> - Recycling and recreating `HttpMessageHandler`'s when their lifetime expires is essential for `IHttpClientFactory` to ensure the handlers react to DNS changes. `HttpClient` is tied to a specific handler instance upon its creation, so new `HttpClient` instances should be requested in a timely manner to ensure the client will get the updated handler.
>
> - Disposing of such `HttpClient` instances **created by the factory** will not lead to socket exhaustion, as its disposal **will not** trigger disposal of the `HttpMessageHandler`. `IHttpClientFactory` tracks and disposes of resources used to create `HttpClient` instances, specifically the `HttpMessageHandler` instances, as soon their lifetime expires and there's no `HttpClient` using them anymore.

Keeping a single `HttpClient` instance alive for a long duration is a common pattern that can be used as an **alternative** to `IHttpClientFactory`, however, this pattern requires additional setup, such as `PooledConnectionLifetime`. You can use either **long-lived** clients with `PooledConnectionLifetime`, or **short-lived** clients created by `IHttpClientFactory`. For information about which strategy to use in your app, see [Guidelines for using HTTP clients](../../fundamentals/networking/http/httpclient-guidelines.md).

## Configure the `HttpMessageHandler`

It may be necessary to control the configuration of the inner <xref:System.Net.Http.HttpMessageHandler> used by a client.

An <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> is returned when adding named or typed clients. The <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method can be used to define a delegate on the `IServiceCollection`. The delegate is used to create and configure the primary `HttpMessageHandler` used by that client:

:::code source="snippets/http/configurehandler/Program.cs" id="configurehandler":::

Configuring the `HttClientHandler` lets you specify a proxy for the `HttpClient` instance among various other properties of the handler. For more information, see [Proxy per client](../../fundamentals/networking/http/httpclient.md#configure-an-http-proxy).

### Additional configuration

There are several additional configuration options for controlling the `IHttpClientHandler`:

| Method | Description |
|--|--|
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> | Adds an additional message handler for a named `HttpClient`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddTypedClient%2A> | Configures the binding between the `TClient` and the named `HttpClient` associated with the `IHttpClientBuilder`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigureHttpClient%2A> | Adds a delegate that will be used to configure a named `HttpClient`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> | Configures the primary `HttpMessageHandler` from the dependency injection container for a named `HttpClient`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.RedactLoggedHeaders%2A> | Sets the collection of HTTP header names for which values should be redacted before logging. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.SetHandlerLifetime%2A> | Sets the length of time that a `HttpMessageHandler` instance can be reused. Each named client can have its own configured handler lifetime value. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.UseSocketsHttpHandler%2A> | Configures a new or a previously added `SocketsHttpHandler` instance from the dependency injection container to be used as a primary handler for a named `HttpClient`. (.NET 5+ only) |

## Using IHttpClientFactory together with SocketsHttpHandler

The `SocketsHttpHandler` implementation of `HttpMessageHandler` was added in .NET Core 2.1, which allows `PooledConnectionLifetime` to be configured. This setting is used to ensure that the handler reacts to DNS changes, so using `SocketsHttpHandler` is considered to be an alternative to using `IHttpClientFactory`. For more information, see [Guidelines for using HTTP clients](../../fundamentals/networking/http/httpclient-guidelines.md).

However, `SocketsHttpHandler` and `IHttpClientFactory` can be used together improve configurability. By using both of these APIs, you benefit from configurability on both a low level (for example, using `LocalCertificateSelectionCallback` for dynamic certificate selection) and a high level (for example, leveraging DI integration and several client configurations).

To use both APIs:

1. Specify `SocketsHttpHandler` as `PrimaryHandler` via <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A>, or <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.UseSocketsHttpHandler%2A> (.NET 5+ only).
1. Set up <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime?displayProperty=nameWithType> based on the interval you expect DNS to be updated; for example, to a value that was previously in `HandlerLifetime`.
1. (Optional) Since `SocketsHttpHandler` will handle connection pooling and recycling, handler recycling at the `IHttpClientFactory` level is no longer needed. You can disable it by setting `HandlerLifetime` to `Timeout.InfiniteTimeSpan`.

```csharp
services.AddHttpClient(name)
    .UseSocketsHttpHandler((handler, _) =>
        handler.PooledConnectionLifetime = TimeSpan.FromMinutes(2)) // Recreate connection every 2 minutes
    .SetHandlerLifetime(Timeout.InfiniteTimeSpan); // Disable rotation, as it is handled by PooledConnectionLifetime
```

In the example above, 2 minutes were chosen arbitrarily for illustration purposes, aligning to a default `HandlerLifetime` value. You should choose the value based on the expected frequency of DNS or other network changes. For more information, see the [DNS behavior](../../fundamentals/networking/http/httpclient-guidelines.md#dns-behavior) section in the `HttpClient` guidelines, and the Remarks section in the <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> API documentation.

## Avoid typed clients in singleton services

When using the _named client_ approach, `IHttpClientFactory` is injected into services, and `HttpClient` instances are created by calling <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A> every time an `HttpClient` is needed.

However, with the _typed client_ approach, typed clients are transient objects usually injected into services. That may cause a problem because a typed client can be injected into a singleton service.

> [!IMPORTANT]
> Typed clients are expected to be **short-lived** in the same sense as `HttpClient` instances created by `IHttpClientFactory` (for more information, see [`HttpClient` lifetime management](#httpclient-lifetime-management)). As soon as a typed client instance is created, `IHttpClientFactory` has no control over it. If a typed client instance is captured in a singleton, it may prevent it from reacting to DNS changes, defeating one of the purposes of `IHttpClientFactory`.

If you need to use `HttpClient` instances in a singleton service, consider the following options:

- Use the _named client_ approach instead, injecting `IHttpClientFactory` in the singleton service and recreating `HttpClient` instances when necessary.
- If you require the _typed client_ approach, use `SocketsHttpHandler` with configured `PooledConnectionLifetime` as a primary handler. For more information on using `SocketsHttpHandler` with `IHttpClientFactory`, see the section [Using IHttpClientFactory together with SocketsHttpHandler](#using-ihttpclientfactory-together-with-socketshttphandler).

## Message Handler Scopes in IHttpClientFactory

`IHttpClientFactory` creates a separate DI scope per each `HttpMessageHandler` instance. These DI scopes are separate from application DI scopes (for example, ASP.NET incoming request scope, or a user-created manual DI scope), so they will **not** share scoped service instances. Message Handler scopes are tied to handler lifetime and can outlive application scopes, which can lead to, for example, reusing the same `HttpMessageHandler` instance with same injected scoped dependencies between several incoming requests.

:::image type="content" source="media/httpclientfactory-scopes.png" alt-text="Diagram showing two application DI scopes and a separate message handler scope":::

Users are strongly advised **not to cache scope-related information** (such as data from `HttpContext`) inside `HttpMessageHandler` instances and use scoped dependencies with caution to avoid leaking sensitive information.

If you require access to an app DI scope from your message handler, for authentication as an example, you'd encapsulate scope-aware logic in a separate transient `DelegatingHandler`, and wrap it around an `HttpMessageHandler` instance from the `IHttpClientFactory` cache. To access the handler call <xref:System.Net.Http.IHttpMessageHandlerFactory.CreateHandler%2A?displayProperty=nameWithType> for any registered _named client_. In that case, you'd create an `HttpClient` instance yourself using the constructed handler.

:::image type="content" source="media/httpclientfactory-scopes-workaround.png" alt-text="Diagram showing gaining access to app DI scopes via a separate transient message handler and IHttpMessageHandlerFactory":::

The following example shows creating an `HttpClient` with a scope-aware `DelegatingHandler`:

:::code source="snippets/http/scopeworkaround/ScopeAwareHttpClientFactory.cs" id="CreateClient":::

A further workaround can follow with an extension method for registering a scope-aware `DelegatingHandler` and overriding default `IHttpClientFactory` registration by a transient service with access to the current app scope:

:::code source="snippets/http/scopeworkaround/ScopeAwareHttpClientFactory.cs" id="AddScopeAwareHttpHandler":::

For more information, see the [full example](https://github.com/dotnet/docs/tree/main/docs/core/extensions/snippets/http/scopeworkaround).

## Avoid depending on "factory-default" Primary Handler

In this section, the term _"factory-default" Primary Handler_ refers to the Primary Handler that the default `IHttpClientFactory` implementation (or more precisely, the default `HttpMessageHandlerBuilder` implementation) assigns if _not configured in any way_ whatsoever.

> [!NOTE]
> The "factory-default" Primary Handler is an _implementation detail_ and subject to change.
> ❌ AVOID depending on a specific implementation being used as a "factory-default" (for example, `HttpClientHandler`).

There are cases in which you need to know the specific type of a Primary Handler, especially if working on a class library. While preserving the end user's configuration, you might want to update, for example, `HttpClientHandler`-specific properties like `ClientCertificates`, `UseCookies`, and `UseProxy`. It might be tempting to cast the Primary handler to `HttpClientHandler`, which _happened to_ work while `HttpClientHandler` was used as the "factory-default" Primary Handler. But as any code depending on implementation details, such a workaround is _fragile_ and bound to break.

Instead of relying on the "factory-default" Primary Handler, you can use `ConfigureHttpClientDefaults` to set up an "app-level" default Primary Handler instance:

```csharp
// Contract with the end-user: Only HttpClientHandler is supported.

// --- "Pre-configure" stage ---
// The default is fixed as HttpClientHandler to avoid depending on the "factory-default"
// Primary Handler.
services.ConfigureHttpClientDefaults(b =>
    b.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { UseCookies = false }));

// --- "End-user" stage ---
// IHttpClientBuilder builder = services.AddHttpClient("test", /* ... */);
// ...

// --- "Post-configure" stage ---
// The code can rely on the contract, and cast to HttpClientHandler only.
builder.ConfigurePrimaryHttpMessageHandler((handler, provider) =>
    {
        if (handler is not HttpClientHandler h)
        {
            throw new InvalidOperationException("Only HttpClientHandler is supported");
        }

        h.ClientCertificates.Add(GetClientCert(provider, builder.Name));

        //X509Certificate2 GetClientCert(IServiceProvider p, string name) { ... }
    });
```

Alternatively, you can consider checking the Primary Handler type, and configure the specifics like client certificates only in the well-known supporting types (most likely, `HttpClientHandler` and `SocketsHttpHandler`):

```csharp
// --- "End-user" stage ---
// IHttpClientBuilder builder = services.AddHttpClient("test", /* ... */);
// ...

// --- "Post-configure" stage ---
// No contract is in place. Trying to configure main handler types supporting client
// certs, logging and skipping otherwise.
builder.ConfigurePrimaryHttpMessageHandler((handler, provider) =>
    {
        if (handler is HttpClientHandler h)
        {
            h.ClientCertificates.Add(GetClientCert(provider, builder.Name));
        }
        else if (handler is SocketsHttpHandler s)
        {
            s.SslOptions ??= new System.Net.Security.SslClientAuthenticationOptions();
            s.SslOptions.ClientCertificates ??= new X509CertificateCollection();
            s.SslOptions.ClientCertificates!.Add(GetClientCert(provider, builder.Name));
        }
        else
        {
            // Log warning
        }

        //X509Certificate2 GetClientCert(IServiceProvider p, string name) { ... }
    });
```

## See also

- [Common `IHttpClientFactory` usage issues][hcf-issues]
- [Dependency injection in .NET][di]
- [Logging in .NET][logging]
- [Configuration in .NET][config]
- <xref:System.Net.Http.IHttpClientFactory>
- <xref:System.Net.Http.IHttpMessageHandlerFactory>
- <xref:System.Net.Http.HttpClient>
- [Make HTTP requests with the HttpClient][httpclient]
- [Implement HTTP retry with exponential backoff][http-retry]

[hcf-issues]: httpclient-factory-troubleshooting.md
[di]: dependency-injection.md
[logging]: logging.md
[config]: configuration.md
[httpclient]: ../../fundamentals/networking/http/httpclient.md
[http-retry]: ../../architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly.md
