---
title: Understand Azure SDK protocol methods
description: Learn about the key differences between Azure SDK protocol methods and convenience methods
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-arm-template
ms.date: 06/24/2024
---

# Azure SDK for .NET convenience and protocol methods overview

The Azure SDK client libraries provide an interface to Azure services by translating library calls into underlying REST requests. In this article, you'll learn about the different types of methods exposed by the client libraries and explore their implementation differences.

## Understand protocol methods and convenience methods

The Azure SDK client libraries expose one or both of two different categories of methods to manage request and response objects:

- **Protocol methods** provide a thin wrapper around the underlying REST API for a corresponding Azure service. Protocol methods map primitive input parameters to HTTP request values and return the raw HTTP response.

- **Convenience methods** provide a convenience layer over the lower level protocol layer to add support for the .NET type system, and other benefits. Convenience methods accept C# model types as parameters that map to the body of an underlying REST API request. Convenience methods handle the details of request and response management to allow developers to focus on sending and receiving data objects, instead of lower level concerns.

These concepts are explored in more depth in the sections ahead.

## Understand Azure SDK client library dependencies

Azure SDK client library protocol and convenience method implementation patterns different slightly depending on the underlying dependency chain of the respective library. Azure SDK client libraries depend on one of two different low level libraries:

- **Azure.Core** provides shared primitives, abstractions, and helpers for building modern .NET Azure SDK client libraries. These libraries follow the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) and can be easily identified by package and namespaces names starting with 'Azure', e.g. `Azure.Storage.Blobs`. Azure.Core allows client libraries to expose common functionality in a consistent fashion, so that once you learn how to use these APIs in one client library, you will know how to use them in other client libraries.

- **System.ClientModel** provides shared primitives, abstractions, and helpers for .NET service client libraries. Whereas `Azure.Core` is specifically designed as a base library for building Azure SDK client libraries, the `System.ClientModel` library is a more general purpose library designed to help build libraries for a variety of platforms and services.

## Explore protocol methods



## Explore convenience methods