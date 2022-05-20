---
title: HTTPClient guidelines for .NET
description: Learn about using HttpClient instances to send HTTP requests and how you can manage clients using IHttpClientFactory in your .NET apps.
author: gewarren
ms.author: gewarren
ms.date: 05/19/2022
---
# Guidelines for using HTTPClient

The <xref:System.Net.Http.HttpClient?displayProperty=fullName> class sends HTTP requests and receives HTTP responses from a resource identified by a URI. An <xref:System.Net.Http.HttpClient> instance is a collection of settings that's applied to all requests executed by that instance, and each instance uses its own connection pool, which isolates its requests from others. Starting in .NET Core 2.1, the <xref:System.Net.Http.SocketsHttpHandler> class provides the implementation, making behavior consistent across all platforms.

If you're using .NET 5+ (including .NET Core), there are some considerations to keep in mind if you're using <xref:System.Net.Http.HttpClient>.

## DNS behavior

<xref:System.Net.Http.HttpClient> only resolves DNS entries when a connection is created. It does not track any time to live (TTL) durations specified by the DNS server. If DNS entries change regularly, which can happen in some container scenarios, the client won't respect those updates. To solve this issue, you can limit the lifetime of the connection by setting the <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> property, so that DNS lookup is required when the connection is replaced.

## Pooled connections

In .NET Framework, disposing <xref:System.Net.Http.HttpClient> objects does not impact connection management. However, in .NET Core, the connection pool is linked to the client's underlying <xref:System.Net.Http.HttpMessageHandler>. When the <xref:System.Net.Http.HttpClient> instance is disposed, it disposes all previously used connections. If you later send a request to the same server, a new connection is created. There's also a performance penalty because it needs a new TCP port. If the rate of requests is high, or if there are any firewall limitations, that can **exhaust the available sockets** because of default TCP cleanup timers.

## Recommended use

- In .NET Framework, you can create a new <xref:System.Net.Http.HttpClient> each time you need to send a request.
- In .NET Core and .NET 5+:
  - Use a static or singleton <xref:System.Net.Http.HttpClient> with <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> set to a desired interval, such as two minutes, depending on expected DNS changes. This solves both the socket exhaustion and DNS changes problems without adding the overhead of <xref:System.Net.Http.IHttpClientFactory>. If you need to be able to mock your handler, you can register it separately.
  - Using <xref:System.Net.Http.IHttpClientFactory>, you can have multiple, differently configured clients for different use cases. If its lifetime hasn't expired, an <xref:System.Net.Http.HttpMessageHandler> instance may be reused from the pool when the factory creates a new <xref:System.Net.Http.HttpClient> instance. This reuse avoids any socket exhaustion issues. If you desire the configurability that <xref:System.Net.Http.IHttpClientFactory> provides, we recommend using the [typed-client approach](../../core/extensions/http-client.md#typed-clients). However, be aware that the clients created by the factory are intended to be short-lived, and once the client is created, the factory no longer has control over it.
  
    > [!TIP]
    > If your app requires cookies, consider disabling automatic cookie handling or avoiding <xref:System.Net.Http.IHttpClientFactory>. Pooling the <xref:System.Net.Http.HttpMessageHandler> instances results in sharing of <xref:System.Net.CookieContainer> objects. Unanticipated <xref:System.Net.CookieContainer> object sharing often results in incorrect code.

## See also

- [Make HTTP requests using IHttpClientFactory](/aspnet/core/fundamentals/http-requests)
- [Use IHttpClientFactory to implement resilient HTTP requests](../../architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests.md)
