---
title: Introduction to resiliency in .NET
description: Learn about resiliency in .NET programming, including fault tolerance, fault injection.
author: IEvangelist
ms.author: dapine
ms.date: 09/07/2023
---

# Introduction to resiliency in .NET

Resiliency is the ability of an app to recover from failures and continue to function. In the context of .NET programming, resiliency is achieved by designing apps that can handle failures gracefully and recover quickly. Two primary libraries can help you build resilient apps in .NET:

- [Microsoft.Extensions.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Resilience): This NuGet package provides mechanisms to harden apps against transient failures.
- [Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience): This NuGet package provides resiliency mechanisms specifically for the <xref:System.Net.Http.HttpClient>.

## Chaos Engineering

Chaos Engineering is a practice that involves conducting experiments on a distributed system by exposing it to real-world failures. The goal of these experiments is to build confidence in the system's ability to withstand turbulent conditions in production. By subjecting the system to controlled chaos, engineers can identify and address weaknesses in the system's design and architecture, ultimately improving its overall resiliency.

## Fault tolerance

Fault tolerance is the ability of a system to continue functioning even when one or more components fail. This is an important aspect of resiliency because it ensures that your app can continue to function even when things go wrong. For example, if your app relies on a database for storing data, it should be able to handle database failures gracefully and recover quickly from them, thus exhibiting fault tolerance.

### Fault injection

Fault injection is a technique that involves injecting faults into a system to test its ability to handle them. For example, you can inject faults into your app's database layer to test its ability to handle database failures.

To promote resilience pattern adoption, an application-level fault injection solution is needed to validate strategies and identify gaps. The [Microsoft.Extensions.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Resilience) library provides several mechanisms for building fault-tolerant apps, including fault injection. This library uses the [Simmy](https://github.com/Polly-Contrib/Simmy) library to simulate faults via chaos policies. Simmy is a chaos-engineering library that allows faults to be injected into services via chaos policies.

A Simmy chaos policy is a special type of resilience policy that allows you to define strategies to inject faults into services. Chaos policies can be applied individually or added to a Polly resilience policy. When added to a resilience policy, faults are injected into the resilience policy according to the strategy defined by the chaos policy, which allows resilience strategies to be tested and verified.

#### Inject faults into a resilience policy

To inject faults, use any of the default policies available in the [Microsoft.Extensions.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Resilience) library. The following faults can be injected into a resilience policy.

##### Latency

<xref:Microsoft.Extensions.Resilience.FaultInjection.LatencyPolicyOptions?displayProperty=fullName>

| Property | Default value | Description |
|--|--|--|
| `Enabled` | `false` | Determines if the created policy should be enabled. |
| `FaultInjectionRate` | `0.1` | A decimal between 0 and 1 inclusive. Indicates the rate at which a chaos policy should inject faults. |
| `Latency` | 30 seconds | The latency to be injected. The upper bound is 10 minutes. |

##### Exception

<xref:Microsoft.Extensions.Resilience.FaultInjection.ExceptionPolicyOptions?displayProperty=fullName>

| Property | Default value | Description |
|--|--|--|
| `Enabled` | `false` | Determines if the created policy should be enabled. |
| `FaultInjectionRate` | `0.1` | A decimal between 0 and 1 inclusive. Indicates the rate at which a chaos policy should inject faults. |
| `ExceptionKey` | `"DefaultException"` | This key is used for fetching a registered exception instance. |

##### Custom defined objects

<xref:Microsoft.Extensions.Resilience.FaultInjection.CustomResultPolicyOptions?displayProperty=fullName>

| Property | Default value | Description |
|--|--|--|
| `Enabled` | `false` | Determines if the created policy should be enabled. |
| `FaultInjectionRate` | `0.1` | A decimal between 0 and 1 inclusive. Indicates the rate at which a chaos policy should inject faults. |
| `CustomResultKey` | `string.Empty` | This key is used for fetching a registered custom defined result object. |

##### Custom defined `HttpResponseMessage`

<xref:Microsoft.Extensions.Resilience.FaultInjection.HttpResponseInjectionPolicyOptions?displayProperty=fullName>

| Property | Default value | Description |
|--|--|--|
| `Enabled` | `false` | Determines if the created policy should be enabled. |
| `FaultInjectionRate` | `0.1` | A decimal between 0 and 1 inclusive. Indicates the rate at which a chaos policy should inject faults. |
| `StatusCode` | `502` | The status code to be injected into a `http` response. |
| `HttpContentKey` | `null` | This key is used to retrieve a registered `HttpContent` instance. |
