---
title: Make HTTP requests with the HttpClient
description: Learn how to make HTTP requests and handle responses with the HttpClient in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 03/06/2025
---

# Make HTTP requests with the HttpClient class

In this article, you learn how to make HTTP requests and handle responses with the `HttpClient` class.

> [!IMPORTANT]
> All of the example HTTP requests in this article target one of the following URLs:
>
> - <https://jsonplaceholder.typicode.com>: A site that provides a free fake API platform for testing and prototyping.
> - <https://www.example.com>: A domain available for use in illustrative examples in documents.

HTTP endpoints commonly return JavaScript Object Notation (JSON) data, but not always. For convenience, the optional [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package provides several extension methods for `HttpClient` and `HttpContent` objects that perform automatic serialization and deserialization by using the [📦 System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The examples in this article call attention to places where these extensions are available.

> [!TIP]
> All source code referenced in this article is available in the [GitHub: .NET Docs](https://github.com/dotnet/docs/tree/main/docs/fundamentals/networking/snippets/httpclient) repository.

## Create an HttpClient object

Most of the examples in this article reuse the same `HttpClient` instance, so you can configure the instance once and use it for the remaining examples. To create an `HttpClient` object, use the `HttpClient` class constructor. For more information, see [Guidelines for using HttpClient](httpclient-guidelines.md).

:::code source="../snippets/httpclient/Program.cs" id="sharedclient":::

The code completes the following tasks:

- Instantiate a new `HttpClient` instance as a `static` variable. According to the [guidelines](httpclient-guidelines.md), the recommended approach is to reuse `HttpClient` instances during the application lifecycle.
- Set the <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> property to `"https://jsonplaceholder.typicode.com"`.

This `HttpClient` instance uses the base address to make subsequent requests. To apply other configurations, consider the following APIs:

- Set the <xref:System.Net.Http.HttpClient.DefaultRequestHeaders?displayProperty=nameWithType> property.
- Apply a nondefault <xref:System.Net.Http.HttpClient.Timeout?displayProperty=nameWithType> property.
- Specify the <xref:System.Net.Http.HttpClient.DefaultRequestVersion?displayProperty=nameWithType> property.

> [!TIP]
> Alternatively, you can create `HttpClient` instances by using a factory-pattern approach that allows you to configure any number of clients and consume them as dependency injection services. For more information, see [HTTP client factory with .NET](../../../core/extensions/httpclient-factory.md).

## Make an HTTP request

To make an HTTP request, you call any of the following API methods:

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

> <sup>†</sup>A `USER SPECIFIED` request indicates that the `SendAsync` method accepts any valid <xref:System.Net.Http.HttpMethod> object.

> [!WARNING]
> Making HTTP requests is considered network I/O-bound work. A synchronous <xref:System.Net.Http.HttpClient.Send%2A?displayProperty=nameWithType> method exists, but the recommendation is to use the asynchronous APIs instead, unless you have good reason not to.

> [!NOTE]
> While targeting Android devices (such as with .NET MAUI development), you must add the `android:usesCleartextTraffic="true"` definition to the `<application></application>` section in the _AndroidManifest.xml_ file. This setting enables clear-text traffic, such as HTTP requests, which is otherwise disabled by default due to Android security policies. Consider the following example XML settings:
>
> ```xml
> <?xml version="1.0" encoding="utf-8"?>
> <manifest xmlns:android="http://schemas.android.com/apk/res/android">
>   <application android:usesCleartextTraffic="true"></application>
>   <!-- omitted for brevity -->
> </manifest>
> ```
>
> For more information, see [Enable clear-text network traffic for the localhost domain](/dotnet/maui/data-cloud/local-web-services#enable-clear-text-network-traffic-for-the-localhost-domain).

### Understand HTTP content

The <xref:System.Net.Http.HttpContent> type is used to represent an HTTP entity body and corresponding content headers. For HTTP methods (or request methods) that require a body (`POST`, `PUT`, `PATCH`), you use the <xref:System.Net.Http.HttpContent> class to specify the body of the request. Most examples show how to prepare the  <xref:System.Net.Http.StringContent> subclass with a JSON payload, but other subclasses exist for different [content (MIME) types](https://developer.mozilla.org/docs/Web/HTTP/MIME_types).

- <xref:System.Net.Http.ByteArrayContent>: Provides HTTP content based on a byte array.
- <xref:System.Net.Http.FormUrlEncodedContent>: Provides HTTP content for name/value tuples encoded by using the `"application/x-www-form-urlencoded"` MIME type.
- <xref:System.Net.Http.Json.JsonContent>: Provides HTTP content based on JSON.
- <xref:System.Net.Http.MultipartContent>: Provides a collection of HttpContent objects that get serialized by using the `"multipart/*"` MIME type specification.
- <xref:System.Net.Http.MultipartFormDataContent>: Provides a container for content encoded by using the `"multipart/form-data"` MIME type.
- <xref:System.Net.Http.ReadOnlyMemoryContent>: Provides HTTP content based on an <xref:System.ReadOnlyMemory%601> value.
- <xref:System.Net.Http.StreamContent>: Provides HTTP content based on a stream.
- <xref:System.Net.Http.StringContent>: Provides HTTP content based on a string.

The `HttpContent` class is also used to represent the response body of the <xref:System.Net.Http.HttpResponseMessage> class, which is accessible on the <xref:System.Net.Http.HttpResponseMessage.Content?displayProperty=nameWithType> property.

### Use an HTTP GET request

A `GET` request shouldn't send a body. This request is used (as the method name indicates) to retrieve (or get) data from a resource. To make an HTTP `GET` request given an `HttpClient` instance and a <xref:System.Uri> object, use the <xref:System.Net.Http.HttpClient.GetAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Get.cs" id="get":::

The code completes the following tasks:

- Make a `GET` request to the `"https://jsonplaceholder.typicode.com/todos/3"` endpoint.
- Ensure the response is successful.
- Write the request details to the console.
- Read the response body as a string.
- Write the JSON response body to the console.

The `WriteRequestToConsole` method is a custom extension that isn't part of the framework. If you're curious about the implementation, consider the following C# code:

:::code source="../snippets/httpclient/HttpResponseMessageExtensions.cs":::

This functionality is used to write the request details to the console in the following form:

`<HTTP Request Method> <Request URI> <HTTP/Version>`

As an example, the `GET` request to the `"https://jsonplaceholder.typicode.com/todos/3"` endpoint outputs the following message:

```output
GET https://jsonplaceholder.typicode.com/todos/3 HTTP/1.1
```

#### Create the HTTP GET request from JSON

The <https://jsonplaceholder.typicode.com/todos> endpoint returns a JSON array of `Todo` objects. Their JSON structure resembles the following form:

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

It's a `record class` type, with optional `Id`, `Title`, `Completed`, and `UserId` properties. For more information on the `record` type, see [Introduction to record types in C#](../../../csharp/fundamentals/types/records.md). To automatically deserialize `GET` requests into a strongly typed C# object, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> extension method that's part of the [📦 System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code source="../snippets/httpclient/Program.GetFromJson.cs" id="getfromjson":::

The code completes the following tasks:

- Make a `GET` request to `"https://jsonplaceholder.typicode.com/todos?userId=1&completed=false"`.

   The query string represents the filtering criteria for the request. When the command succeeds, the response is automatically deserialized into a `List<Todo>` object.

- Write the request details to the console, along with each `Todo` object.

### Use an HTTP POST request

A `POST` request sends data to the server for processing. The `Content-Type` header of the request signifies what [MIME type](xref:System.Net.Mime.ContentType) the body is sending. To make an HTTP `POST` request given an `HttpClient` instance and a <xref:System.Uri> object, use the <xref:System.Net.Http.HttpClient.PostAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Post.cs" id="post":::

The code completes the following tasks:

- Prepare a <xref:System.Net.Http.StringContent> instance with the JSON body of the request (MIME type of `"application/json"`).
- Make a `POST` request to the `"https://jsonplaceholder.typicode.com/todos"` endpoint.
- Ensure the response is successful and write the request details to the console.
- Write the response body as a string to the console.

#### Create the HTTP POST request as JSON

To automatically serialize `POST` request arguments and deserialize responses into strongly typed C# objects, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> extension method that's part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code source="../snippets/httpclient/Program.PostAsJson.cs" id="postasjson":::

The code completes the following tasks:

- Serialize the `Todo` instance as JSON and make a `POST` request to the `"https://jsonplaceholder.typicode.com/todos"` endpoint.
- Ensure the response is successful and write the request details to the console.
- Deserialize the response body into a `Todo` instance and write the `Todo` object to the console.

### Use an HTTP PUT request

The `PUT` request method either replaces an existing resource or creates a new one by using the request body payload. To make an HTTP `PUT` request given an `HttpClient` instance and a <xref:System.Uri> object, use the <xref:System.Net.Http.HttpClient.PutAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Put.cs" id="put":::

The code completes the following tasks:

- Prepare a <xref:System.Net.Http.StringContent> instance with the JSON body of the request (MIME type of `"application/json"`).
- Make a `PUT` request to the `"https://jsonplaceholder.typicode.com/todos/1"` endpoint.
- Ensure the response is successful and write the request details with the JSON response body to the console.

#### Create the HTTP PUT request as JSON

To automatically serialize `PUT` request arguments and deserialize responses into strongly typed C# objects, use the <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> extension method that's part of the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package.

:::code source="../snippets/httpclient/Program.PutAsJson.cs" id="putasjson":::

The code completes the following tasks:

- Serialize the `Todo` instance as JSON and make a `PUT` request to the `"https://jsonplaceholder.typicode.com/todos/5"` endpoint.
- Ensure the response is successful and write the request details to the console.
- Deserialize the response body into a `Todo` instance and write the `Todo` objects to the console.

### Use an HTTP PATCH request

The `PATCH` request is a partial update to an existing resource. This request doesn't create a new resource and it isn't intended to replace an existing resource. Instead, this method only partially updates a resource. To make an HTTP `PATCH` request given an `HttpClient` instance and a <xref:System.Uri> object, use the <xref:System.Net.Http.HttpClient.PatchAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Patch.cs" id="patch":::

The code completes the following tasks:

- Prepare a <xref:System.Net.Http.StringContent> instance with the JSON body of the request (MIME type of `"application/json"`).
- Make a `PATCH` request to the `"https://jsonplaceholder.typicode.com/todos/1"` endpoint.
- Ensure the response is successful and write the request details with the JSON response body to the console.

No extension methods exist for `PATCH` requests in the `System.Net.Http.Json` NuGet package.

### Use an HTTP DELETE request

A `DELETE` request removes an existing resource and the request is _idempotent_, but not _safe_. Multiple `DELETE` requests to the same resources yield the same result, but the request affects the state of the resource. To make an HTTP `DELETE` request given an `HttpClient` instance and a <xref:System.Uri> object, use the <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Delete.cs" id="delete":::

The code completes the following tasks:

- Make a `DELETE` request to the `"https://jsonplaceholder.typicode.com/todos/1"` endpoint.
- Ensure the response is successful and write the request details to the console.

> [!TIP]
> The response to a `DELETE` request (just like a `PUT` request) might or might not include a body.

### Explore the HTTP HEAD request

The `HEAD` request is similar to a `GET` request. Instead of returning the resource, this request returns only the headers associated with the resource. A response to the `HEAD` request doesn't return a body. To make an HTTP `HEAD` request given an `HttpClient` instance and a <xref:System.Uri> object, use the <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType> method with the <xref:System.Net.Http.HttpMethod> type set to `HttpMethod.Head`:

:::code source="../snippets/httpclient/Program.Head.cs" id="head":::

The code completes the following tasks:

- Make a `HEAD` request to the `"https://www.example.com/"` endpoint.
- Ensure the response is successful and write the request details to the console.
- Iterate over all of the response headers and write each header to the console.

### Explore the HTTP OPTIONS request

The `OPTIONS` request is used to identify which HTTP methods a server or endpoint supports. To make an HTTP `OPTIONS` request given an `HttpClient` instance and a <xref:System.Uri> object, use the <xref:System.Net.Http.HttpClient.SendAsync%2A?displayProperty=nameWithType> method with the <xref:System.Net.Http.HttpMethod> type set to `HttpMethod.Options`:

:::code source="../snippets/httpclient/Program.Options.cs" id="options":::

The code completes the following tasks:

- Send an `OPTIONS` HTTP request to the `"https://www.example.com/"` endpoint.
- Ensure the response is successful and write the request details to the console.
- Iterate over all of the response content headers and write each header to the console.

### Explore the HTTP TRACE request

The `TRACE` request can be useful for debugging as it provides application-level loop-back of the request message. To make an HTTP `TRACE` request, create an <xref:System.Net.Http.HttpRequestMessage> by using the `HttpMethod.Trace` type:

:::code source="../snippets/httpclient/Program.Trace.cs" id="trace":::

> [!CAUTION]
> Not all HTTP servers support the `TRACE` HTTP method. This method can expose a security vulnerability if used unwisely. For more information, see [Open Web Application Security Project (OWASP): Cross Site Tracing](https://owasp.org/www-community/attacks/Cross_Site_Tracing).

## Handle an HTTP response

When you handle an HTTP response, you interact with the <xref:System.Net.Http.HttpResponseMessage> type. Several members are used to evaluate the validity of a response. The HTTP status code is available in the <xref:System.Net.Http.HttpResponseMessage.StatusCode?displayProperty=nameWithType> property.

Suppose you send a request given a client instance:

:::code source="../snippets/httpclient/Program.Responses.cs" id="request":::

To ensure the `response` is `OK` (HTTP status code 200), you can evaluate the value as shown in the following example:

:::code source="../snippets/httpclient/Program.Responses.cs" id="isstatuscode":::

There are other HTTP status codes that represent a successful response, such as `CREATED` (HTTP status code 201), `ACCEPTED` (HTTP status code 202), `NO CONTENT` (HTTP status code 204), and `RESET CONTENT` (HTTP status code 205). You can use the <xref:System.Net.Http.HttpResponseMessage.IsSuccessStatusCode?displayProperty=nameWithType> property to evaluate these codes as well, which ensures that the response status code is within the range 200-299:

:::code source="../snippets/httpclient/Program.Responses.cs" id="issuccessstatuscode":::

If you need to have the framework throw the <xref:System.Net.Http.HttpRequestException> error, you can call the <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode?displayProperty=nameWithType> method:

:::code source="../snippets/httpclient/Program.Responses.cs" id="ensurestatuscode":::

This code throws an `HttpRequestException` error if the response status code isn't within the 200-299 range.

### Explore HTTP valid content responses

With a valid response, you can access the response body by using the <xref:System.Net.Http.HttpResponseMessage.Content> property. The body is available as an <xref:System.Net.Http.HttpContent> instance, which you can use to access the body as a stream, byte array, or string.

The following code uses the `responseStream` object to read the response body:

:::code source="../snippets/httpclient/Program.Responses.cs" id="stream":::

You can use different objects to read the response body. Use the `responseByteArray` object to read the response body:

:::code source="../snippets/httpclient/Program.Responses.cs" id="array":::

Use the `responseString` object to read the response body:

:::code source="../snippets/httpclient/Program.Responses.cs" id="string":::

When you know an HTTP endpoint returns JSON, you can deserialize the response body into any valid C# object by using the [System.Net.Http.Json](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package:

:::code source="../snippets/httpclient/Program.Responses.cs" id="json":::

In this code, the `result` value is the response body deserialized as the type `T`.

<a name="http-error-handling"></a>

## Use HTTP error handling

When an HTTP request fails, the system throws the <xref:System.Net.Http.HttpRequestException> object. Catching the exception alone might not be sufficient. There are other potential exceptions thrown that you might want to consider handling. For example, the calling code might use a cancellation token that was canceled before the request completed. In this scenario, you can catch the <xref:System.Threading.Tasks.TaskCanceledException> error:

:::code source="../snippets/httpclient/Program.Cancellation.cs" id="cancellation":::

Likewise, when you make an HTTP request, if the server doesn't respond before the <xref:System.Net.Http.HttpClient.Timeout?displayProperty=nameWithType> value is exceeded, the same exception is thrown. In this scenario, you can distinguish that the time-out occurred by evaluating the <xref:System.Exception.InnerException?displayProperty=nameWithType> property when catching the <xref:System.Threading.Tasks.TaskCanceledException> error:

:::code source="../snippets/httpclient/Program.CancellationInnerTimeout.cs" id="innertimeout":::

In the code, when the inner exception is an <xref:System.TimeoutException> type, then the time-out occurred and the cancellation token doesn't cancel the request.

To evaluate the HTTP status code when you catch the <xref:System.Net.Http.HttpRequestException> object, you can evaluate the <xref:System.Net.Http.HttpRequestException.StatusCode%2A?displayProperty=nameWithType> property:

:::code source="../snippets/httpclient/Program.CancellationStatusCode.cs" id="statuscode":::

In the code, the <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode> method is called to throw an exception if the response isn't successful. The <xref:System.Net.Http.HttpRequestException.StatusCode%2A?displayProperty=nameWithType> property is then evaluated to determine if the response was a `404` (HTTP status code 404). There are several helper methods on the `HttpClient` object that implicitly call the `EnsureSuccessStatusCode` method on your behalf.

For HTTP error handing, consider the following APIs:

- <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A?displayProperty=nameWithType> method
- <xref:System.Net.Http.HttpClient.GetStreamAsync%2A?displayProperty=nameWithType> method
- <xref:System.Net.Http.HttpClient.GetStringAsync%2A?displayProperty=nameWithType> method

> [!TIP]
> All `HttpClient` methods used to make HTTP requests that don't return an `HttpResponseMessage` type implicitly call the `EnsureSuccessStatusCode` method on your behalf.

When you call these methods, you can handle the `HttpRequestException` object and evaluate the <xref:System.Net.Http.HttpRequestException.StatusCode%2A?displayProperty=nameWithType> property to determine the HTTP status code of the response:

:::code source="../snippets/httpclient/Program.CancellationStream.cs" id="helpers":::

There might be scenarios where you need to throw the <xref:System.Net.Http.HttpRequestException> object in your code. The <xref:System.Net.Http.HttpRequestException.%23ctor> constructor is public and you can use it to throw an exception with a custom message:

:::code source="../snippets/httpclient/Program.ThrowHttpException.cs" id="throw":::

<a name="http-proxy"></a>

## Configure an HTTP proxy

An HTTP proxy can be configured in one of two ways. A default is specified on the <xref:System.Net.Http.HttpClient.DefaultProxy?displayProperty=nameWithType> property. Alternatively, you can specify a proxy on the <xref:System.Net.Http.HttpClientHandler.Proxy?displayProperty=nameWithType> property.

### Use a global default proxy

The `HttpClient.DefaultProxy` property is a static property that determines the default proxy that all `HttpClient` instances use, if no proxy is set explicitly in the <xref:System.Net.Http.HttpClientHandler> object passed through its constructor.

The default instance returned by this property initializes according to a different set of rules depending on your platform:

- **Windows**: Read proxy configuration from environment variables, or if variables aren't defined, read from user proxy settings.
- **macOS**: Read proxy configuration from environment variables, or if variables aren't defined, read from system proxy settings.
- **Linux**: Read proxy configuration from environment variables, or if variables aren't defined, initialize a nonconfigured instance to bypass all addresses.

The `DefaultProxy` property initialization on Windows and Unix-based platforms uses the following environment variables:

- `HTTP_PROXY`: The proxy server used on HTTP requests.
- `HTTPS_PROXY`: The proxy server used on HTTPS requests.
- `ALL_PROXY`: The proxy server used on HTTP and/or HTTPS requests when the `HTTP_PROXY` and/or `HTTPS_PROXY` variables aren't defined.
- `NO_PROXY`: A comma-separated list of hostnames to exclude from proxying. Asterisks aren't supported for wildcards. Use a leading period (.) when you want to match a subdomain. Examples: `NO_PROXY=.example.com` (with leading period) matches `www.example.com`, but doesn't match `example.com`. `NO_PROXY=example.com` (without leading period) doesn't match `www.example.com`. This behavior might be revisited in the future to match other ecosystems better.

On systems where environment variables are case-sensitive, the variable names can be all lowercase or all uppercase. The lowercase names are checked first.

The proxy server can be a hostname or IP address, optionally followed by a colon and port number, or it can be an `http` URL, optionally including a username and password for proxy authentication. The URL must start with `http`, not `https`, and can't include any text after the hostname, IP, or port.

### Configure the proxy per client

The <xref:System.Net.Http.HttpClientHandler.Proxy?displayProperty=nameWithType> property identifies the <xref:System.Net.WebProxy> object to use to process requests to internet resources. To specify that no proxy should be used, set the `Proxy` property to the proxy instance returned by the <xref:System.Net.GlobalProxySelection.GetEmptyWebProxy?displayProperty=nameWithType> method.

The local computer or application configuration file might specify that a default proxy is used. If the `Proxy` property is specified, then the proxy settings from the `Proxy` property override the local computer or application config file and the handler uses the proxy settings specified. If no proxy is specified in a config file and the `Proxy` property is unspecified, the handler uses the proxy settings inherited from the local computer. If there are no proxy settings, the request is sent directly to the server.

The <xref:System.Net.Http.HttpClientHandler> class parses a proxy bypass list with wildcard characters inherited from local computer settings. For example, the `HttpClientHandler` class parses a bypass list of `"nt*"` from browsers as a regular expression of `"nt.*"`. Therefore, a URL of `http://nt.com` bypasses the proxy by using the `HttpClientHandler` class.

The `HttpClientHandler` class supports local proxy bypass. The class considers a destination to be local if any of the following conditions are met:

- The destination contains a flat name (no periods (.) in the URL).
- The destination contains a loopback address (<xref:System.Net.IPAddress.Loopback> or <xref:System.Net.IPAddress.IPv6Loopback>) or the destination contains an <xref:System.Net.IPAddress> property assigned to the local computer.
- The domain suffix of the destination matches the local computer's domain suffix, as defined in the <xref:System.Net.NetworkInformation.IPGlobalProperties.DomainName> property.

For more information about configuring a proxy, see the following APIs:

- <xref:System.Net.WebProxy.Address?displayProperty=nameWithType> property
- <xref:System.Net.WebProxy.BypassProxyOnLocal?displayProperty=nameWithType> property
- <xref:System.Net.WebProxy.BypassArrayList?displayProperty=nameWithType> property

## Next steps

- [HTTP support in .NET](http-overview.md)
- [Guidelines for using HttpClient](httpclient-guidelines.md)
- [HTTP client factory with .NET](../../../core/extensions/httpclient-factory.md)
- [Use HTTP/3 with HttpClient](../../../core/extensions/httpclient-http3.md)
- [Test web APIs with the HttpRepl](/aspnet/core/web-api/http-repl)
