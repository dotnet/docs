---
title: System.Net.Http.HttpClient class
description: Learn about the System.Net.Http.HttpClient class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Net.Http.HttpClient class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Net.Http.HttpClient> class instance acts as a session to send HTTP requests. An <xref:System.Net.Http.HttpClient> instance is a collection of settings applied to all requests executed by that instance. In addition, every <xref:System.Net.Http.HttpClient> instance uses its own connection pool, isolating its requests from requests executed by other <xref:System.Net.Http.HttpClient> instances.

## Instancing

<xref:System.Net.Http.HttpClient> is intended to be instantiated once and reused throughout the life of an application. In .NET Core and .NET 5+, HttpClient pools connections inside the handler instance and reuses a connection across multiple requests. If you instantiate an HttpClient class for every request, the number of sockets available under heavy loads will be exhausted. This exhaustion will result in <xref:System.Net.Sockets.SocketException> errors.

You can configure additional options by passing in a "handler", such as <xref:System.Net.Http.HttpClientHandler> (or <xref:System.Net.Http.SocketsHttpHandler> in .NET Core 2.1 or later), as part of the constructor. The connection properties on the handler cannot be changed once a request has been submitted, so one reason to create a new HttpClient instance would be if you need to change the connection properties. If different requests require different settings, this may also lead to an application having multiple <xref:System.Net.Http.HttpClient> instances, where each instance is configured appropriately, and then requests are issued on the relevant client.

HttpClient only resolves DNS entries when a connection is created. It does not track any time to live (TTL) durations specified by the DNS server. If DNS entries change regularly, which can happen in some container scenarios, the client won't respect those updates. To solve this issue, you can limit the lifetime of the connection by setting the <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime?displayProperty=nameWithType> property, so that DNS lookup is required when the connection is replaced.

```csharp
public class GoodController : ApiController
{
    private static readonly HttpClient httpClient;

    static GoodController()
    {
        var socketsHandler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2)
        };

        httpClient = new HttpClient(socketsHandler);
    }
}
```

As an alternative to creating only one HttpClient instance, you can also use <xref:System.Net.Http.IHttpClientFactory> to manage the HttpClient instances for you. For more information, see [Guidelines for using HttpClient](/dotnet/fundamentals/networking/httpclient-guidelines).

## Derivation

The <xref:System.Net.Http.HttpClient> also acts as a base class for more specific HTTP clients. An example would be a FacebookHttpClient that provides additional methods specific to a Facebook web service (for example, a `GetFriends` method). Derived classes should not override the virtual methods on the class. Instead, use a constructor overload that accepts <xref:System.Net.Http.HttpMessageHandler> to configure any pre-request or post-request processing.

## Transports

The <xref:System.Net.Http.HttpClient> is a high-level API that wraps the lower-level functionality available on each platform where it runs.

On each platform, <xref:System.Net.Http.HttpClient> tries to use the best available transport:

| **Host/Runtime**            | **Backend**                                                                               |
| --------------------------- | ----------------------------------------------------------------------------------------- |
| Windows/.NET Framework      | <xref:System.Net.HttpWebRequest>                                                          |
| Windows/Mono                | <xref:System.Net.HttpWebRequest>                                                          |
| Windows/UWP                 | Windows native <xref:System.Net.Http.WinHttpHandler> (HTTP 2.0 capable)                   |
| Windows/.NET Core 1.0-2.0   | Windows native <xref:System.Net.Http.WinHttpHandler> (HTTP 2.0 capable)                   |
| macOS/Mono                  | <xref:System.Net.HttpWebRequest>                                                          |
| macOS/.NET Core 1.0-2.0     | `libcurl`-based HTTP transport (HTTP 2.0 capable)                                         |
| Linux/Mono                  | <xref:System.Net.HttpWebRequest>                                                          |
| Linux/.NET Core 1.0-2.0     | `libcurl`-based HTTP transport (HTTP 2.0 capable)                                         |
| .NET Core 2.1 and later     | <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType>                    |

Users can also configure a specific transport for <xref:System.Net.Http.HttpClient> by invoking the <xref:System.Net.Http.HttpClient.%23ctor*> constructor that takes an <xref:System.Net.Http.HttpMessageHandler>.

### .NET Framework & Mono

By default on .NET Framework and Mono, <xref:System.Net.HttpWebRequest> is used to send requests to the server. This behavior can be modified by specifying a different handler in one of the constructor overloads with an <xref:System.Net.Http.HttpMessageHandler> parameter. If you require features like authentication or caching, you can use <xref:System.Net.Http.WebRequestHandler> to configure settings and the instance can be passed to the constructor. The returned handler can be passed to a constructor overload that has an <xref:System.Net.Http.HttpMessageHandler> parameter.

### .NET Core

Starting with .NET Core 2.1, the <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType> class instead of <xref:System.Net.Http.HttpClientHandler> provides the implementation used by higher-level HTTP networking classes such as <xref:System.Net.Http.HttpClient>. The use of <xref:System.Net.Http.SocketsHttpHandler> offers a number of advantages:

- A significant performance improvement when compared with the previous implementation.
- The elimination of platform dependencies, which simplifies deployment and servicing. For example, `libcurl` is no longer a dependency on .NET Core for macOS and .NET Core for Linux.
- Consistent behavior across all .NET platforms.

