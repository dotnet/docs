---
title: Make HTTP requests with the HttpClient
description: Learn how to make HTTP requests and handle responses with the HttpClient in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 11/02/2023
---

# Make HTTP requests with the HttpClient class

In this article, you'll learn how to make HTTP requests and handle responses with the `HttpClient` class.

> [!IMPORTANT]
> All of the example HTTP requests target one of the following URLs:
>
> - <https://jsonplaceholder.typicode.com>: Free fake API for testing and prototyping.
> - <https://www.example.com>: This domain is for use in illustrative examples in documents.

HTTP endpoints commonly return JavaScript Object Notation (JSON) data, but not always. For convenience, the optional [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package provides several extension methods for `HttpClient` and `HttpContent` that perform automatic serialization and deserialization using `System.Text.Json`. The examples that follow call attention to places where these extensions are available.

> [!TIP]
> All of the source code from this article is available in the [GitHub: .NET Docs](https://github.com/dotnet/docs/tree/main/docs/fundamentals/networking/snippets/httpclient) repository.

## Create an `HttpClient`

Most of the following examples reuse the same `HttpClient` instance, and therefore only need to be configured once. To create an `HttpClient`, use the `HttpClient` class constructor. For more information, see [Guidelines for using HttpClient](httpclient-guidelines.md).

:::code source="../snippets/httpclient/Program.cs" id="sharedclient":::

The preceding code:

- Instantiates a new `HttpClient` instance as a `static` variable. As per the [guidelines](httpclient-guidelines.md), it's recommended to reuse `HttpClient` instances during the application's lifecycle.
- Sets the <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> to `"https://jsonplaceholder.typicode.com"`.

This `HttpClient` instance uses the base address when making subsequent requests. To apply other configuration, consider:

- Setting <xref:System.Net.Http.HttpClient.DefaultRequestHeaders?displayProperty=nameWithType>.
- Applying a nondefault <xref:System.Net.Http.HttpClient.Timeout?displayProperty=nameWithType>.
- Specifying the <xref:System.Net.Http.HttpClient.DefaultRequestVersion?displayProperty=nameWithType>.

> [!TIP]
> Alternatively, you can create `HttpClient` instances using a factory-pattern approach that allows you to configure any number of clients and consume them as dependency injection services. For more information, see [IHttpClientFactory with .NET](../../../core/extensions/httpclient-factory.md).

## Make an HTTP request

To make an HTTP request, you call any of the following APIs:

| HTTP method                  | API                                                                                 |
|------------------------------|-------------------------------------------------------------------------------------|
| `GET`                        | <xref:System.Net.Http.HttpClient.GetAsync%2A?displayProperty=nameWithType>          |
| `GET`                        | <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A?displayProperty=nameWithType> |
| `GET`                        | <xref:System.Net.Http.HttpClient.GetStreamAsync%2A?displayProperty=nameWithType>    |
| `GET`                        | <xref:System.Net.Http.HttpClient.GetStringAsync%2A?displayProperty=nameWithType>    |
| `POST`                       | <xref:System.Net.Http.HttpClient.PostAsync%2A?displayProperty=nameWithType>         |
| `PUT`                        | <xref:System.Net.Http.HttpClient.PutAsync%2A?displayProperty=nameWithType>          |
| `PATCH`                      | <xref:System.Net.Http.HttpClient.PatchAsync%2A?displayProperty=nameWithType>        |
| `DELETE`                     | <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType>       |
| <sup>†</sup>`USER SPECIFIED` | <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType>         |

> <sup>†</sup>A `USER SPECIFIED` request indicates that the `SendAsync` method accepts any valid <xref:System.Net.Http.HttpMethod>.

> [!WARNING]
> Making HTTP requests is considered network I/O-bound work. While there is a synchronous <xref:System.Net.Http.HttpClient.Send%2A?displayProperty=nameWithType> method, it is recommended to use the asynchronous APIs instead, unless you have good reason not to.

### HTTP content

The <xref:System.Net.Http.HttpContent> type is used to represent an HTTP entity body and corresponding content headers. For HTTP methods (or request methods) that require a body, `POST`, `PUT`, and `PATCH`, you use the <xref:System.Net.Http.HttpContent> class to specify the body of the request. Most examples show how to prepare the  <xref:System.Net.Http.StringContent> subclass with a JSON payload, but other subclasses exist for different [content (MIME) types](https://developer.mozilla.org/docs/Web/HTTP/Basics_of_HTTP/MIME_types).

- <xref:System.Net.Http.ByteArrayContent>: Provides HTTP content based on a byte array.
- <xref:System.Net.Http.FormUrlEncodedContent>: Provides HTTP content for name/value tuples encoded using `"application/x-www-form-urlencoded"` MIME type.
- <xref:System.Net.Http.Json.JsonContent>: Provides HTTP content based on JSON.
- <xref:System.Net.Http.MultipartContent>: Provides a collection of HttpContent objects that get serialized using the `"multipart/*"` MIME type specification.
- <xref:System.Net.Http.MultipartFormDataContent>: Provides a container for content encoded using `"multipart/form-data"` MIME type.
- <xref:System.Net.Http.ReadOnlyMemoryContent>: Provides HTTP content based on a <xref:System.ReadOnlyMemory%601>.
- <xref:System.Net.Http.StreamContent>: Provides HTTP content based on a stream.
- <xref:System.Net.Http.StringContent>: Provides HTTP content based on a string.

The `HttpContent` class is also used to represent the response body of the <xref:System.Net.Http.HttpResponseMessage>, accessible on the <xref:System.Net.Http.HttpResponseMessage.Content?displayProperty=nameWithType> property.

### HTTP Get

A `GET` request shouldn't send a body and is used (as the method name indicates) to retrieve (or get) data from a resource. To make an HTTP `GET` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.GetAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Get.cs" id="get":::

The preceding code:

- Makes a `GET` request to `"https://jsonplaceholder.typicode.com/todos/3"`.
- Ensures that the response is successful.
- Writes the request details to the console.
- Reads the response body as a string.
- Writes the JSON response body to the console.

The `WriteRequestToConsole` is a custom extension method that isn't part of the framework, but if you're curious about how it's implemented, consider the following C# code:

:::code source="../snippets/httpclient/HttpResponseMessageExtensions.cs":::

This functionality is used to write the request details to the console in the following form:

  `<HTTP Request Method> <Request URI> <HTTP/Version>`

As an example, the `GET` request to `https://jsonplaceholder.typicode.com/todos/3` outputs the following message:

```Output
GET https://jsonplaceholder.typicode.com/todos/3 HTTP/1.1
```

#### HTTP Get from JSON

The <https://jsonplaceholder.typicode.com/todos> endpoint returns a JSON array of "todo" objects. Their JSON structure resembles the following:

```json
[
  {
    "userId": 1,
    "id": 1,
    "title": "example title",
    "completed": false
  },
  {
    "userId": 1,
    "id": 2,
    "title": "another example title",
    "completed": true
  },
]
```

The C# `Todo` object is defined as follows:

:::code source="../snippets/httpclient/Todo.cs":::

It's a `record class` type, with optional `Id`, `Title`, `Completed`, and `UserId` properties. For more information on the `record` type, see [Introduction to record types in C#](../../../csharp/fundamentals/types/records.md). To automatically deserialize `GET` requests into strongly-typed C# object, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> extension method that's part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code source="../snippets/httpclient/Program.GetFromJson.cs" id="getfromjson":::

In the preceding code:

- A `GET` request is made to `"https://jsonplaceholder.typicode.com/todos?userId=1&completed=false"`.
  - The query string represents the filtering criteria for the request.
- The response is automatically deserialized into a `List<Todo>` when successful.
- The request details are written to the console, along with each `Todo` object.

### HTTP Post

A `POST` request sends data to the server for processing. The `Content-Type` header of the request signifies what [MIME type](xref:System.Net.Mime.ContentType) the body is sending. To make an HTTP `POST` request, given an `HttpClient` and a <xref:System.Uri>, use the <xref:System.Net.Http.HttpClient.PostAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Post.cs" id="post":::

The preceding code:

- Prepares a <xref:System.Net.Http.StringContent> instance with the JSON body of the request (MIME type of `"application/json"`).
- Makes a `POST` request to `"https://jsonplaceholder.typicode.com/todos"`.
- Ensures that the response is successful, and writes the request details to the console.
- Writes the response body as a string to the console.

#### HTTP Post as JSON

To automatically serialize `POST` request arguments and deserialize responses into strongly-typed C# objects, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> extension method that's part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code source="../snippets/httpclient/Program.PostAsJson.cs" id="postasjson":::

The preceding code:

- Serializes the `Todo` instance as JSON, and makes a `POST` request to `"https://jsonplaceholder.typicode.com/todos"`.
- Ensures that the response is successful, and writes the request details to the console.
- Deserializes the response body into a `Todo` instance, and writes the `Todo` to the console.

### HTTP Put

The `PUT` request method either replaces an existing resource or creates a new one using request body payload. To make an HTTP `PUT` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.PutAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Put.cs" id="put":::

The preceding code:

- Prepares a <xref:System.Net.Http.StringContent> instance with the JSON body of the request (MIME type of `"application/json"`).
- Makes a `PUT` request to `"https://jsonplaceholder.typicode.com/todos/1"`.
- Ensures that the response is successful, and writes the request details and JSON response body to the console.

#### HTTP Put as JSON

To automatically serialize `PUT` request arguments and deserialize responses into strongly typed C# objects, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> extension method that's part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code source="../snippets/httpclient/Program.PutAsJson.cs" id="putasjson":::

The preceding code:

- Serializes the `Todo` instance as JSON, and makes a `PUT` request to `"https://jsonplaceholder.typicode.com/todos/5"`.
- Ensures that the response is successful, and writes the request details to the console.
- Deserializes the response body into a `Todo` instance, and writes the `Todo` to the console.

### HTTP Patch

The `PATCH` request is a partial update to an existing resource. It doesn't create a new resource, and it's not intended to replace an existing resource. Instead, it updates a resource only partially. To make an HTTP `PATCH` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.PatchAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Patch.cs" id="patch":::

The preceding code:

- Prepares a <xref:System.Net.Http.StringContent> instance with the JSON body of the request (MIME type of `"application/json"`).
- Makes a `PATCH` request to `"https://jsonplaceholder.typicode.com/todos/1"`.
- Ensures that the response is successful, and writes the request details and JSON response body to the console.

No extension methods exist for `PATCH` requests in the `System.Net.Http.Json` NuGet package.

### HTTP Delete

A `DELETE` request deletes an existing resource. A `DELETE` request is _idempotent_ but not _safe_, meaning multiple `DELETE` requests to the same resources yield the same result, but the request affects the state of the resource. To make an HTTP `DELETE` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Delete.cs" id="delete":::

The preceding code:

- Makes a `DELETE` request to `"https://jsonplaceholder.typicode.com/todos/1"`.
- Ensures that the response is successful, and writes the request details to the console.

> [!TIP]
> The response to a `DELETE` request (just like a `PUT` request) may or may not include a body.

### HTTP Head

The `HEAD` request is similar to a `GET` request. Instead of returning the resource, it only returns the headers associated with the resource. A response to the `HEAD` request doesn't return a body. To make an HTTP `HEAD` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType> method with the <xref:System.Net.Http.HttpMethod> set to `HttpMethod.Head`:

:::code source="../snippets/httpclient/Program.Head.cs" id="head":::

The preceding code:

- Makes a `HEAD` request to `"https://www.example.com/"`.
- Ensures that the response is successful, and writes the request details to the console.
- Iterates over all of the response headers, writing each one to the console.

### HTTP Options

The `OPTIONS` request is used to identify which HTTP methods a server or endpoint supports. To make an HTTP `OPTIONS` request, given an `HttpClient` and a URI, use the <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType> method with the <xref:System.Net.Http.HttpMethod> set to `HttpMethod.Options`:

:::code source="../snippets/httpclient/Program.Options.cs" id="options":::

The preceding code:

- Sends an `OPTIONS` HTTP request to `"https://www.example.com/"`.
- Ensures that the response is successful, and writes the request details to the console.
- Iterates over all of the response content headers, writing each one to the console.

### HTTP Trace

The `TRACE` request can be useful for debugging as it provides application-level loop-back of the request message. To make an HTTP `TRACE` request, create an <xref:System.Net.Http.HttpRequestMessage> using the `HttpMethod.Trace`:

:::code source="../snippets/httpclient/Program.Trace.cs" id="trace":::

> [!CAUTION]
> The `TRACE` HTTP method is not supported by all HTTP servers. It can expose a security vulnerability if used unwisely. For more information, see [Open Web Application Security Project (OWASP): Cross Site Tracing](https://owasp.org/www-community/attacks/Cross_Site_Tracing).

## Handle an HTTP response

Whenever you're handling an HTTP response, you interact with the <xref:System.Net.Http.HttpResponseMessage> type. Several members are used when evaluating the validity of a response. The HTTP status code is available via the <xref:System.Net.Http.HttpResponseMessage.StatusCode?displayProperty=nameWithType> property. Imagine that you've sent a request given a client instance:

:::code source="../snippets/httpclient/Program.Responses.cs" id="request":::

To ensure that the `response` is `OK` (HTTP status code 200), you can evaluate it as shown in the following example:

:::code source="../snippets/httpclient/Program.Responses.cs" id="isstatuscode":::

There are other HTTP status codes that represent a successful response, such as `CREATED` (HTTP status code 201), `ACCEPTED` (HTTP status code 202), `NO CONTENT` (HTTP status code 204), and `RESET CONTENT` (HTTP status code 205). You can use the <xref:System.Net.Http.HttpResponseMessage.IsSuccessStatusCode?displayProperty=nameWithType> property to evaluate these codes as well, which ensures that the response status code is within the range 200-299:

:::code source="../snippets/httpclient/Program.Responses.cs" id="issuccessstatuscode":::

If you need to have the framework throw the <xref:System.Net.Http.HttpRequestException>, you can call the <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Responses.cs" id="ensurestatuscode":::

This code throws an `HttpRequestException` if the response status code isn't within the 200-299 range.

### HTTP valid content responses

With a valid response, you can access the response body using the <xref:System.Net.Http.HttpResponseMessage.Content> property. The body is available as an <xref:System.Net.Http.HttpContent> instance, which you can use to access the body as a stream, byte array, or string:

:::code source="../snippets/httpclient/Program.Responses.cs" id="stream":::

In the preceding code, the `responseStream` can be used to read the response body.

:::code source="../snippets/httpclient/Program.Responses.cs" id="array":::

In the preceding code, the `responseByteArray` can be used to read the response body.

:::code source="../snippets/httpclient/Program.Responses.cs" id="string":::

In the preceding code, the `responseString` can be used to read the response body.

Finally, when you know an HTTP endpoint returns JSON, you can deserialize the response body into any valid C# object by using the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package:

:::code source="../snippets/httpclient/Program.Responses.cs" id="json":::

In the preceding code, `result` is the response body deserialized as the type `T`.

## HTTP error handling

When an HTTP request fails, the <xref:System.Net.Http.HttpRequestException> is thrown. Catching that exception alone may not be sufficient, as there are other potential exceptions thrown that you might want to consider handling. For example, the calling code may have used a cancellation token that was canceled before the request was completed. In this scenario, you'd catch the <xref:System.Threading.Tasks.TaskCanceledException>:

:::code source="../snippets/httpclient/Program.Cancellation.cs" id="cancellation":::

Likewise, when making an HTTP request, if the server doesn't respond before the <xref:System.Net.Http.HttpClient.Timeout?displayProperty=nameWithType> is exceeded the same exception is thrown. However, in this scenario, you can distinguish that the timeout occurred by evaluating the <xref:System.Exception.InnerException?displayProperty=nameWithType> when catching the <xref:System.Threading.Tasks.TaskCanceledException>:

:::code source="../snippets/httpclient/Program.CancellationInnerTimeout.cs" id="innertimeout":::

In the preceding code, when the inner exception is a <xref:System.TimeoutException> the timeout occurred, and the request wasn't canceled by the cancellation token.

To evaluate the HTTP status code when catching an <xref:System.Net.Http.HttpRequestException>, you can evaluate the <xref:System.Net.Http.HttpRequestException.StatusCode%2A?displayProperty=nameWithType> property:

:::code source="../snippets/httpclient/Program.CancellationStatusCode.cs" id="statuscode":::

In the preceding code, the <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode> method is called to throw an exception if the response isn't successful. The <xref:System.Net.Http.HttpRequestException.StatusCode%2A?displayProperty=nameWithType> property is then evaluated to determine if the response was a `404` (HTTP status code 404). There are several helper methods on `HttpClient` that implicitly call `EnsureSuccessStatusCode` on your behalf, consider the following APIs:

- <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A?displayProperty=nameWithType>
- <xref:System.Net.Http.HttpClient.GetStreamAsync%2A?displayProperty=nameWithType>
- <xref:System.Net.Http.HttpClient.GetStringAsync%2A?displayProperty=nameWithType>

> [!TIP]
> All `HttpClient` methods used to make HTTP requests that don't return an `HttpResponseMessage` implicitly call `EnsureSuccessStatusCode` on your behalf.

When calling these methods, you can handle the `HttpRequestException` and evaluate the <xref:System.Net.Http.HttpRequestException.StatusCode%2A?displayProperty=nameWithType> property to determine the HTTP status code of the response:

:::code source="../snippets/httpclient/Program.CancellationStream.cs" id="helpers":::

There might be scenarios in which you need to throw the <xref:System.Net.Http.HttpRequestException> in your code. The <xref:System.Net.Http.HttpRequestException.%23ctor> constructor is public, and you can use it to throw an exception with a custom message:

:::code source="../snippets/httpclient/Program.ThrowHttpException.cs" id="throw":::

## HTTP proxy

An HTTP proxy can be configured in one of two ways. A default is specified on the <xref:System.Net.Http.HttpClient.DefaultProxy?displayProperty=nameWithType> property. Alternatively, you can specify a proxy on the <xref:System.Net.Http.HttpClientHandler.Proxy?displayProperty=nameWithType> property.

### Global default proxy

The `HttpClient.DefaultProxy` is a static property that determines the default proxy that all `HttpClient` instances use if no proxy is set explicitly in the <xref:System.Net.Http.HttpClientHandler> passed through its constructor.

The default instance returned by this property initializes following a different set of rules depending on your platform:

- **For Windows:** Reads proxy configuration from environment variables or, if those aren't defined, from the user's proxy settings.
- **For macOS:** Reads proxy configuration from environment variables or, if those aren't defined, from the system's proxy settings.
- **For Linux:** Reads proxy configuration from environment variables or, in case those aren't defined, this property initializes a non-configured instance that bypasses all addresses.

The environment variables used for `DefaultProxy` initialization on Windows and Unix-based platforms are:

- `HTTP_PROXY`: the proxy server used on HTTP requests.
- `HTTPS_PROXY`: the proxy server used on HTTPS requests.
- `ALL_PROXY`: the proxy server used on HTTP and/or HTTPS requests in case `HTTP_PROXY` and/or `HTTPS_PROXY` aren't defined.
- `NO_PROXY`: a comma-separated list of hostnames that should be excluded from proxying. Asterisks aren't supported for wildcards; use a leading dot in case you want to match a subdomain. Examples: `NO_PROXY=.example.com` (with leading dot) will match `www.example.com`, but won't match `example.com`. `NO_PROXY=example.com` (without leading dot) won't match `www.example.com`. This behavior might be revisited in the future to match other ecosystems better.

On systems where environment variables are case-sensitive, the variable names may be all lowercase or all uppercase. The lowercase names are checked first.

The proxy server may be a hostname or IP address, optionally followed by a colon and port number, or it may be an `http` URL, optionally including a username and password for proxy authentication. The URL must be start with `http`, not `https`, and can't include any text after the hostname, IP, or port.

### Proxy per client

The <xref:System.Net.Http.HttpClientHandler.Proxy?displayProperty=nameWithType> property identifies the <xref:System.Net.WebProxy> object to use to process requests to Internet resources. To specify that no proxy should be used, set the `Proxy` property to the proxy instance returned by the <xref:System.Net.GlobalProxySelection.GetEmptyWebProxy?displayProperty=nameWithType> method.

The local computer or application config file may specify that a default proxy is used. If the Proxy property is specified, then the proxy settings from the Proxy property override the local computer or application config file and the handler uses the proxy settings specified. If no proxy is specified in a config file and the Proxy property is unspecified, the handler uses the proxy settings inherited from the local computer. If there are no proxy settings, the request is sent directly to the server.

The <xref:System.Net.Http.HttpClientHandler> class parses a proxy bypass list with wildcard characters inherited from local computer settings. For example, the `HttpClientHandler` class parses a bypass list of `"nt*"` from browsers as a regular expression of `"nt.*"`. So a URL of `http://nt.com` would bypass the proxy using the `HttpClientHandler` class.

The `HttpClientHandler` class supports local proxy bypass. The class considers a destination to be local if any of the following conditions are met:

1. The destination contains a flat name (no dots in the URL).
1. The destination contains a loopback address (<xref:System.Net.IPAddress.Loopback> or <xref:System.Net.IPAddress.IPv6Loopback>) or the destination contains an <xref:System.Net.IPAddress> assigned to the local computer.
1. The domain suffix of the destination matches the local computer's domain suffix (<xref:System.Net.NetworkInformation.IPGlobalProperties.DomainName>).

For more information about configuring a proxy, see:

- <xref:System.Net.WebProxy.Address?displayProperty=nameWithType>
- <xref:System.Net.WebProxy.BypassProxyOnLocal?displayProperty=nameWithType>
- <xref:System.Net.WebProxy.BypassArrayList?displayProperty=nameWithType>

## See also

- [HTTP support in .NET](http-overview.md)
- [Guidelines for using HttpClient](httpclient-guidelines.md)
- [IHttpClientFactory with .NET](../../../core/extensions/httpclient-factory.md)
- [Use HTTP/3 with HttpClient](../../../core/extensions/httpclient-http3.md)
- [Test web APIs with the HttpRepl](/aspnet/core/web-api/http-repl)
