---
title: Understand Azure SDK client library method types
description: Learn about the key differences between Azure SDK client library protocol and convenience methods.
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-arm-template
ms.date: 08/29/2024
---

# Azure SDK for .NET protocol and convenience methods overview

The Azure SDK client libraries provide an interface to Azure services by translating method calls into messages sent via the respective service protocol. For REST API services, this means sending HTTP requests and converting the responses into runtime types. In this article, you'll learn about the different types of methods exposed by the client libraries and explore their implementation patterns.

## Understand protocol and convenience methods

An Azure SDK for .NET client library can expose two different categories of methods to make requests to an Azure service:

- **Protocol methods** provide a thin wrapper around the underlying REST API for a corresponding Azure service. These methods map primitive input parameters to HTTP request values and return a raw HTTP response object.

- **Convenience methods** provide a convenience layer over the lower-level protocol layer to add support for the .NET type system and other benefits. Convenience methods accept primitives or .NET model types as parameters and map them to the body of an underlying REST API request. These methods also handle various details of request and response management to allow developers to focus on sending and receiving data objects, instead of lower-level concerns.

### Azure SDK client library dependency patterns

Protocol and convenience methods implement slightly different patterns based on the underlying package dependency chain of the respective library. An Azure SDK for .NET client library depends on one of two different foundational libraries:

- [**Azure.Core**](/dotnet/api/overview/azure/core-readme) provides shared primitives, abstractions, and helpers for building modern Azure SDK client libraries. These libraries follow the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) and use package names and namespaces prefixed with *Azure*, such as [`Azure.Storage.Blobs`](/dotnet/api/overview/azure/storage.blobs-readme).

- [**System.ClientModel**](/dotnet/api/overview/azure/system.clientmodel-readme) is a core library that provides shared primitives, abstractions, and helpers for .NET service client libraries. The `System.ClientModel` library is a general purpose toolset designed to help build libraries for various platforms and services, whereas the `Azure.Core` library is specifically designed for building Azure client libraries.

> [!NOTE]
> The `Azure.Core` library itself also depends on `System.ClientModel` for various client building blocks. In the context of this article, the key differentiator for method patterns is whether a client library depends on `Azure.Core` or `System.ClientModel` directly, rather than through a transitive dependency.

The following table compares some of the request and response types used by protocol and convenience methods, based on whether the library depends on `Azure.Core` or `System.ClientModel`.

| Request or response concern   | Azure.Core                       | System.ClientModel                                    |
|-------------------------------|----------------------------------|-------------------------------------------------------|
| Request body                  | <xref:Azure.Core.RequestContent> | <xref:System.ClientModel.BinaryContent>               |
| Advanced options              | <xref:Azure.RequestContext>      | <xref:System.ClientModel.Primitives.RequestOptions>   |
| Raw HTTP Response             | <xref:Azure.Response>            | <xref:System.ClientModel.Primitives.PipelineResponse> |
| Return type with output model | <xref:Azure.Response%601>        | <xref:System.ClientModel.ClientResult%601>            |

The sections ahead provide implementation examples of these concepts.

## Protocol and convenience method examples

The coding patterns and types used by client library protocol and convenience methods vary slightly based on whether the library depends on `Azure.Core` or `System.ClientModel`. The differences primarily influence the .NET types used for handling request and response data.

### Libraries that depend on Azure.Core

Azure SDK client libraries adhering to the [latest design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) depend on the `Azure.Core` library. For example, the [`Azure.AI.ContentSafety`](/dotnet/api/overview/azure/ai.contentsafety-readme) library depends on the `Azure.Core` library and provides a `ContentSafetyClient` class that exposes both protocol and convenience methods.

### [Convenience method](#tab/convenience-methods)

The following code uses a `ContentSafetyClient` to call the `AnalyzeText` convenience method:

:::code source="snippets/protocol-convenience-methods/AzureCoreConvenience/Program.cs" highlight="10":::

The preceding code demonstrates the following `Azure.Core` convenience method patterns:

- Uses a standard C# primitive or model type as a parameter.
- Returns a friendly C# type that represents the result of the operation.

### [Protocol method](#tab/protocol-methods)

The following code uses a `ContentSafetyClient` to call the `AnalyzeText` protocol method:

:::code source="snippets/protocol-convenience-methods/AzureCoreProtocol/Program.cs" highlight="19-24":::

The preceding code demonstrates the following protocol method patterns:

