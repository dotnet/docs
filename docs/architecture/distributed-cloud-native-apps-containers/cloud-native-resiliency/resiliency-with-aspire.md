---
title: Resiliency with .NET
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Resiliency with .NET
author: 
ms.date: 04/06/2022
---

# Add resiliency with .NET

You've seen how important it is to design your cloud-native applications to be resilient and the different approaches you can take to achieve this. We'll explore how you can implement application resiliency using the features built in to .NET.

Application resiliency is provided in .NET by two packages:

- `Microsoft.Extensions.Resilience`
- `Microsoft.Extensions.Http.Resilience`

These packages implement the resiliency strategies provided by Polly to make your applications more resilient to transient faults and other issues that can occur in distributed environments.

For detailed information on how to use these packages, see [Introduction to resilient app development](https://learn.microsoft.com/en-us/dotnet/core/resilience).

## Adding fault tolerance to microservices

In a distributed cloud-native environment, HTTP requests are a common way to communicate between services. You can use the `Microsoft.Extensions.Http.Resilience` package to add fault tolerance between your services.

The high level steps are:

- Add the `Microsoft.Extensions.Http.Resilience` package to the project that needs to handle failures.
- Add the `AddStandardResilienceHandler` method to the `HttpClient` factory.
- Configure the resiliency policies for the `HttpClient` factory.

The default `AddStandardResilienceHandler` sets sensible values for the timeout, retries, and circuit breaker policies. But you can choose to customize these policies to suit your application's specific needs.

This manual process of adding the package, modifying the HttpClient, and configuring the policies can be time-consuming and error-prone. There is a better way to add resiliency to your application.

## Add resiliency with .NET Aspire

As you've seen throughout this book .NET Aspire stack scales with your application and services. One of the fundamental ideas is to have an opinionated take on how to build better cloud-native applications. This includes adding sensible defaults for resiliency.

If you've already added the previous .NET packages for resiliency and configured them, you can leave all that code in place. For all your microservices without any added resiliency, you can enrol them in .NET Aspire and gain the benefits of standard HTTP resiliency without any additional code.

The projects you enlist in .NET Aspire have a dependency added to the service defaults project. This project contains the default configuration for resiliency, observability, telemetry, and other features. When you add a new microservice to .NET Aspire, it automatically gets the resiliency configuration.

The code inside the service defaults project that adds the default resiliency configuration is:

```csharp
public static IHostApplicationBuilder AddServiceDefaults(
    this IHostApplicationBuilder builder)
{
    builder.ConfigureOpenTelemetry();

    builder.AddDefaultHealthChecks();

    builder.Services.AddServiceDiscovery();

    builder.Services.ConfigureHttpClientDefaults(http =>
    {
        // Turn on resilience by default
        http.AddStandardResilienceHandler();

        // Turn on service discovery by default
        http.AddServiceDiscovery();
    });

    return builder;
}
```

You don't need to change any of your code if the default resiliency settings meet your needs.

## Additional resources

- **Implement resiliency in a cloud-native .NET microservice** \
  <https://learn.microsoft.com/training/modules/microservices-resiliency-aspnet-core/>

- **Tutorial: Add .NET Aspire to an existing .NET app** \<https://learn.microsoft.com/dotnet/aspire/get-started/add-aspire-existing-app>

>[!div class="step-by-step"]
>[Previous](resilient-communication.md)
>[Next](../monitoring-health/observability-patterns.md)
