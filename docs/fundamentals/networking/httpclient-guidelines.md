---
title: HTTPClient guidelines for .NET
description: Learn about using HttpClient instances to send HTTP requests and how you can manage clients using IHttpClientFactory in your .NET apps.
author: gewarren
ms.author: gewarren
ms.date: 05/19/2022
---
# Guidelines for using HTTP clients

The <xref:System.Net.Http.HttpClient?displayProperty=fullName> class sends HTTP requests and receives HTTP responses from a resource identified by a URI. An <xref:System.Net.Http.HttpClient> instance is a collection of settings that's applied to all requests executed by that instance, and each instance uses its own connection pool, which isolates its requests from others. Starting in .NET Core 2.1, the <xref:System.Net.Http.SocketsHttpHandler> class provides the implementation, and provides consistent behavior across all platforms.

If you're using .NET 5+ (including .NET Core), there are some considerations to keep in mind if you're using <xref:System.Net.Http.HttpClient>.

## DNS behavior

<xref:System.Net.Http.HttpClient> only resolves DNS entries when a connection is created. It does not track any time to live (TTL) durations specified by the DNS server. If DNS entries change regularly, which can happen in some container scenarios, the client won't respect those updates. To solve this issue, you can limit the lifetime of the connection by setting the <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> property, so that DNS lookup is required when the connection is replaced.

## Pooled connections

In .NET Framework, disposing <xref:System.Net.Http.HttpClient> objects does not impact connection management. However, in .NET Core, the connection pool is linked to the client's underlying <xref:System.Net.Http.HttpClientHandler>. When the <xref:System.Net.Http.HttpClient> instance is disposed, it disposes all previously used connections. If you later send a request to the same server, a new connection is created. There's also a performance penalty because it needs a new TCP port. If the rate of requests is high, or if there are any firewall limitations, that can exhaust the available sockets because of default TCP cleanup timers.



Recommendation:

- In .NET Framework, use HttpClient.
- In .NET Core:
  - Use a static/singleton HttpClient with PooledConnectionLifetime set to a desired interval depending on expected DNS changes. This solves both the socket exhaustion and DNS changes problems without adding an overhead of HttpClientFactory. You can also register your handler separately to be able to mock it.
  - If you require the full configurability HttpClientFactory offers, though, like having multiple differently configured HttpClients for different use cases, use the typed-client approach, but be aware that these are intended to be short-lived.


## HttpClientFactory

- Solves socket exhaustion problem by pooling and reusing HttpClientHandlers.
- Adds overhead
- HttpClients are expected to be short-lived - this is okay because handlers are reused.
- Once the client is created, the factory no longer has control over it.
- Pools the HttpMessageHandler instances to reduce resource consumption. An HttpMessageHandler instance may be reused from the pool when creating a new HttpClient instance if its lifetime hasn't expired. However, the pooled instances results in sharing of <xref:System.Net.CookieContainer> objects. Unanticipated CookieContainer object sharing often results in incorrect code. For apps that require cookies, consider disabling automatic cookie handling or avoiding IHttpClientFactory.

## See also

- [Make HTTP requests using IHttpClientFactory](/aspnet/core/fundamentals/http-requests)
- [Use IHttpClientFactory to implement resilient HTTP requests](../../architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests.md)
