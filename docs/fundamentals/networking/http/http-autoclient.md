---
title: Use the REST API HTTP client generator
description: Learn how to generate HttpClient-dependent code implementations of AutoClient decorated interfaces.
author: IEvangelist
ms.author: dapine
ms.date: 09/06/2023
---

# Use the REST API HTTP client generator

The <xref:System.Net.Http.HttpClient> is a great way to consume REST APIs, but it's not without its challenges. One of the challenges is the amount of boilerplate code you need to write to consume the API. In this article, you learn how to use the [Microsoft.Extensions.Http.AutoClient](https://www.nuget.org/packages/Microsoft.Extensions.Http.AutoClient) NuGet package to decorate an interface and generate an HTTP client dependency. The AutoClient's underlying source generator generates the implementation of your interface, along with extension methods to register it into the dependency injection container. Additionally, the AutoClient generates telemetry for each HTTP request, which is sent to the <xref:Microsoft.Extensions.Http.Telemetry.IHttpTelemetrySink>.

## Use the `AutoClientAttribute`

The <xref:Microsoft.Extensions.Http.AutoClient.AutoClientAttribute> is responsible for triggering the AutoClient generator to emit the corresponding implementation of the decorated interface. It accepts the `httpClientName` of the <xref:System.Net.Http.HttpClient> to be retrieved from the <xref:System.Net.Http.IHttpClientFactory>. Consider the following interface definition:

```csharp
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(httpClientName: "GeneratedClient")]
public interface IProductClient
{
}
```

> [!TIP]
> The interface name must start with an `I`. The name is stripped of the leading `I`, and used as the <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata.DependencyName?displayProperty=nameWithType> for telemetry's <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata>. If the name ends in `Api` or `Client`, those are excluded. For example, if the interface is named `IProductClient`, the dependency name is `Product`.

To override the calculated dependency name, use the `customDependencyName` parameter of the <xref:Microsoft.Extensions.Http.AutoClient.AutoClientAttribute>.

```csharp
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(
    httpClientName: "GeneratedClient",
    customDependencyName: "Product Service")]
public interface IProductClient
{
}
```

## Define HTTP methods with verb attributes

An empty interface isn't a useful abstraction. To define HTTP methods, you must use the HTTP verb attributes. Each HTTP method returns a <xref:System.Threading.Tasks.Task%601> where `T` is any of the following types:

| Return type | Description |
|--|--|
| `Task<string>` | The raw content of the response is returned as a string. |
| `Task<T>` | When `T` is any serializable type, the response content is deserialized from JSON and returned. |
| `Task<HttpResponseMessage>` | If you need the <xref:System.Net.Http.HttpResponseMessage> itself, as returned from <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType>, use this type. |

When the content type of the HTTP response isn't `application/json` and the method's return type isn't `Task<string>`, an exception is thrown.

### HTTP verb attributes

An HTTP method is defined using one of the following attributes:

- <xref:Microsoft.Extensions.Http.AutoClient.GetAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.PostAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.PutAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.PatchAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.DeleteAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.HeadAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.OptionsAttribute?displayProperty=fullName>

Each attribute requires a `path` argument that routes to the underlying REST API, and it should be relative to the <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType>. The `path` can't contain query string parameters, instead the <xref:Microsoft.Extensions.Http.AutoClient.QueryAttribute> is used. From the perspective of telemetry, the `path` is used as the <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata.RequestRoute?displayProperty=nameWithType>.

HTTP methods decorated with any of the verb attributes must have a <xref:System.Threading.CancellationToken> parameter and it should be the last parameter defined. The `CancellationToken` parameter is used to cancel the HTTP request.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient("GeneratedClient")]
public interface IProductClient
{
    [Get("/api/users")]
    public Task<User[]> GetUsersAsync(
        CancellationToken cancellationToken = default);
}
```

The preceding code:

- Defines an HTTP method using the <xref:Microsoft.Extensions.Http.AutoClient.GetAttribute>.
- The `path` is `/api/users`.
- The method returns a <xref:System.Threading.Tasks.Task%601> where `T` is `User[]`.
- The method accepts an optional <xref:System.Threading.CancellationToken> parameter that is assigned to `default`.

### Route parameters

The URL may contain route parameters, for example, `"/api/users/{userId}"`. To define a route parameter the method must also accept a parameter with the same name, in this case, `userId`:

```csharp
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient), "User Service")]
public interface IUserClient
{
    [Get("/api/users/{userId}")]
    public Task<User> GetUserAsync(
        string userId,
        CancellationToken cancellationToken = default);
}
```

In the preceding code:

- The `GetUserAsync` method has a route parameter named `userId`.
- The `userId` parameter is used in the `path` of the request, replacing the `{userId}` placeholder.

### Telemetry request name

The method name is used as the <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata.RequestName?displayProperty=nameWithType>. If the method name includes the `Async` suffix, it's removed. For example, a method named `GetUsersAsync` is calculated as `"GetUsers"`.

To override the name, use the `RequestName` property of each attribute of the [HTTP verb attributes](#http-verb-attributes).

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient), "User Service")]
public interface IUserClient
{
    [Get("/api/users", RequestName = "CustomRequestName")]
    public Task<List<User>> GetUsersAsync(
        CancellationToken cancellationToken = default);
}
```

## HTTP payloads

