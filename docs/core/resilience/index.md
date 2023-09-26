---
title: Introduction to resiliency in .NET
description: 
author: IEvangelist
ms.author: dapine
ms.date: 09/26/2023
---

# Introduction to resiliency in .NET

Resiliency is the ability of an app to recover from failures and continue to function. In the context of .NET programming, resiliency is achieved by designing apps that can handle failures gracefully and recover quickly. To help build resilient apps in .NET, the following two packages are available on NuGet:

- [Microsoft.Extensions.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Resilience): This NuGet package provides mechanisms to harden apps against transient failures.
- [Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience): This NuGet package provides resiliency mechanisms specifically for the <xref:System.Net.Http.HttpClient>.

These two NuGet packages are built on top of _Polly_, which is a very popular open-source project. Polly is a .NET resilience and transient-fault-handling library that allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, Rate-limiting and Fallback in a fluent and thread-safe manner. For more information, see [Polly](https://github.com/App-vNext/Polly).

## Get started

To get started with resiliency in .NET, install the [Microsoft.Extensions.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Resilience) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Resilience --version 8.0.0-rc.1.23421.29
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Resilience"
    Version="8.0.0-rc.1.23421.29" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Build a resilience pipeline

### Pipeline builder extensions

## Enrichment

Enrichment is the automatic augmentation of telemetry with well-known state, in the form of name/value pairs. For example, an app might emit a log that includes the _operation_ and _result code_ as columns to represent the outcome of some operation. In this situation and depending on peripheral context, enrichment adds _cluster name_, _process name_, _region_, _tenant id_ and more to the log as it's sent to the telemetry backend. Enrichment is done systematically and behind the scenes relative to logging and metrics update within the app's main code.

Consider 1,000 instances of a service, spread around the world, each pumping logs and metrics out. If you look at a dashboard for your service and there's a problem, you need to know which region/data center is having trouble. Enrichment automatically makes sure that the log records have the state needed to pinpoint failures in distributed systems. If this isn't done through enrichment, it means the app code itself would need to track this state internally, weave it to wherever logging is done in the code, and then manually emit it. Enrichment makes that simpler, and invisible to app logic.

## Use pipeline

## Next steps

> [!div class="nextstepaction"]
> [Learn about adding code to articles](code-in-docs.md)