- Uses the `RequestContent` type to supply data for the request body.
- Uses the `RequestContext` type to configure request options.
- Returns data using the `Response` type.
- Reads content from the response data into a [dynamic](../../csharp/advanced-topics/interop/using-type-dynamic.md) type using <xref:Azure.AzureCoreExtensions.ToDynamicFromJson%2A>. For more information, see [Announcing dynamic JSON in the Azure Core library for .NET](https://devblogs.microsoft.com/azure-sdk/dynamic-json-in-azure-core/).

> [!NOTE]
> The preceding code configures the `ClientErrorBehaviors.NoThrow` for the `RequestOptions`. This option prevents non-success service responses status codes from throwing an exception, which means the app code should manually handle the response status code checks.

---

### Libraries that depend on System.ClientModel

Some client libraries that connect to non-Azure services use patterns similar to the libraries that depend on `Azure.Core`. For example, the [`OpenAI`](https://www.nuget.org/packages/OpenAI) library provides a client that connects to the OpenAI services. These libraries are based on a library called `System.ClientModel` that has patterns similar to `Azure.Core`.

### [Convenience method](#tab/convenience-methods)

Consider the following code that uses a `ChatClient` to call the `CompleteChat` convenience method:

:::code source="snippets/protocol-convenience-methods/SCMConvenience/Program.cs" highlight="9":::

The preceding code demonstrates the following `System.ClientModel` convenience method patterns:

- Uses a standard C# primitive or model type as a parameter.
- Returns a `ClientResult` type that represents the result of the operation.

### [Protocol method](#tab/protocol-methods)

The following code uses a `ChatClient` to call the `CompleteChat` protocol method:

:::code source="snippets/protocol-convenience-methods/SCMProtocol/Program.cs" highlight="26-31":::

The preceding code demonstrates the following `System.ClientModel` protocol method patterns:

- Uses the `BinaryContent` type as a parameter to supply data for the request body.
- Uses the `RequestContext` type to configure request options.
- Returns data using the `ClientResult` type.
- Calls the <xref:System.ClientModel.ClientResult.GetRawResponse%2A> method to access the response data.

> [!NOTE]
> The preceding code configures the [ClientErrorBehaviors.NoThrow](/dotnet/api/system.clientmodel.primitives.clienterrorbehaviors) behavior for the `RequestOptions`. This option prevents non-success service responses status codes from throwing an exception, which means the app code should manually handle the response status code checks.

A `System.ClientModel`-based response can be processed like a convenience model, if you take a dependency on `Azure.Core`. The following diff shows this alternative approach, which follows the same approach demonstrated in the **Protocol method** tab of [Libraries that depend on Azure.Core](#libraries-that-depend-on-azurecore).

```diff
PipelineResponse response = result.GetRawResponse();

- BinaryData output = result.GetRawResponse().Content;
- using JsonDocument outputAsJson = JsonDocument.Parse(output);
- JsonElement message = outputAsJson.RootElement
-     .GetProperty("choices"u8)[0]
-     .GetProperty("message"u8);

- Console.WriteLine($@"[{message.GetProperty("role"u8)}]:
-     {message.GetProperty("content"u8)}");

+ dynamic output = response.Content.ToDynamicFromJson(
+     JsonPropertyNames.CamelCase);
+ var message = output.Choices[0].Message;
+ Console.WriteLine($"[{message.Role}]: {message.Content}");
```

---

## Protocol and convenience method usage guidance

Although the Azure SDK for .NET client libraries provide the option to use either protocol or convenience methods, prioritize using convenience methods in most scenarios. Convenience methods are designed to improve the development experience and provide flexibility for authoring requests and handling responses. However, both method types can be used in your app as needed. Consider the following criteria when deciding which type of method to use.

Convenience methods:

- Enable you to work with more friendly method parameter and response types.
- Handle various low-level concerns and optimizations for you.

Protocol methods:

- Provide access to lower-level types, such as `RequestContext` and `RequestOptions`, which aren't available through convenience methods.
- Enable access to features of the underlying REST APIs that convenience methods don't expose.
- Enable you to create your own convenience methods around service endpoints that don't already have convenience methods. This approach requires understanding the service's REST API documentation to handle requests and responses correctly.

## See also

- [Understanding the Azure Core library for .NET](https://devblogs.microsoft.com/azure-sdk/understanding-the-azure-core-library-for-net/)
- [Azure.Core library for .NET](/dotnet/api/overview/azure/core-readme)
- [System.ClientModel library for .NET](/dotnet/api/overview/azure/system.clientmodel-readme)