To send an HTTP payload with your request, use the <xref:Microsoft.Extensions.Http.AutoClient.BodyAttribute> on a method's parameter. If you don't pass any parameter to it, it treats the content type as JSON, serializing your parameter before sending. Otherwise, you define an explicit
<xref:Microsoft.Extensions.Http.AutoClient.BodyContentType> and use it within the <xref:Microsoft.Extensions.Http.AutoClient.BodyAttribute>.

```csharp
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient), "User Service")]
public interface IUserClient
{
    [Post("/api/users")]
    public Task<User> CreateUserAsync(
        // The content type is JSON
        // The parameter is serialized before sending
        [Body] User user);

    [Put("/api/users/{userId}/displayName")]
    public Task<User> UpdateDisplayNameAsync(
        string userId,
        // The content type is text/plain
        // The parameter is sent as is
        [Body(BodyContentType.TextPlain)] string displayName,
        CancellationToken cancellationToken = default);
}
```

## HTTP headers

There are two ways of sending headers with your HTTP request. One of them is best suited for headers that never change value (static headers). The other way is headers that change based on the parameters of your methods.

### Static headers

To define a static header, use the <xref:Microsoft.Extensions.Http.AutoClient.StaticHeaderAttribute> on your interface definition. Pass the header name and value to its constructor.

You can also use more than one <xref:Microsoft.Extensions.Http.AutoClient.StaticHeaderAttribute> together and in methods as well. When the `StaticHeader` attribute is used on a method, that HTTP header is sent for that method only, whereas the interface-level `StaticHeader` attribute is sent for all methods.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient), "User Service")]
[StaticHeader("X-ForAllRequests", "GlobalHeaderValue")]
public interface IUserClient
{
    [Get("/api/users")]
    [StaticHeader("X-ForJustThisRequest", "RequestHeaderValue")]
    public Task<List<User>> GetUsersAsync(
        CancellationToken cancellationToken = default);
}
```

### Parameter headers

Use the <xref:Microsoft.Extensions.Http.AutoClient.HeaderAttribute> to define parameter-based headers, where you can receive the value for a header from the attributes of your method. Pass the header name to its constructor.

The parameter may be of any type. When the header type is anything other than a `string`, the `.ToString()` method is called on the value of the parameter.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient), "User Service")]
public interface IUserClient
{
    [Get("/api/users")]
    public Task<List<User>> GetUsersAsync(
        [Header("X-MyHeader")] string myHeader,
        CancellationToken cancellationToken = default);
}
```

## Query parameters

Query parameters are defined using the <xref:Microsoft.Extensions.Http.AutoClient.QueryAttribute> on a method's parameter. All types are valid, and the query value relies on the `.ToString()` method to get the value of the parameter when not a `string` type.

The <xref:Microsoft.Extensions.Http.AutoClient.QueryAttribute.Key?displayProperty=nameWithType> is assigned from the name of the parameter.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient))]
public interface IUserClient
{
    [Get("/api/users")]
    public Task<List<User>> GetUsersAsync(
        [Query] string search,
        CancellationToken cancellationToken = default);
}
```

The `GetUsersAsync` method generates an HTTP request with a URL formatted as `/api/users?search={search}`. This format is used as the <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata.RequestRoute?displayProperty=nameWithType> for telemetry.

If you need to change the query key, you may call the `key` parameter-based constructor, <xref:Microsoft.Extensions.Http.AutoClient.QueryAttribute.%23ctor(System.String)>.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient))]
public interface IUserClient
{
    [Get("/api/users")]
    public Task<List<User>> GetUsersAsync(
        [Query("customQueryKey")] string search,
        CancellationToken cancellationToken = default);
}
```

The `GetUsersAsync` method generates an HTTP request with a URL formatted like `/api/users?customQueryKey={customQueryKey}`, as the key name was overridden to `customQueryKey`.

## Auto client's dependency injection hooks

Along with the interface's implementation, extension methods are generated to register the client in the dependency injection container. The name of the generated extension method is the same as your interface name, replacing the leading `I` with `Add`.

For example, consider the following interface definition:

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient))]
public interface IUserClient
{
    [Get("/api/users")]
    public Task<List<User>> GetUsersAsync(
        CancellationToken cancellationToken = default);
}
```

While the generator emits the implementation of the `IUserClient` interface, it also generates the `AddUserClient` extension method on the `IServiceCollection`. Consider the following registration code:

```csharp
var builder = Host.CreateApplicationBuilder(args);

// Add the named HttpClient to the service collection
builder.Services.AddHttpClient(
    nameof(IUserClient),
    client =>
    {
        client.BaseAddress = new Uri("<The REST API base address>");
    });

// Add the IUserClient/UserClient to the service collection
builder.Services.AddUserClient();
```

In the preceding example code:

- The <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(System.String[])?displayProperty=fullName> is used to create a <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder>.
- The <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> is retrieved from the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder.Services?displayProperty=nameWithType> property, to call the `AddHttpClient` extension method.
  - The `AddHttpClient` extension method is called with the name of the <xref:System.Net.Http.HttpClient> to be registered, and a delegate to configure the <xref:System.Net.Http.HttpClient> instance.
- The `AddUserClient` extension method is called to register the <xref:IUserClient> interface and its implementation.

Consuming the client is as simple as injecting it into your service's constructor:

```csharp
public sealed class UserService(IUserClient userClient)
{
    public async Task ProcessUsersAsync()
    {
        var users = await userClient.GetUsersAsync();
        // ...
    }
}
```

For more information, see [.NET dependency injection](../../../core/extensions/dependency-injection.md).
