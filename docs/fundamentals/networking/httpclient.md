---
title: Make HTTP requests with the HttpClient
description: Learn how to make HTTP requests and handle responses with the HttpClient in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/10/2022
---

# Make HTTP requests with the HttpClient

Hypertext Transfer Protocol (or HTTP) is a protocol for requesting resources from a web server. The <xref:System.Net.Http.HttpClient?displayProperty=fullName> class exposes the ability to send HTTP requests and receive HTTP responses from a resource identified by a URI. There are many types of resources that are available on the web, and HTTP defines a set of request methods for accessing these resources. The request methods are differentiated via several factors, first by their _verb_ but also by the following characteristics:

- A request method is **_idempotent_** if it can be successfully processed multiple times without changing the result. For more information, see [RFC 7231: Section 4.2.2 Idempotent Methods](https://datatracker.ietf.org/doc/html/rfc7231#section-4.2.2).
- A request method is **_cacheable_** when its corresponding response can be stored for reuse. For more information, see [RFC 7231: Section 4.2.3 Cacheable Methods](https://datatracker.ietf.org/doc/html/rfc7231#section-4.2.3).
- A request method is considered a **safe method** if it doesn't modify the state of a resource. All _safe methods_ are also _idempotent_, but not all _idempotent_ methods are considered _safe_. For more information, see [RFC 7231: Section 4.2.1 Safe Methods](https://datatracker.ietf.org/doc/html/rfc7231#section-4.2.1).

| HTTP verb | Is idempotent | Is cacheable         | Is safe |
|----------:|---------------|----------------------|---------|
| `GET`     | ✔️ Yes       | ✔️ Yes               | ✔️ Yes |
| `POST`    | ❌ No         | ⚠️ <sup>†</sup>Rarely | ❌ No   |
| `PUT`     | ✔️ Yes       | ❌ No                 | ❌ No   |
| `PATCH`   | ❌ No         | ❌ No                 | ❌ No   |
| `DELETE`  | ✔️ Yes       | ❌ No                 | ❌ No   |
| `HEAD`    | ✔️ Yes       | ✔️ Yes               | ✔️ Yes |
| `OPTIONS` | ✔️ Yes       | ❌ No                 | ✔️ Yes |
| `TRACE`   | ✔️ Yes       | ❌ No                 | ✔️ Yes |
| `CONNECT` | ❌ No         | ❌ No                 | ❌ No   |

<sup>†</sup>The `POST` method is only cacheable when the appropriate `Cache-Control` or `Expires` response headers are present.

In this article, you'll learn how to make HTTP requests and handle responses with the `HttpClient` class.

> [!IMPORTANT]
> All of the example HTTP requests target one of the following URLs:
>
> - <https://jsonplaceholder.typicode.com>: Free fake API for testing and prototyping.
> - <https://www.example.com>: This domain is for use in illustrative examples in documents.

Most commonly HTTP endpoints return JavaScript Object Notation (JSON) data, but not always. When they do, and as a convenience, the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package provides several extension methods for `HttpClient` and `HttpContent` that perform automatic serialization and deserialization using `System.Text.Json`. The examples below will call attention to when these extensions are available.

## Create an `HttpClient`

Most of the following examples reuse the same `HttpClient` instance, and therefore only need to be configured once. To create an `HttpClient`, use the `HttpClient` class constructor.

:::code language="csharp" source="snippets/httpclient/Program.cs" id="todoclient":::

The preceding code:

- Instantiates a new `HttpClient` instance.
- Sets the <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> to `"https://jsonplaceholder.typicode.com"`.

This `HttpClient` instance will always use the base address when making subsequent requests. Additional configuration can be applied, such as but not limited to:

- Setting <xref:System.Net.Http.HttpClient.DefaultRequestHeaders?displayProperty=nameWithType>.
- Applying a non-default <xref:System.Net.Http.HttpClient.Timeout?displayProperty=nameWithType>.
- Specifying the <xref:System.Net.Http.HttpClient.DefaultRequestVersion?displayProperty=nameWithType>.

Alternatively, you can create `HttpClient` instances using a factory-pattern approach that allows you to configure any number of clients and consume them as dependency injection services. For more information, see [IHttpClientFactory with .NET](../../core/extensions/httpclient-factory.md).

## Make an HTTP request

To make an HTTP request, you call any of the following APIs:

| HTTP verb                    | API                                                                                 |
|-----------------------------:|-------------------------------------------------------------------------------------|
| `GET`                        | <xref:System.Net.Http.HttpClient.GetAsync%2A?displayProperty=nameWithType>          |
| `GET`                        | <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A?displayProperty=nameWithType> |
| `GET`                        | <xref:System.Net.Http.HttpClient.GetStreamAsync%2A?displayProperty=nameWithType>    |
| `GET`                        | <xref:System.Net.Http.HttpClient.GetStringAsync%2A?displayProperty=nameWithType>    |
| `POST`                       | <xref:System.Net.Http.HttpClient.PostAsync%2A?displayProperty=nameWithType>         |
| `PUT`                        | <xref:System.Net.Http.HttpClient.PutAsync%2A?displayProperty=nameWithType>          |
| `PATCH`                      | <xref:System.Net.Http.HttpClient.PatchAsync%2A?displayProperty=nameWithType>        |
| `DELETE`                     | <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType>       |
| <sup>†</sup>`USER SPECIFIED` | <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType>         |

<sup>†</sup>A `USER SPECIFIED` request indicates that the `SendAsync` method accepts any valid <xref:System.Net.Http.HttpMethod>.

> [!WARNING]
> Making HTTP requests is considered network activity, and is I/O bound work. While there is a synchronous <xref:System.Net.Http.HttpClient.Send%2A?displayProperty=nameWithType> method, it is recommended to use the asynchronous APIs instead, unless you have good reason not to.

### HTTP Get

To make an HTTP `GET` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.GetAsync%2A?displayProperty=nameWithType> method:

:::code language="csharp" source="snippets/httpclient/Program.Get.cs" id="get":::

The preceding code:

- Makes a `GET` request to `"https://jsonplaceholder.typicode.com/todos/3"`.
- Ensures that the response is successful.
- Writes the request details to the console.
- Reads the response body as a string.
- Writes the JSON response body to the console.

The `WriteRequestToConsole` is a custom extension method that isn't part of the framework, but if you're curious how it's written, consider the following C# code:

:::code source="snippets/httpclient/HttpResponseMessageExtensions.cs":::

#### HTTP Get from JSON

The <https://jsonplaceholder.typicode.com/todos> endpoint returns a JSON array of `Todo` objects. The `Todo` object is defined as follows:

:::code source="snippets/httpclient/Todo.cs":::

It's a `record class` type, with the optional `Id`, `Title`, `Completed`, and `UserId` properties. To automatically deserialize `GET` requests into strongly-typed C# object, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> extension method that's part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code language="csharp" source="snippets/httpclient/Program.GetFromJson.cs" id="getfromjson":::

The preceding code:

- Makes a `GET` request to `"https://jsonplaceholder.typicode.com/todos?userId=1&completed=false"`.
  - The query string represents the filtering criteria for the request.
- The response is automatically deserialized into a `List<Todo>` when successful.
- The request details are written to the console, along with each `Todo`.

### HTTP Post

To make an HTTP `POST` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.PostAsync%2A?displayProperty=nameWithType> method:

:::code language="csharp" source="snippets/httpclient/Program.Post.cs" id="post":::

The preceding code:

- Prepares a <xref:System.Net.Http.StringContent> instance with the JSON body of the request.
- Makes a `POST` request to `"https://jsonplaceholder.typicode.com/todos"`.
- Ensures that the response is successful, and writes the request details to the console.
- Writes the response body as a string to the console.

#### HTTP Post as JSON

To automatically serialize `POST` request arguments and deserialize responses into strongly-typed C# objects, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> extension method that's part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code language="csharp" source="snippets/httpclient/Program.PostAsJson.cs" id="postasjson":::

The preceding code:

- Serializes the `Todo` instance as JSON, and makes a `POST` request to `"https://jsonplaceholder.typicode.com/todos"`.
- Ensures that the response is successful, and writes the request details to the console.
- Deserializes the response body into a `Todo` instance, and writes the `Todo` to the console.

### HTTP Put

To make an HTTP `PUT` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.PutAsync%2A?displayProperty=nameWithType> method:

:::code language="csharp" source="snippets/httpclient/Program.Put.cs" id="put":::

#### HTTP Put as JSON

:::code language="csharp" source="snippets/httpclient/Program.PutAsJson.cs" id="putasjson":::

### HTTP Patch

To make an HTTP `PATCH` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.PatchAsync%2A?displayProperty=nameWithType> method:

:::code language="csharp" source="snippets/httpclient/Program.Patch.cs" id="patch":::

### HTTP Delete

To make an HTTP `DELETE` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType> method:

:::code language="csharp" source="snippets/httpclient/Program.Delete.cs" id="delete":::

### HTTP Head

To make an HTTP `HEAD` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType> method with the <xref:System.Net.Http.HttpMethod> set to `HttpMethod.Head`:

:::code language="csharp" source="snippets/httpclient/Program.Head.cs" id="head":::

### HTTP Options

To make an HTTP `OPTIONS` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType> method with the <xref:System.Net.Http.HttpMethod> set to `HttpMethod.Options`:

:::code language="csharp" source="snippets/httpclient/Program.Options.cs" id="options":::

### HTTP Trace

To make an HTTP `TRACE` request, create an <xref:System.Net.Http.HttpRequestMessage> using the `HttpMethod.Trace`:

:::code language="csharp" source="snippets/httpclient/Program.Trace.cs" id="trace":::

> [!CAUTION]
> The `TRACE` HTTP verb is not supported by all HTTP servers. It can expose a security vulnerability if used unwisely. For more information, see [OWASP: Cross Site Tracing](https://owasp.org/www-community/attacks/Cross_Site_Tracing).

## Handle HTTP responses

Whenever you're handling an HTTP response, you interact with the <xref:System.Net.Http.HttpResponseMessage> type. Several members are used when evaluating the validity of a response. The HTTP status code is available via the <xref:System.Net.Http.HttpResponseMessage.StatusCode?displayProperty=nameWithType> property. Imagine that you've sent a request given a client instance:

:::code language="csharp" source="snippets/httpclient/Program.Responses.cs" id="request":::

To ensure that the `response` is `OK` (HTTP status code 200), you can evaluate it as shown in the following example:

:::code language="csharp" source="snippets/httpclient/Program.Responses.cs" id="isstatuscode":::

But there are additional HTTP status codes that represent a successful response, such as `CREATED` (HTTP status code 201), `ACCEPTED` (HTTP status code 202), `NO CONTENT` (HTTP status code 204), and `RESET CONTENT` (HTTP status code 205) to name a few. You can use the <xref:System.Net.Http.HttpResponseMessage.IsSuccessStatusCode?displayProperty=nameWithType> property to evaluate these codes as well, which ensures that the response status code is within the range 200-299:

:::code language="csharp" source="snippets/httpclient/Program.Responses.cs" id="issuccessstatuscode":::

If you need to have the framework throw the <xref:System.Net.Http.HttpRequestException>, you can call the <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/httpclient/Program.Responses.cs" id="ensurestatuscode":::

This will throw an `HttpRequestException` if the response status code is not within the range 200-299.

## See also

- [Guidelines for using HttpClient](httpclient-guidelines.md)
- [IHttpClientFactory with .NET](../../core/extensions/httpclient-factory.md)
- [Use HTTP/3 with HttpClient](../../core/extensions/httpclient-http3.md)
- [Test web APIs with the HttpRepl](/aspnet/core/web-api/http-repl)
