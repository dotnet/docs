---
title: Use AutoClient to generate HTTP client dependencies
description: Learn how to source generate HttpClient dependent code implementations of AutoClient decorated interfaces.
author: IEvangelist
ms.author: dapine
ms.date: 09/06/2023
---

# Use AutoClient to generate HTTP client dependencies

In this article, you'll learn how to use the [Microsoft.Extensions.Http.AutoClient](https://www.nuget.org/packages/Microsoft.Extensions.Http.AutoClient) NuGet package to decorate an interface and generate a strongly typed HTTP client dependency. This is a great way to reduce the amount of boilerplate code you need to write when using the <xref:System.Net.Http.IHttpClientFactory> to create named HTTP clients. Relying on a source generator, the .NET AutoClient package generates the implementation of your interface, along with extension methods to register it into the dependency injection container. The source-generated code is written in a highly performant way, using the <xref:System.Net.Http.HttpClient> directly, without any reflection or dynamic code.

## Use the AutoClient attribute

The <xref:Microsoft.Extensions.Http.AutoClient.AutoClientAttribute> is a required attribute of HTTP auto clients. It receives the name of the <xref:System.Net.Http.HttpClient> to be retrieved from the <xref:System.Net.Http.IHttpClientFactory>, consider the following interface definition:

```csharp
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(httpClientName: "GeneratedClient")]
public interface IProductClient
{
}
```

The interface name must start with an `I`. It's used as the <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata.DependencyName?displayProperty=nameWithType> for the source-generated telemetry's <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata>. If the name ends in `Api` or `Client`, those are excluded. For example, if the interface is named `IProductClient`, the dependency name is `Product`.

To override the calculated dependency name, use the `customDependencyName` parameter of the <xref:Microsoft.Extensions.Http.AutoClient.AutoClientAttribute>.

```csharp
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(httpClientName: "GeneratedClient", customDependencyName: "Product Service")]
public interface IProductClient
{
}
```

## Define HTTP methods with verb attributes

An empty interface isn't a useful abstraction. To define HTTP methods, you must use the HTTP verb attributes. Each HTTP method must return a <xref:System.Threading.Tasks.Task%601> where `T` is any of the following types:

| Return type | Description |
|--|--|
| `Task<string>` | The raw content of the response, as a string, will be returned. |
| `Task<T>` | When `T` is any serializable type, the response content is deserialized from JSON and returned. |
| `Task<HttpResponseMessage>` | If you need the <xref:System.Net.Http.HttpResponseMessage> itself, as returned from <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType>, use this type. |

When the content type of the response isn't `application/json` and the method's return type isn't `Task<string>`, an exception is thrown.

### HTTP verb attributes

The HTTP method is defined using one of the following attributes:

- <xref:Microsoft.Extensions.Http.AutoClient.GetAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.PostAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.PutAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.PatchAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.DeleteAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.HeadAttribute?displayProperty=fullName>
- <xref:Microsoft.Extensions.Http.AutoClient.OptionsAttribute?displayProperty=fullName>

The attribute must receive the path to call the API. This path must not contain query parameters. The path is used as the <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata.RequestRoute?displayProperty=nameWithType> for telemetry. The path must be relative, to be used along with the base address of the <xref:System.Net.Http.HttpClient>.

HTTP methods decorated with any of the verb attributes must have a <xref:System.Threading.CancellationToken> parameter and it should be the last parameter defined. It can be defined as optional with `default`.

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

### Route parameters

The URL may contain route parameters, for example, `/api/users/{userId}`. To define a route parameter the method must accept a parameter with the same name:

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
- The `userId` parameter is used in the path of the request, replacing the `{userId}` placeholder.

### Telemetry request name

The method name is used as the <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata.RequestName?displayProperty=nameWithType>. If the method name ends in `Async`, that part is removed. For example, if a method is named `GetUsersAsync`, the request name is `GetUsers`.

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

To send a payload with your request, you must use the <xref:Microsoft.Extensions.Http.AutoClient.BodyAttribute> on a method parameter. If you don't pass any parameter to it, it treats the content type as JSON, serializing your parameter before sending. Otherwise, you define an explicit
<xref:Microsoft.Extensions.Http.AutoClient.BodyContentType> and use it within the <xref:Microsoft.Extensions.Http.AutoClient.BodyAttribute>.

```csharp
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient), "User Service")]
public interface IUserClient
{
    [Post("/api/users")]
    public Task<User> CreateUserAsync(
        [Body] User user);

    [Put("/api/users/{userId}/displayName")]
    public Task<User> UpdateDisplayNameAsync(
        string userId,
        [Body(BodyContentType.TextPlain)] string displayName,
        CancellationToken cancellationToken = default);
}
```

## HTTP headers

There are two ways of sending headers with your HTTP request. One of them is best suited for headers that never change value (static headers). The other way is headers that change based on the parameters of your methods.

### Static headers

To define a static header, you must use the <xref:Microsoft.Extensions.Http.AutoClient.StaticHeaderAttribute> on your interface. You must pass the header name and value to its constructor.

You can also use more than one <xref:Microsoft.Extensions.Http.AutoClient.StaticHeaderAttribute> together and in methods as well. If used in a method, that static
header is sent for that method only.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IUserClient), "User Service")]
[StaticHeader("X-MyHeader", "HeaderValue")]
public interface IUserClient
{
    [Get("/api/users")]
    [StaticHeader("X-MethodHeader", "HeaderValue")]
    public Task<List<User>> GetUsersAsync(
        CancellationToken cancellationToken = default);
}
```

### Parameter headers

Use the <xref:Microsoft.Extensions.Http.AutoClient.HeaderAttribute> to define parameter-based headers, where you can receive the value for a header from the attributes of your method. You must pass the header name to its constructor.

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

Query parameters are defined using the <xref:Microsoft.Extensions.Http.AutoClient.QueryAttribute> on a method's attribute. The parameter may be of any type. To set the query value, the `.ToString()` method is called on the value of the parameter.

The query key is the name of the parameter.

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

The `GetUsersAsync` method generates an HTTP request with a URL formatted like `/api/users?search={search}`. This format is used as the <xref:Microsoft.Extensions.Http.Telemetry.RequestMetadata.RequestRoute?displayProperty=nameWithType> for telemetry.

If you need to change the query key, you may pass a string parameter to the <xref:Microsoft.Extensions.Http.AutoClient.QueryAttribute>.

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

This time, the `GetUsersAsync` method generates an HTTP request with a URL formatted like `/api/users?customQueryKey={customQueryKey}`.

## Auto client's dependency injection hooks

Along with the interface's implementation, extension methods are generated to register it into the dependency injection container. The name of the generated extension method is the same as your interface name, replacing the leading `I` with `Add`.

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

You'd have registration code similar to the following:

```csharp
var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddHttpClient(
        nameof(IUserClient),
        client => client.BaseAddress = new Uri("<The REST API base address>"))
    .AddHttpClientMetering()
    .AddHttpClientLogging()
    .AddStandardResilienceHandler()
    .AddSocketsHttpHandler();

services.AddUserClient();
```

Then services would consume the client through its constructor:

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
