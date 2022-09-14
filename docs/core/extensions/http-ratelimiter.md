---
title: Rate limiting an HTTP handler in .NET
description: Learn how to create a client-side HTTP handler that limits the number of requests.
author: IEvangelist
ms.author: dapine
ms.date: 09/09/2022
---

# Rate limiting an HTTP handler in .NET

In this article, you'll learn how to create a client-side HTTP handler that rate limits the number of requests it sends. In this example, you'll see an <xref:System.Net.Http.HttpClient> that accesses the `"www.example.com"` resource. Resources are consumed by apps that rely on them, and when an app makes too many requests to a single resource this can lead to resource contention. Resource contention is when a resource is consumed by too many apps, and the resource is unable to serve all of the apps that are requesting it. This can lead to a poor user experience, and in some cases, it can even lead to a denial of service (DoS) attack. For more information on DoS, see [OWASP: Denial of Service](https://owasp.org/www-community/attacks/Denial_of_Service).

## What is rate limiting?

Rate limiting is the concept of limiting how much a resource can be accessed. For example, you may know that a database your app accesses can safely handle 1,000 requests per minute, but it may not handle much more than that. You can put a rate limiter in your appl that only allows 1,000 requests every minute and rejects any more requests before they can access the database. Thus, rate limiting your database and allowing your app to handle a safe number of requests. This is a common pattern in distributed systems, where you may have multiple instances of an app running, and you want to ensure that they don't all try to access the database at the same time. There are multiple different rate-limiting algorithms to control the flow of requests.

## Implement a `DelegatingHandler` subclass

To control the flow of requests, you implement a custom <xref:System.Net.Http.DelegatingHandler> subclass. This is a type of <xref:System.Net.Http.HttpMessageHandler> that allows you to intercept and handle requests before they are sent to the server. You can also intercept and handle responses before they are returned to the caller. In this example, you'll implement a custom `DelegatingHandler` subclass that limits the number of requests that can be sent to a single resource. Consider the following custom `ClientSideRateLimitedHandler` class:

:::code language="csharp" source="snippets/ratelimit/http/ClientSideRateLimitedHandler.cs":::

The preceding C# code:

- Inherits the `DelegatingHandler` type.
- Implements the <xref:System.IAsyncDisposable> interface.
- Defines a `RateLimiter` field that is assigned from the constructor.
- The `SendAsync` method is overridden to intercept and handle requests before they are sent to the server.
- The `DisposeAsync` method is overridden to dispose of the `RateLimiter` instance.

Looking a bit closer at the `SendAsync` method, you'll see that it:

- Relies on the `RateLimiter` instance to acquire a `RateLimitLease` from the `WaitAsync`.
- When the `lease.IsAcquired` property is `true`, the request is sent to the server.
- Otherwise, an <xref:System.Net.Http.HttpResponseMessage> is returned with a `429` status code, and if the `lease` contains a `RetryAfter` value, the `Retry-After` header is set to that value.

## See also

- [Announcing Rate Limiting for .NET](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet)
- [Rate limiting middleware in ASP.NET Core](/aspnet/core/performance/rate-limit)
