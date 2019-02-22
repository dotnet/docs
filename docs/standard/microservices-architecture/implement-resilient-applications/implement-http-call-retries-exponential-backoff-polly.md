---
title: Implement HTTP call retries with exponential backoff with Polly
description: Learn how to handle HTTP failures with Polly and HttpClientFactory.
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 01/07/2019
---

# Implement HTTP call retries with exponential backoff with HttpClientFactory and Polly policies

The recommended approach for retries with exponential backoff is to take advantage of more advanced .NET libraries like the open-source [Polly library](https://github.com/App-vNext/Polly).

Polly is a .NET library that provides resilience and transient-fault handling capabilities. You can implement those capabilities by applying Polly policies such as Retry, Circuit Breaker, Bulkhead Isolation, Timeout, and Fallback. Polly targets .NET 4.x and the .NET Standard Library 1.0 (which supports .NET Core).

However, using Polly’s library with your own custom code with HttpClient can be significantly complex. In the original version of eShopOnContainers, there was a [ResilientHttpClient building-block](https://github.com/dotnet-architecture/eShopOnContainers/blob/master/src/BuildingBlocks/Resilience/Resilience.Http/ResilientHttpClient.cs) based on Polly. But with the release of HttpClientFactory, resilient Http communication has become much simpler to implement, so that building-block was deprecated from eShopOnContainers. 

The following steps show how you can use Http retries with Polly integrated into HttpClientFactory, which is explained in the previous section.

**Reference the ASP.NET Core 2.2 packages**

`HttpClientFactory` is available since .NET Core 2.1 however we recommend you to use the latest ASP.NET Core 2.2 packages from NuGet in your project. You typically need the `AspNetCore` metapackage, and the extension package `Microsoft.Extensions.Http.Polly`.

**Configure a client with Polly’s Retry policy, in Startup**

As shown in previous sections, you need to define a named or typed client HttpClient configuration in your standard Startup.ConfigureServices(...) method, but now, you add incremental code specifying the policy for the Http retries with exponential backoff, as below:

```csharp
//ConfigureServices()  - Startup.cs
services.AddHttpClient<IBasketService, BasketService>()
        .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
        .AddPolicyHandler(GetRetryPolicy());
```

The **AddPolicyHandler()** method is what adds policies to the `HttpClient` objects you'll use. In this case, it's adding a Polly’s policy for Http Retries with exponential backoff.

To have a more modular approach, the Http Retry Policy can be defined in a separate method within the `Startup.cs` file, as shown in the following code:

```csharp
static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                    retryAttempt)));
}
```

With Polly, you can define a Retry policy with the number of retries, the exponential backoff configuration, and the actions to take when there's an HTTP exception, such as logging the error. In this case, the policy is configured to try six times with an exponential retry, starting at two seconds. 

so it will try six times and the seconds between each retry will be exponential, starting on two seconds.

## Add a jitter strategy to the retry policy

A regular Retry policy can impact your system in cases of high concurrency and scalability and under high contention. To overcome peaks of similar retries coming from many clients in case of partial outages, a good workaround is to add a jitter strategy to the retry algorithm/policy. This can improve the overall performance of the end-to-end system by adding randomness to the exponential backoff. This spreads out the spikes when issues arise. When you use a plain Polly policy, code to implement jitter could look like the following example:

```csharp
Random jitterer = new Random(); 
Policy
  .Handle<HttpResponseException>() // etc
  .WaitAndRetry(5,    // exponential back-off plus some jitter
      retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))  
                    + TimeSpan.FromMilliseconds(jitterer.Next(0, 100)) 
  );
```

## Additional resources

- **Retry pattern**\
  [*https://docs.microsoft.com/azure/architecture/patterns/retry*](/azure/architecture/patterns/retry)

- **Polly and HttpClientFactory**\
  [*https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory*](https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory)

- **Polly (.NET resilience and transient-fault-handling library)**\
  [*https://github.com/App-vNext/Polly*](https://github.com/App-vNext/Polly)

- **Marc Brooker. Jitter: Making Things Better With Randomness**\
  [*https://brooker.co.za/blog/2015/03/21/backoff.html*](https://brooker.co.za/blog/2015/03/21/backoff.html)

>[!div class="step-by-step"]
>[Previous](explore-custom-http-call-retries-exponential-backoff.md)
>[Next](implement-circuit-breaker-pattern.md)