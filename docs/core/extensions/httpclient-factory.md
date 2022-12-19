---
title: Use the IHttpClientFactory
description: Learn how to use the HttpClient and IHttpClientFactory implementations with dependency injection in your .NET workloads.
author: IEvangelist
ms.author: dapine
ms.date: 12/07/2022
---

# IHttpClientFactory with .NET

In this article, you'll learn how to use the `IHttpClientFactory` to create `HttpClient` types with various .NET fundamentals, such as dependency injection (DI), logging, and configuration. The <xref:System.Net.Http.HttpClient> type was introduced in .NET Framework 4.5, which was released in 2012. In other words, it's been around for a while. `HttpClient` is used for making HTTP requests and handling HTTP responses from web resources identified by a <xref:System.Uri>. The HTTP protocol makes up the vast majority of all internet traffic.

With modern application development principles driving best practices, the <xref:System.Net.Http.IHttpClientFactory> serves as a factory abstraction that can create `HttpClient` instances with custom configurations. <xref:System.Net.Http.IHttpClientFactory> was introduced in .NET Core 2.1. Common HTTP-based .NET workloads can take advantage of resilient and transient-fault-handling third-party middleware with ease.

> [!NOTE]
> If your app requires cookies, it might be better to avoid using <xref:System.Net.Http.IHttpClientFactory> in your app. For alternative ways of managing clients, see [Guidelines for using HTTP clients](../../fundamentals/networking/http/httpclient-guidelines.md).

