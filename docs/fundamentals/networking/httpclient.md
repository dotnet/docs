---
title: Make HTTP requests with the HttpClient
description: Learn how to make HTTP requests and handle responses with the HttpClient in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/09/2022
---

# Make HTTP requests with the HttpClient

The <xref:System.Net.Http.HttpClient> is a class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.

## HTTP Get

:::code language="csharp" source="snippets/httpclient/Program.Get.cs" id="get":::

## HTTP Post

:::code language="csharp" source="snippets/httpclient/Program.Post.cs" id="post":::

## HTTP Put

:::code language="csharp" source="snippets/httpclient/Program.Put.cs" id="put":::

## HTTP extensions

Most commonly HTTP endpoints return JavaScript Object Notation (JSON) data. As a convenience, the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package provides several extension methods for `HttpClient` and `HttpContent` that perform automatic serialization and deserialization using `System.Text.Json`.

:::code language="csharp" source="snippets/httpclient/Program.GetFromJson.cs" id="getfromjson":::

:::code language="csharp" source="snippets/httpclient/Program.PostAsJson.cs" id="postasjson":::

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
- [IHttpClientFactory with .NET](../../core/extensions/http-client-factory.md)
- [Use HTTP/3 with HttpClient](../../core/extensions/httpclient-http3.md)
- [Test web APIs with the HttpRepl](aspnet/core/web-api/http-repl)
