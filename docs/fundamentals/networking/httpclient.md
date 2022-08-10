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

| HTTP verb | Is idempotent | Is cacheable             | Is safe |
|-----------|---------------|--------------------------|---------|
| `GET`     | ✔️ Yes       | ✔️ Yes                   | ✔️ Yes |
| `POST`    | ❌ No         | ⚠️ <sup>**†**</sup>Rarely | ❌ No   |
| `PUT`     | ✔️ Yes       | ❌ No                     | ❌ No   |
| `PATCH`   | ❌ No         | ❌ No                     | ❌ No   |
| `DELETE`  | ✔️ Yes       | ❌ No                     | ❌ No   |
| `HEAD`    | ✔️ Yes       | ✔️ Yes                   | ✔️ Yes |
| `OPTIONS` | ✔️ Yes       | ❌ No                     | ✔️ Yes |
| `TRACE`   | ✔️ Yes       | ❌ No                     | ✔️ Yes |
| `CONNECT` | ❌ No         | ❌ No                     | ❌ No   |

<sup>**†**</sup>The `POST` method is only cacheable when the appropriate `Cache-Control` or `Expires` response headers are present.

In this article, you'll learn how to make HTTP requests and handle responses with the `HttpClient` class.

> [!NOTE]
> All of the example HTTP requests either rely on <https://jsonplaceholder.typicode.com> or <https://www.example.com>.

> [!TIP]
> Most commonly HTTP endpoints return JavaScript Object Notation (JSON) data, but not always. When they do, and as a convenience, the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package provides several extension methods for `HttpClient` and `HttpContent` that perform automatic serialization and deserialization using `System.Text.Json`.

## HTTP Get

:::code language="csharp" source="snippets/httpclient/Program.Get.cs" id="get":::

### HTTP Get extensions

:::code language="csharp" source="snippets/httpclient/Program.GetFromJson.cs" id="getfromjson":::

## HTTP Post

:::code language="csharp" source="snippets/httpclient/Program.Post.cs" id="post":::

### HTTP Post extensions

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
