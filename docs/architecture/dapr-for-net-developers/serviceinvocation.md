---
title: The Service Invocation building block
description: A description of the Service Invocation building block and how to apply it
author: amolenk
ms.date: 09/26/2020
---

# The Service Invocation building block

Many services need to communicate with each other in a distributed system. The Service Invocation building block enables you to quickly set up communication between services using either gRPC or HTTP protocols while providing some additional benefits.

## What it solves

Making calls between services may sound easy, but there are some challenges involved. In a distributed system, how do you even know where the other service is? Once you've got the address, how do you call that service securely? And what about if that call fails? How do you handle retries to transient errors? Lastly, since distributed systems can consist of many different services, it is also necessary to get insights into the system and the service call graphs to diagnose issues that may pop in production.

The Dapr Service Invocation building block helps you solve these challenges by using the Dapr sidecar as a reverse proxy for your service.

## How it works

Let's start with an example. There are two services, service A and service B, and service A needs to call service B. Instead of making a direct call from service A to service B, service A calls the invoke API of its Dapr sidecar:

```
TODO http example
```

 The sidecar takes care of the rest:

1. discovery
2. calls the other sidecar
3. other sidecar calls the service
4. response

Because the call is now routed through sidecars, Dapr can add additional features.


### Using the .NET SDK

## Reference case: eShopOnDapr

[Really quick intro on specific <BuildingBlock> stuff in eShop]

### <BuildingBlock> in eShopOnDapr
…


### Compared to eShopOnContainers

…

## Summary

### References

>[!div class=“step-by-step”]
>[Previous](~index.md~)
>[Next](~index.md~)