> [!IMPORTANT]
> Lifetime management of `HttpClient` instances created by `IHttpClientFactory` is completely different from instances created manually. The strategies are to use either **short-lived** clients created by `IHttpClientFactory` or **long-lived** clients with `PooledConnectionLifetime` set up. For more information, see the [HttpClient lifetime management](#httpclient-lifetime-management) section and [Guidelines for using HTTP clients](../../fundamentals/networking/http/httpclient-guidelines.md).

## The `IHttpClientFactory` type

All of the sample source code in this article relies on the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/microsoft.extensions.http) NuGet package. Additionally, HTTP `GET` requests are made to the free [{JSON} Placeholder](https://jsonplaceholder.typicode.com/) API to get user `Todo` objects.

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

:::code source="snippets/http/basic/Program.cs" range="1-13" highlight="10":::

Consuming services can require the `IHttpClientFactory` as a constructor parameter with [DI][di]. The following code uses `IHttpClientFactory` to create an `HttpClient` instance:

:::code source="snippets/http/basic/TodoService.cs" highlight="11,15,17,22":::

Using `IHttpClientFactory` like in the preceding example is a good way to refactor an existing app. It has no impact on how `HttpClient` is used. In places where `HttpClient` instances are created in an existing app, replace those occurrences with calls to <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A>.

### Named clients

Named clients are a good choice when:

- The app requires many distinct uses of `HttpClient`.
- Many `HttpClient` instances have different configuration.

Configuration for a named `HttpClient` can be specified during registration in `ConfigureServices`:

:::code source="snippets/http/named/Program.cs" range="1-23" highlight="10-20":::

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

:::code source="snippets/http/typed/TodoService.cs" highlight="10,14,16,24-26":::

In the preceding code:

- The configuration is set when the typed client is added to the service collection.
- The `HttpClient` is assigned as a class-scoped variable (field), and used with exposed APIs.

API-specific methods can be created that expose `HttpClient` functionality. For example, the `GetUserTodosAsync` method encapsulates code to retrieve user-specific `Todo` objects.

The following code calls <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> in `ConfigureServices` to register a typed client class:

:::code source="snippets/http/typed/Program.cs" range="1-23" highlight="10-18":::

The typed client is registered as transient with DI. In the preceding code, `AddHttpClient` registers `TodoService` as a transient service. This registration uses a factory method to:

1. Create an instance of `HttpClient`.
1. Create an instance of `TodoService`, passing in the instance of `HttpClient` to its constructor.

> [!IMPORTANT]
> Using typed clients in singleton services can be dangerous. For more information, see the [Using Typed clients in singleton services](#use-typed-clients-in-singleton-services) section.

### Generated clients

`IHttpClientFactory` can be used in combination with third-party libraries such as [Refit](https://github.com/paulcbetts/refit). Refit is a REST library for .NET. It allows for declarative REST API definitions, mapping interface methods to endpoints. An implementation of the interface is generated dynamically by the `RestService`, using `HttpClient` to make the external HTTP calls.

Consider the following `record` type:

:::code source="snippets/http/shared/Todo.cs":::

The following example relies on the [`Refit.HttpClientFactory`](https://www.nuget.org/packages/refit.httpclientfactory) NuGet package, and is a simple interface:

:::code source="snippets/http/generated/ITodoService.cs":::

The preceding C# interface:

- Defines a method named `GetUserTodosAsync` that returns a `Task<Todo[]>` instance.
- Declares a `Refit.GetAttribute` attribute with the path and query string to the external API.

A typed client can be added, using Refit to generate the implementation:

:::code source="snippets/http/generated/Program.cs" range="1-21" highlight="11-19":::

The defined interface can be consumed where necessary, with the implementation provided by DI and Refit.

## Make POST, PUT, and DELETE requests

In the preceding examples, all HTTP requests use the `GET` HTTP verb. `HttpClient` also supports other HTTP verbs, including:

- `POST`
- `PUT`
- `DELETE`
- `PATCH`

For a complete list of supported HTTP verbs, see <xref:System.Net.Http.HttpMethod>.

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

It may be necessary to control the configuration of the inner `HttpMessageHandler` used by a client.

An <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> is returned when adding named or typed clients. The <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method can be used to define a delegate on the `IServiceCollection`. The delegate is used to create and configure the primary `HttpMessageHandler` used by that client:

```csharp
services.AddHttpClient("Named.Client")
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            AllowAutoRedirect = false,
            UseDefaultCredentials = true
        };
    });
```

Configuring the `HttClientHandler` lets you specify a proxy for the `HttpClient` instance. For more information, see [Proxy per client](../../fundamentals/networking/http/httpclient.md#http-proxy).

### Additional configuration

There are several additional configuration options for controlling the `IHttpClientHandler`:

| Method | Description |
|--|--|
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> | Adds an additional message handler for a named `HttpClient`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddTypedClient%2A> | Configures the binding between the `TClient` and the named `HttpClient` associated with the `IHttpClientBuilder`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigureHttpClient%2A> | Adds a delegate that will be used to configure a named `HttpClient`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigureHttpMessageHandlerBuilder%2A> | Adds a delegate that will be used to configure message handlers using <xref:Microsoft.Extensions.Http.HttpMessageHandlerBuilder> for a named `HttpClient`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> | Configures the primary `HttpMessageHandler` from the dependency injection container for a named `HttpClient`. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.RedactLoggedHeaders%2A> | Sets the collection of HTTP header names for which values should be redacted before logging. |
| <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.SetHandlerLifetime%2A> | Sets the length of time that a `HttpMessageHandler` instance can be reused. Each named client can have its own configured handler lifetime value. |

## Using IHttpClientFactory together with SocketsHttpHandler

The `SocketsHttpHandler` implementation of `HttpMessageHandler` was added in .NET Core 2.1, which allows `PooledConnectionLifetime` to be configured. This setting is used to ensure that the handler reacts to DNS changes, so using `SocketsHttpHandler` is considered to be an alternative to using `IHttpClientFactory`. For more information, see [Guidelines for using HTTP clients](../../fundamentals/networking/http/httpclient-guidelines.md).

However, `SocketsHttpHandler` and `IHttpClientFactory` can be used together improve configurability. By using both of these APIs, you benefit from configurability on both a low level (for example, using `LocalCertificateSelectionCallback` for dynamic certificate selection) and a high level (for example, leveraging DI integration and several client configurations).

To use both APIs:

1. Specify `SocketsHttpHandler` as `PrimaryHandler` and set up its `PooledConnectionLifetime` (for example, to a value that was previously in `HandlerLifetime`).
1. As `SocketsHttpHandler` will handle connection pooling and recycling, then handler recycling at the `IHttpClientFactory` level is not needed anymore. You can disable it by setting `HandlerLifetime` to `Timeout.InfiniteTimeSpan`.

```csharp
services.AddHttpClient(name)
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new SocketsHttpHandler()
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2)
        };
    })
    .SetHandlerLifetime(Timeout.InfiniteTimeSpan); // Disable rotation, as it is handled by PooledConnectionLifetime
```

## Use typed clients in singleton services

When using the _named client_ approach, `IHttpClientFactory` is injected into services, and `HttpClient` instances are created by calling <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A> every time an `HttpClient` is needed.

However, with the _typed client_ approach, typed clients are transient objects usually injected into services. That may cause a problem because a typed client can be injected into a singleton service.

> [!IMPORTANT]
> Typed clients are expected to be **short-lived** in the same sense as `HttpClient` instances created by `IHttpClientFactory` (for more information, see [`HttpClient` lifetime management](#httpclient-lifetime-management)). As soon as a typed client instance is created, `IHttpClientFactory` has no control over it. If a typed client instance is captured in a singleton, it may prevent it from reacting to DNS changes, defeating one of the purposes of `IHttpClientFactory`.

If you need to use `HttpClient` instances in a singleton service, consider the following options:

- Use the _named client_ approach instead, injecting `IHttpClientFactory` in the singleton service and recreating `HttpClient` instances when necessary.
- If you require the _typed client_ approach, use `SocketsHttpHandler` with configured `PooledConnectionLifetime` as a primary handler. For more information on using `SocketsHttpHandler` with `IHttpClientFactory`, see the section [Using HttpClientFactory together with SocketsHttpHandler](#using-httpclientfactory-together-with-socketshttphandler).

## Message Handler Scopes in IHttpClientFactory

`IHttpClientFactory` creates a separate DI scope per each `HttpMessageHandler` instance. These DI scopes are separate from application DI scopes (for example, ASP.NET incoming request scope, or a user-created manual DI scope), so they will **not** share scoped service instances. Message Handler scopes are tied to handler lifetime and can outlive application scopes, which can lead to, for example, reusing the same `HttpMessageHandler` instance with same injected scoped dependencies between several incoming requests.

:::image type="content" source="media/httpclientfactory-scopes.png" alt-text="Diagram showing two application DI scopes and a separate message handler scope":::

Users are strongly advised **not to cache scope-related information** (such as data from `HttpContext`) inside `HttpMessageHandler` instances and use scoped dependencies with caution to avoid leaking sensitive information.

## See also

- [Dependency injection in .NET][di]
- [Logging in .NET][logging]
- [Configuration in .NET][config]
- <xref:System.Net.Http.IHttpClientFactory>
- <xref:System.Net.Http.HttpClient>
- [Make HTTP requests with the HttpClient][httpclient]
- [Implement HTTP retry with exponential backoff][http-retry]

[di]: dependency-injection.md
[logging]: logging.md
[config]: configuration.md
[httpclient]: ../../fundamentals/networking/http/httpclient.md
[http-retry]: ../../architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly.md