If this change is undesirable, on Windows you can continue to use <xref:System.Net.Http.WinHttpHandler> by referencing its [NuGet package](https://www.nuget.org/packages/System.Net.Http.WinHttpHandler/) and passing it to [HttpClient's constructor](xref:System.Net.Http.HttpClient.%23ctor(System.Net.Http.HttpMessageHandler)) manually.

## Configure behavior using runtime configuration options

Certain aspects of <xref:System.Net.Http.HttpClient>'s behavior are customizable through [Runtime configuration options](/dotnet/core/run-time-config/networking). However, the behavior of these switches differs through .NET versions. For example, in .NET Core 2.1 - 3.1, you can configure whether <xref:System.Net.Http.SocketsHttpHandler> is used by default, but that option is no longer available starting in .NET 5.

## Connection pooling

HttpClient pools HTTP connections where possible and uses them for more than one request. This can have a significant performance benefit, especially for HTTPS requests, as the connection handshake is only done once.

Connection pool properties can be configured on a <xref:System.Net.Http.HttpClientHandler> or <xref:System.Net.Http.SocketsHttpHandler> passed in during construction, including <xref:System.Net.Http.HttpClientHandler.MaxConnectionsPerServer>, <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionIdleTimeout>, and <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime>.

Disposing of the HttpClient instance closes the open connections and cancels any pending requests.

> [!NOTE]
> If you concurrently send HTTP/1.1 requests to the same server, new connections can be created. Even if you reuse the `HttpClient` instance, if the rate of requests is high, or if there are any firewall limitations, that can exhaust the available sockets because of default TCP cleanup timers. To limit the number of concurrent connections, you can set the `MaxConnectionsPerServer` property. By default, the number of concurrent HTTP/1.1 connections is unlimited.

## Buffering and request lifetime

By default, HttpClient methods (except <xref:System.Net.Http.HttpClient.GetStreamAsync%2A>) buffer the responses from the server, reading all the response body into memory before returning the async result. Those requests will continue until one of the following occurs:

- The <xref:System.Threading.Tasks.Task%601> succeeds and returns a result.
- The <xref:System.Net.Http.HttpClient.Timeout> is reached, in which case the <xref:System.Threading.Tasks.Task%601> will be cancelled.
- The <xref:System.Threading.CancellationToken> passable to some method overloads is fired.
- <xref:System.Net.Http.HttpClient.CancelPendingRequests> is called.
- The HttpClient is disposed.

You can change the buffering behavior on a per-request basis using the <xref:System.Net.Http.HttpCompletionOption> parameter available on some method overloads. This argument can be used to specify if the <xref:System.Threading.Tasks.Task%601> should be considered complete after reading just the response headers, or after reading and buffering the response content.

If your app that uses <xref:System.Net.Http.HttpClient> and related classes in the <xref:System.Net.Http> namespace intends to download large amounts of data (50 megabytes or more), then the app should stream those downloads and not use the default buffering. If you use the default buffering, the client memory usage will get very large, potentially resulting in substantially reduced performance.

## Thread safety

The following methods are thread safe:

- <xref:System.Net.Http.HttpClient.CancelPendingRequests%2A>
- <xref:System.Net.Http.HttpClient.DeleteAsync%2A>
- <xref:System.Net.Http.HttpClient.GetAsync%2A>
- <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A>
- <xref:System.Net.Http.HttpClient.GetStreamAsync%2A>
- <xref:System.Net.Http.HttpClient.GetStringAsync%2A>
- <xref:System.Net.Http.HttpClient.PostAsync%2A>
- <xref:System.Net.Http.HttpClient.PutAsync%2A>
- <xref:System.Net.Http.HttpClient.SendAsync%2A>

## Proxies

By default, HttpClient reads proxy configuration from environment variables or user/system settings, depending on the platform. You can change this behavior by passing a <xref:System.Net.WebProxy> or <xref:System.Net.IWebProxy> to, in order of precedence:

- The <xref:System.Net.Http.HttpClientHandler.Proxy> property on a HttpClientHandler passed in during HttpClient construction
- The <xref:System.Net.Http.HttpClient.DefaultProxy> static property (affects all instances)

You can disable the proxy using <xref:System.Net.Http.HttpClientHandler.UseProxy>. The default configuration for Windows users is to try and detect a proxy using network discovery, which can be slow. For high throughput applications where it's known that a proxy isn't required, you should disable the proxy.

Proxy settings (like <xref:System.Net.IWebProxy.Credentials>) should be changed only before the first request is made using the HttpClient. Changes made after using the HttpClient for the first time may not be reflected in subsequent requests.

## Timeouts

You can use <xref:System.Net.Http.HttpClient.Timeout> to set a default timeout for all HTTP requests from the HttpClient instance. The timeout only applies to the xxxAsync methods that cause a request/response to be initiated. If the timeout is reached, the <xref:System.Threading.Tasks.Task%601> for that request is cancelled.

You can set some additional timeouts if you pass in a <xref:System.Net.Http.SocketsHttpHandler> instance when constructing the HttpClient object:

| Property | Description |
| ------------ | -------------- |
| <xref:System.Net.Http.SocketsHttpHandler.ConnectTimeout> | Specifies a timeout that's used when a request requires a new TCP connection to be created. If the timeout occurs, the request <xref:System.Threading.Tasks.Task%601> is cancelled. |
| <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> | Specifies a timeout to be used for each connection in the connection pool. If the connection is idle, the connection is immediately closed; otherwise, the connection is closed at the end of the current request. |
| <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionIdleTimeout> | If a connection in the connection pool is idle for this long, the connection is closed. |
| <xref:System.Net.Http.SocketsHttpHandler.Expect100ContinueTimeout> | If request has an "Expect: 100-continue" header, it delays sending content until the timeout or until a "100-continue" response is received. |

HttpClient only resolves DNS entries when the connections are created. It does not track any time to live (TTL) durations specified by the DNS server. If DNS entries are changing regularly, which can happen in some container scenarios, you can use the <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> to limit the lifetime of the connection so that DNS lookup is required when replacing the connection.
