---
title: HTTP with .NET
description: Learn how to use the HttpClient and IHttpClientFactory implementations with dependency injection in your .NET workloads.
author: IEvangelist
ms.author: dapine
ms.date: 11/12/2021
---

# HTTP with .NET

In this article, you'll learn how to use the `IHttpClientFactory` and the `HttpClient` types with various .NET fundamentals, such as dependency injection (DI), logging, and configuration. The <xref:System.Net.Http.HttpClient> type was introduced in .NET Framework 4.5, which was released in 2012. In other words, it's been around for a while. `HttpClient` is used for making HTTP requests and handling HTTP responses from web resources identified by a <xref:System.Uri>. The HTTP protocol makes up the vast majority of all internet traffic.

With modern application development principles driving best practices, the <xref:System.Net.Http.IHttpClientFactory> serves as a factory abstraction that can create `HttpClient` instances with custom configurations. <xref:System.Net.Http.IHttpClientFactory> was introduced in .NET Core 2.1. Common HTTP-based .NET workloads can take advantage of resilient and transient-fault-handling third-party middleware with ease.

## Explore the `IHttpClientFactory` type

All of the sample source code in this article relies on the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/microsoft.extensions.http) NuGet package. Additionally, [The Internet Chuck Norris Database](https://www.icndb.com) free API is used to make HTTP GET requests for "nerdy" jokes.

When you call any of the <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> extension methods, you're adding the `IHttpClientFactory` and related services to the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. The `IHttpClientFactory` type offers the following benefits:

- Exposes the `HttpClient` class as a DI-ready type.
- Provides a central location for naming and configuring logical `HttpClient` instances.
- Codifies the concept of outgoing middleware via delegating handlers in `HttpClient`.
- Provides extension methods for Polly-based middleware to take advantage of delegating handlers in `HttpClient`.
- Manages the pooling and lifetime of underlying <xref:System.Net.Http.HttpClientHandler> instances. Automatic management avoids common Domain Name System (DNS) problems that occur when manually managing `HttpClient` lifetimes.
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

:::code source="snippets/http/basic/JokeService.cs" highlight="9,13,15,20":::

Using `IHttpClientFactory` like in the preceding example is a good way to refactor an existing app. It has no impact on how `HttpClient` is used. In places where `HttpClient` instances are created in an existing app, replace those occurrences with calls to <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A>.

### Named clients

Named clients are a good choice when:

- The app requires many distinct uses of `HttpClient`.
- Many `HttpClient` instances have different configuration.

Configuration for a named `HttpClient` can be specified during registration in `ConfigureServices`:

:::code source="snippets/http/named/Program.cs" range="1-23" highlight="10-20":::

In the preceding code, the client is configured with:

- A name that's pulled from the configuration under the `"JokeHttpClientName"`.
- The base address `https://api.icndb.com/`.
- A `"User-Agent"` header.

You can use configuration to specify HTTP client names, which is helpful to avoid misnaming clients when adding and creating. In this example, the *appsettings.json* file is used to configure the HTTP client name:

:::code language="json" source="snippets/http/named/appsettings.json":::

It's easy to extend this configuration and store more details about how you'd like your HTTP client to function. For more information, see [Configuration in .NET][config].

#### Create client

Each time <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A> is called:

- A new instance of `HttpClient` is created.
- The configuration action is called.

To create a named client, pass its name into `CreateClient`:

:::code source="snippets/http/named/JokeService.cs" highlight="10,15,18-19,24-25,31-33":::

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

:::code source="snippets/http/typed/JokeService.cs" highlight="9,13,15,23-25":::

In the preceding code:

- The configuration is set when the typed client is added to the service collection.
- The `HttpClient` is assigned as a class-scoped variable (field), and used with exposed APIs.

API-specific methods can be created that expose `HttpClient` functionality. For example, the `GetRandomJokeAsync` method encapsulates code to retrieve a random joke.

The following code calls <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> in `ConfigureServices` to register a typed client class:

:::code source="snippets/http/typed/Program.cs" range="1-21" highlight="9-17":::

The typed client is registered as transient with DI. In the preceding code, `AddHttpClient` registers `JokeService` as a transient service. This registration uses a factory method to:

1. Create an instance of `HttpClient`.
1. Create an instance of `JokeService`, passing in the instance of `HttpClient` to its constructor.

> [!TIP]
> A call to `AddHttpClient<TClient>` doesn't add the `TClient` service to the `IServiceCollection`. You still need to explicitly add it with `Add{ServiceLifetime}`.

### Generated clients

`IHttpClientFactory` can be used in combination with third-party libraries such as [Refit](https://github.com/paulcbetts/refit). Refit is a REST library for .NET. It allows for declarative REST API definitions, mapping interface methods to endpoints. An implementation of the interface is generated dynamically by the `RestService`, using `HttpClient` to make the external HTTP calls.

Consider the following `record` types:

:::code source="snippets/http/shared/IdentifiableJokeValue.cs":::

:::code source="snippets/http/shared/ChuckNorrisJoke.cs":::

The following example relies on the [`Refit.HttpClientFactory`](https://www.nuget.org/packages/refit.httpclientfactory) NuGet package, and is a simple interface:

:::code source="snippets/http/generated/IJokeService.cs":::

The preceding C# interface:

- Defines a method named `GetRandomJokeAsync` that returns a `Task<ChuckNorrisJoke>` instance.
- Declares a `Refit.GetAttribute` attribute with the path and query string to the external API.

A typed client can be added, using Refit to generate the implementation:

:::code source="snippets/http/generated/Program.cs" range="1-22" highlight="11-19":::

The defined interface can be consumed where necessary, with the implementation provided by DI and Refit.

## Make POST, PUT, and DELETE requests

In the preceding examples, all HTTP requests use the GET HTTP verb. `HttpClient` also supports other HTTP verbs, including:

- POST
- PUT
- DELETE
- PATCH

For a complete list of supported HTTP verbs, see <xref:System.Net.Http.HttpMethod>.

The following example shows how to make an HTTP POST request:

:::code source="snippets/http/basic/ItemService.cs" id="Create":::

In the preceding code, the `CreateItemAsync` method:

- Serializes the `Item` parameter to JSON using `System.Text.Json`. This uses an instance of <xref:System.Text.Json.JsonSerializerOptions> to configure the serialization process.
- Creates an instance of <xref:System.Net.Http.StringContent> to package the serialized JSON for sending in the HTTP request's body.
- Calls <xref:System.Net.Http.HttpClient.PostAsync%2A> to send the JSON content to the specified URL. This is a relative URL that gets added to the [HttpClient.BaseAddress](xref:System.Net.Http.HttpClient.BaseAddress).
- Calls <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode%2A> to throw an exception if the response status code does not indicate success.

`HttpClient` also supports other types of content. For example, <xref:System.Net.Http.MultipartContent> and <xref:System.Net.Http.StreamContent>. For a complete list of supported content, see <xref:System.Net.Http.HttpContent>.

The following example shows an HTTP PUT request:

:::code source="snippets/http/basic/ItemService.cs" id="Update":::

The preceding code is very similar to the POST example. The `UpdateItemAsync` method calls <xref:System.Net.Http.HttpClient.PutAsync%2A> instead of `PostAsync`.

The following example shows an HTTP DELETE request:

:::code source="snippets/http/basic/ItemService.cs" id="Delete":::

In the preceding code, the `DeleteItemAsync` method calls <xref:System.Net.Http.HttpClient.DeleteAsync%2A>. Because HTTP DELETE requests typically contain no body, the `DeleteAsync` method doesn't provide an overload that accepts an instance of `HttpContent`.

To learn more about using different HTTP verbs with `HttpClient`, see <xref:System.Net.Http.HttpClient>.

## `HttpClient` lifetime management

A new `HttpClient` instance is returned each time `CreateClient` is called on the `IHttpClientFactory`. One <xref:System.Net.Http.HttpClientHandler> instance is created per client. The factory manages the lifetimes of the `HttpClientHandler` instances.

`IHttpClientFactory` pools the `HttpClientHandler` instances created by the factory to reduce resource consumption. An `HttpClientHandler` instance may be reused from the pool when creating a new `HttpClient` instance if its lifetime hasn't expired.

Pooling of handlers is desirable as each handler typically manages its own underlying HTTP connection. Creating more handlers than necessary can result in connection delays. Some handlers also keep connections open indefinitely, which can prevent the handler from reacting to DNS changes.

The default handler lifetime is two minutes. To override the default value, call <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.SetHandlerLifetime%2A> for each client, on the `IServiceCollection`:

```csharp
services.AddHttpClient("Named.Client")
    .SetHandlerLifetime(TimeSpan.FromMinutes(5));
```

> [!IMPORTANT]
> You can generally treat `HttpClient` instances as objects that **do not** require disposal. Disposal cancels outgoing requests and guarantees the given `HttpClient` instance can't be used after calling <xref:System.IDisposable.Dispose%2A>. `IHttpClientFactory` tracks and disposes resources used by `HttpClient` instances.

Keeping a single `HttpClient` instance alive for a long duration is a common pattern used before the inception of `IHttpClientFactory`. This pattern becomes unnecessary after migrating to `IHttpClientFactory`.

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

## See also

- [Dependency injection in .NET][di]
- [Logging in .NET][logging]
- [Configuration in .NET][config]
- <xref:System.Net.Http.IHttpClientFactory>
- <xref:System.Net.Http.HttpClient>
- [Implement HTTP retry with exponential backoff][http-retry]

[di]: dependency-injection.md
[logging]: logging.md
[config]: configuration.md
[http-retry]: ../../architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly.md
