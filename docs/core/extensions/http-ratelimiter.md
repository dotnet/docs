---
title: Rate limiting an HTTP handler in .NET
description: Learn how to create a client-side HTTP handler that limits the number of requests, with the inbuilt rate limiter API from .NET.
author: IEvangelist
ms.author: dapine
ms.date: 03/13/2023
---

# Rate limit an HTTP handler in .NET

In this article, you'll learn how to create a client-side HTTP handler that rate limits the number of requests it sends. You'll see an <xref:System.Net.Http.HttpClient> that accesses the `"www.example.com"` resource. Resources are consumed by apps that rely on them, and when an app makes too many requests for a single resource, it can lead to *resource contention*. Resource contention occurs when a resource is consumed by too many apps, and the resource is unable to serve all of the apps that are requesting it. This can result in a poor user experience, and in some cases, it can even lead to a denial of service (DoS) attack. For more information on DoS, see [OWASP: Denial of Service](https://owasp.org/www-community/attacks/Denial_of_Service).

## What is rate limiting?

Rate limiting is the concept of limiting how much a resource can be accessed. For example, you may know that a database your app accesses can safely handle 1,000 requests per minute, but it may not handle much more than that. You can put a rate limiter in your app that only allows 1,000 requests every minute and rejects any more requests before they can access the database. Thus, rate limiting your database and allowing your app to handle a safe number of requests. This is a common pattern in distributed systems, where you may have multiple instances of an app running, and you want to ensure that they don't all try to access the database at the same time. There are multiple different rate-limiting algorithms to control the flow of requests.

To use rate limiting in .NET, you'll reference the [System.Threading.RateLimiting](https://www.nuget.org/packages/System.Threading.RateLimiting) NuGet package.

## Implement a `DelegatingHandler` subclass

To control the flow of requests, you implement a custom <xref:System.Net.Http.DelegatingHandler> subclass. This is a type of <xref:System.Net.Http.HttpMessageHandler> that allows you to intercept and handle requests before they're sent to the server. You can also intercept and handle responses before they're returned to the caller. In this example, you'll implement a custom `DelegatingHandler` subclass that limits the number of requests that can be sent to a single resource. Consider the following custom `ClientSideRateLimitedHandler` class:

:::code language="csharp" source="snippets/ratelimit/http/ClientSideRateLimitedHandler.cs":::

The preceding C# code:

- Inherits the `DelegatingHandler` type.
- Implements the <xref:System.IAsyncDisposable> interface.
- Defines a `RateLimiter` field that is assigned from the constructor.
- Overrides the `SendAsync` method to intercept and handle requests before they're sent to the server.
- Overrides the <xref:System.IAsyncDisposable.DisposeAsync> method to dispose of the `RateLimiter` instance.

Looking a bit closer at the `SendAsync` method, you'll see that it:

- Relies on the `RateLimiter` instance to acquire a `RateLimitLease` from the `AcquireAsync`.
- When the `lease.IsAcquired` property is `true`, the request is sent to the server.
- Otherwise, an <xref:System.Net.Http.HttpResponseMessage> is returned with a `429` status code, and if the `lease` contains a `RetryAfter` value, the `Retry-After` header is set to that value.

## Emulate many concurrent requests

To put this custom `DelegatingHandler` subclass to the test, you'll create a console app that emulates many concurrent requests. This `Program` class creates an <xref:System.Net.Http.HttpClient> with the custom `ClientSideRateLimitedHandler`:

:::code language="csharp" source="snippets/ratelimit/http/Program.cs":::

In the preceding console app:

- The `TokenBucketRateLimiterOptions` are configured with a token limit of `8`, and queue processing order of `OldestFirst`, a queue limit of `3`, and replenishment period of `1` millisecond, a tokens per period value of `2`, and an auto-replenish value of `true`.
- An `HttpClient` is created with the `ClientSideRateLimitedHandler` that is configured with the `TokenBucketRateLimiter`.
- To emulate 100 requests, <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType> creates 100 URLs, each with a unique query string parameter.
- Two <xref:System.Threading.Tasks.Task> objects are assigned from the <xref:System.Threading.Tasks.Parallel.ForEachAsync%2A?displayProperty=nameWithType> method, splitting the URLs into two groups.
- The `HttpClient` is used to send a `GET` request to each URL, and the response is written to the console.
- <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> waits for both tasks to complete.

Since the `HttpClient` is configured with the `ClientSideRateLimitedHandler`, not all requests will make it to the server resource. You can test this assertion by running the console app. You'll see that only a fraction of the total number of requests are sent to the server, and the rest are rejected with an HTTP status code of `429`. Try altering the `options` object used to create the `TokenBucketRateLimiter` to see how the number of requests that are sent to the server changes.

Consider the following example output:

```Output
URL: https://example.com?iteration=06, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=60, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=55, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=59, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=57, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=11, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=63, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=13, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=62, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=65, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=64, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=67, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=14, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=68, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=16, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=69, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=70, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=71, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=17, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=18, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=72, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=73, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=74, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=19, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=75, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=76, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=79, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=77, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=21, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=78, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=81, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=22, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=80, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=20, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=82, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=83, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=23, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=84, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=24, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=85, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=86, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=25, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=87, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=26, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=88, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=89, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=27, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=90, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=28, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=91, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=94, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=29, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=93, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=96, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=92, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=95, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=31, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=30, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=97, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=98, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=99, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=32, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=33, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=34, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=35, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=36, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=37, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=38, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=39, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=40, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=41, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=42, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=43, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=44, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=45, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=46, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=47, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=48, HTTP status code: TooManyRequests (429)
URL: https://example.com?iteration=15, HTTP status code: OK (200)
URL: https://example.com?iteration=04, HTTP status code: OK (200)
URL: https://example.com?iteration=54, HTTP status code: OK (200)
URL: https://example.com?iteration=08, HTTP status code: OK (200)
URL: https://example.com?iteration=00, HTTP status code: OK (200)
URL: https://example.com?iteration=51, HTTP status code: OK (200)
URL: https://example.com?iteration=10, HTTP status code: OK (200)
URL: https://example.com?iteration=66, HTTP status code: OK (200)
URL: https://example.com?iteration=56, HTTP status code: OK (200)
URL: https://example.com?iteration=52, HTTP status code: OK (200)
URL: https://example.com?iteration=12, HTTP status code: OK (200)
URL: https://example.com?iteration=53, HTTP status code: OK (200)
URL: https://example.com?iteration=07, HTTP status code: OK (200)
URL: https://example.com?iteration=02, HTTP status code: OK (200)
URL: https://example.com?iteration=01, HTTP status code: OK (200)
URL: https://example.com?iteration=61, HTTP status code: OK (200)
URL: https://example.com?iteration=05, HTTP status code: OK (200)
URL: https://example.com?iteration=09, HTTP status code: OK (200)
URL: https://example.com?iteration=03, HTTP status code: OK (200)
URL: https://example.com?iteration=58, HTTP status code: OK (200)
URL: https://example.com?iteration=50, HTTP status code: OK (200)
```

You'll notice that the first logged entries are always the immediately returned 429 responses, and the last entries are always the 200 responses. This is because the rate limit is encountered client-side and avoids making an HTTP call to a server. This is a good thing because it means that the server isn't flooded with requests. It also means that the rate limit is enforced consistently across all clients.

Note also that each URL's query string is unique: examine the `iteration` parameter to see that it's incremented by one for each request. This parameter helps to illustrate that the 429 responses aren't from the first requests, but rather from the requests that are made after the rate limit is reached. The 200 responses arrive later but these requests were made earlier&mdash;before the limit was reached.

To have a better understanding of the various rate-limiting algorithms, try rewriting this code to accept a different `RateLimiter` implementation. In addition to the `TokenBucketRateLimiter` you could try:

- `ConcurrencyLimiter`
- `FixedWindowRateLimiter`
- `PartitionedRateLimiter`
- `SlidingWindowRateLimiter`

## Summary

In this article, you learned how to implement a custom `ClientSideRateLimitedHandler`. This pattern could be used to implement a rate-limited HTTP client for resources that you know have API limits. In this way, you're preventing your client app from making unnecessary requests to the server, and you're also preventing your app from being blocked by the server. Additionally, with the use of metadata to store retry timing values, you could also implement automatic retry logic.

## See also

- [Announcing Rate Limiting for .NET](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet)
- [Rate limiting middleware in ASP.NET Core](/aspnet/core/performance/rate-limit)
- [Azure Architecture: Rate limiting pattern](/azure/architecture/patterns/rate-limiting-pattern)
- [Automatic retry logic in .NET](../../architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly.md)
