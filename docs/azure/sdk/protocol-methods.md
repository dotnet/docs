---
title: Understand Azure SDK protocol methods
description: Learn about the key differences between Azure SDK protocol methods and convenience methods
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-arm-template
ms.date: 06/24/2024
---

# Azure SDK for .NET client protocol methods overview

The Azure SDK client libraries provide an interface to Azure services by translating library calls into underlying REST requests. In this article, you'll learn about the different types of methods exposed by the client libraries and how to use them in your apps.

## Understand the method types in the Azure SDK client libraries

The Azure SDK client libraries expose two different types of methods to access the request and response body:

- **Protocol methods** accept HTTP request and response object as parameters, such as the `RequestBody` and `RequestContext` types. These parameters require the developer to directly manage the request content and parse the corresponding response data.
- **Convenience methods** accept 'model types' as parameters - C# classes which map to the message body of the REST call. These methods handle the details of request and response management and allow developers to focus specifically on sending and receiving the data objects they are concerned with.

Most Azure SDK Clients expose methods that take 'model types' as parameters, C# classes which map to the message body of the REST call. Those methods can be called here 'convenience methods'.

However, some clients expose methods that mirror the message body directly. Those methods are called here 'protocol methods', as they provide more direct access to the REST protocol used by the client library.