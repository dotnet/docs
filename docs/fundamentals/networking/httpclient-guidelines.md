---
title: HTTPClient guidelines for .NET
description: Learn about using HttpClient instances to send HTTP requests and how you can manage clients using IHttpClientFactory in your .NET apps.
author: gewarren
ms.author: gewarren
ms.date: 05/19/2022
---
# Guidelines for using HTTP clients

The <xref:System.Net.Http.HttpClient?displayProperty=fullName> class 

Recommendation:

- In .NET Framework, use HttpClient.
- In .NET Core:
  - Use a static/singleton HttpClient with PooledConnectionLifetime set to a desired interval depending on expected DNS changes. This solves both the socket exhaustion and DNS changes problems without adding an overhead of HttpClientFactory. You can also register your handler separately to be able to mock it.
  - If you require the full configurability HttpClientFactory offers, though, like having multiple differently configured HttpClients for different use cases, use the typed-client approach, but be aware that these are intended to be short-lived.

## HttpClient

Discuss disposal, DNS behavior, and PooledConnectionLifetime...

- If you use a shared instance to improve performance, the client won't respect DNS record updates in case of failover scenarios.
- In .NET Framework, disposing HttpClient does not impact connection management. In .NET Core, the connection pool is linked to HttpClient's underlying HttpHandler. So when HttpClient is disposed, it disposes all previously used connections. That forces new connection next time you need to talk to the same server and there is performance penalty as well it needs new TCP port. If the rate of request is high or if there are any firewall limitations that can exhaust available range because of default TCP cleanup timers.
- Starting with .NET Core 2.1, the SocketsHttpHandler class provides the implementation. SocketsHttpHandler provides consistent behavior across all platforms.

HttpClient will only resolve DNS entries when the connections are created, it does not track any TTL durations specified by the DNS server. If DNS entries are changing regularly, which can happen in some container scenarios, the <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> can be used to limit the lifetime of the connection so that DNS will be required when replacing the connection.

## HttpClientFactory

- Solves socket exhaustion problem by pooling and reusing HttpClientHandlers.
- Adds overhead
- HttpClients are expected to be short-lived - this is okay because handlers are reused.
- Once the client is created, the factory no longer has control over it.
- Pools the HttpMessageHandler instances to reduce resource consumption. An HttpMessageHandler instance may be reused from the pool when creating a new HttpClient instance if its lifetime hasn't expired. However, the pooled instances results in sharing of <xref:System.Net.CookieContainer> objects. Unanticipated CookieContainer object sharing often results in incorrect code. For apps that require cookies, consider disabling automatic cookie handling or avoiding IHttpClientFactory.

## See also

- [Make HTTP requests using IHttpClientFactory](/aspnet/core/fundamentals/http-requests)
- [Use IHttpClientFactory to implement resilient HTTP requests](../../architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests.md)
