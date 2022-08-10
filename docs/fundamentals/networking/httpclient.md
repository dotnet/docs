---
title: Make HTTP requests with the HttpClient
description: Learn how to make HTTP requests and handle responses with the HttpClient in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/10/2022
---

# Make HTTP requests with the HttpClient

Hypertext Transfer Protocol (or HTTP) is a protocol for requesting resources from a web server. The <xref:System.Net.Http.HttpClient?displayProperty=fullName> class exposes the ability to send HTTP requests and receive HTTP responses from a resource identified by a URI. There are many types of resources that are available on the web, and HTTP defines a set of request methods for accessing these resources. The request methods are described by several differentiators, first by their verb but also by the following characteristics:

- A request method is **_idempotent_** if it can be successfully processed multiple times without changing the result. For more information, see [RFC 7231: Section 4.2.2 Idempotent Methods](https://datatracker.ietf.org/doc/html/rfc7231#section-4.2.2).
- A request method is **_cacheable_** when its corresponding response is stored for reuse. For more information, see [RFC 7231: Section 4.2.3 Cacheable Methods](https://datatracker.ietf.org/doc/html/rfc7231#section-4.2.3).
- **Safe methods** are methods that don't modify the state of the resource. All _safe methods_ are also _idempotent_, but not all _idempotent_ methods are considered _safe_. For more information, see [RFC 7231: Section 4.2.1 Safe Methods](https://datatracker.ietf.org/doc/html/rfc7231#section-4.2.1).

| HTTP verb | Is idempotent | Is cacheable         | Is safe |
|-----------|---------------|----------------------|---------|
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

> [!NOTE]
> All of the example HTTP requests either rely on <https://jsonplaceholder.typicode.com> or <https://www.example.com>.

> [!TIP]
> Most commonly HTTP endpoints return JavaScript Object Notation (JSON) data, but not always. When they do, and as a convenience, the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package provides several extension methods for `HttpClient` and `HttpContent` that perform automatic serialization and deserialization using `System.Text.Json`.

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

## HTTP Get

To make an HTTP `GET` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.GetAsync%2A?displayProperty=nameWithType> method:

:::code language="csharp" source="snippets/httpclient/Program.Get.cs" id="get":::

### HTTP Get extensions

To automatically deserialize `GET` requests into strongly-typed C# object, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> extension method that is part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code language="csharp" source="snippets/httpclient/Program.GetFromJson.cs" id="getfromjson":::

## HTTP Post

:::code language="csharp" source="snippets/httpclient/Program.Post.cs" id="post":::

### HTTP Post extensions

To automatically serialize `POST` request arguments and deserialize responses into strongly-typed C# objects, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> extension method that is part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code language="csharp" source="snippets/httpclient/Program.PostAsJson.cs" id="postasjson":::

## HTTP Put

:::code language="csharp" source="snippets/httpclient/Program.Put.cs" id="put":::

### HTTP Put extensions

:::code language="csharp" source="snippets/httpclient/Program.PutAsJson.cs" id="putasjson":::

## HTTP Patch

:::code language="csharp" source="snippets/httpclient/Program.Patch.cs" id="patch":::

## HTTP Delete

:::code language="csharp" source="snippets/httpclient/Program.Delete.cs" id="delete":::

## HTTP Head

:::code language="csharp" source="snippets/httpclient/Program.Head.cs" id="head":::

## HTTP Options

:::code language="csharp" source="snippets/httpclient/Program.Options.cs" id="options":::

## HTTP Trace

:::code language="csharp" source="snippets/httpclient/Program.Trace.cs" id="trace":::

## See also

- [Guidelines for using HttpClient](httpclient-guidelines.md)
- [IHttpClientFactory with .NET](../../core/extensions/httpclient-factory.md)
- [Use HTTP/3 with HttpClient](../../core/extensions/httpclient-http3.md)
- [Test web APIs with the HttpRepl](/aspnet/core/web-api/http-repl)
