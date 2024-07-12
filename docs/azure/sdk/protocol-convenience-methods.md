---
title: Understand Azure SDK protocol methods
description: Learn about the key differences between Azure SDK protocol methods and convenience methods
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-arm-template
ms.date: 06/24/2024
---

# Azure SDK for .NET protocol and convenience methods overview

The Azure SDK client libraries provide an interface to Azure service REST APIs by translating method calls into underlying HTTP requests. In this article, you'll learn about the different types of methods exposed by the client libraries and explore their implementation patterns.

## Understand protocol and convenience methods

The Azure SDK for .NET client libraries expose two different categories of methods to make requests to an Azure service:

- **Protocol methods** provide a thin wrapper around the underlying REST API for a corresponding Azure service. These methods map primitive input parameters to HTTP request values and return a raw HTTP response object.

- **Convenience methods** provide a convenience layer over the lower-level protocol layer to add support for the .NET type system and other benefits. Convenience methods accept primitives or C# model types as parameters and map them to the body of an underlying REST API request. These methods also handle various details of request and response management to allow developers to focus on sending and receiving data objects, instead of lower-level concerns.

### Azure SDK client library dependency patterns

Protocol and convenience methods implement slightly different patterns based on the underlying package dependency chain of the respective library. The Azure SDK for .NET client libraries depend on one of two different lower-level libraries:

- [**Azure.Core**](/dotnet/api/overview/azure/core-readme) provides shared primitives, abstractions, and helpers for building modern Azure SDK for .NET client libraries. These libraries follow the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) and use package and namespace names prefixed with 'Azure', such as [`Azure.Storage.Blobs`](/dotnet/api/overview/azure/storage.blobs-readme).

- [**System.ClientModel**](/dotnet/api/overview/azure/system.clientmodel-readme) is a lower-level library that provides shared primitives, abstractions, and helpers for .NET service client libraries. The `System.ClientModel` library is a general purpose toolset designed to help build libraries for a variety of platforms and services, whereas the `Azure.Core` library is specifically designed for building Azure client libraries.

> [!NOTE]
> The `Azure.Core` library itself also depends on the `System.ClientModel` for various service building blocks. In the context of this article, the key differentiator for method patterns is whether a client library depends on `Azure.Core` or `System.ClientModel` directly, rather than through a nested dependency.

The following table compares some of the request and response types used by protocol and convenience methods based on whether the library depend on `Azure.Core` or `System.ClientModel`:

|Request or response concern  |Azure.Core  | System.ClientModel |
|---------|---------|---------|
|Request body     | `RequestContent`         | `BinaryContent`         |
|Advanced options     | `RequestContext`         | `RequestOptions`         |
|Raw HTTP Response     | `Response`         | `PipelineResponse`         |
|Input model     | `IPersistableModel<T>`         | `IPersistableModel<T>`         |
|Output model     | `IPersistableModel<T>`         | `IPersistableModel<T>`         |
|Return type with output model     | `Response<T>`         | `ClientResult<T>`         |

The sections ahead provide implementation examples of these concepts.

## Protocol and convenience method examples

The coding patterns and types used by client library protocol and convenience methods vary slightly based on whether the library depends on `Azure.Core` or `System.ClientModel`. The differences primarily influence the C# types used for handling request and response data.

### Libraries that depend on Azure.Core

Many Azure SDK client libraries depend on the `Azure.Core` library. For example, the [`Azure.AI.ContentSafety`](/dotnet/api/overview/azure/ai.contentsafety-readme) library depends on the `Azure.Core` library and provides a `ContentSafetyClient` class that exposes both protocol and convenience methods.

#### Work with protocol methods

The following code uses a `ContentSafetyClient` to call the `AnalyzeText` protocol method:

```csharp
// Create the client
var safetyClient = new ContentSafetyClient(
    new Uri("content-safety-service-uri"),
    new AzureKeyCredential("content-safety-key"));

// Create the message content
RequestContent message = RequestContent.Create(new
    {
        text = "What is Microsoft Azure?",
    });

// Call the protocol method
Response response = safetyClient.AnalyzeText(
    message, 
    new RequestContext()
    {
         ErrorOptions = ErrorOptions.NoThrow;
    });

// Display the results
using (StreamReader streamReader = new StreamReader(response.ContentStream))
{
    Console.WriteLine(streamReader.ReadToEnd());
}
```

The preceding code demonstrates the following protocol method patterns:

- Uses the `RequestContent` type as a  to supply data for the request body.
- Uses the `RequestContext` type to configure request options.
- Returns data using the `Response` type.
- Reads the `ContentStream` to access the response data.

#### Work with convenience methods

The following code uses a `ContentSafetyClient` to call the `AnalyzeText` convenience method:

```csharp
// Create the client
var safetyClient = new ContentSafetyClient(
    new Uri("content-safety-service-uri"),
    new AzureKeyCredential("content-safety-key"));

// Call the convenience method
AnalyzeTextResult result = safetyClient.AnalyzeText("What is Microsoft Azure?");

// Print the results
foreach (var item in result.CategoriesAnalysis)
{
    Console.Write($"{item.Category}: ");
    Console.Write(item.Severity);
    Console.WriteLine();
}
```

The preceding code demonstrates the following `Azure.Core` convenience method patterns:

- Uses a standard C# primitive or model type as a parameter.
- Returns a friendly C# type that represents the result of the operation.

### Libraries that depend on System.ClientModel

Some Azure client libraries depend directly on the `System.ClientModel` library. For example, the [`OpenAI`](https://www.nuget.org/packages/OpenAI/2.0.0-beta.7) library depends on the `System.ClientModel` library and provides a `ChatClient` class that exposes both protocol and convenience methods.

#### Work with protocol methods

The following code uses a `ChatClient` to call the `CompleteChat` protocol method:

```csharp
OpenAIClient client = new("your-openai-key");
ChatClient chatClient = client.GetChatClient("gpt-4");

BinaryData input = BinaryData.FromBytes("""
    {  
        "model": "gpt-4o",
        "messages": [
           {
               "role": "user",
               "content": "What is Microsoft Azure?."
           }
        ]
    }
    """u8.ToArray());
    
using BinaryContent content = BinaryContent.Create(input);
ClientResult result = chatClient.CompleteChat(
        content,
        new RequestOptions()
        { 
            ErrorOptions = ClientErrorBehaviors.NoThrow
        });
BinaryData output = result.GetRawResponse().Content;

using JsonDocument outputAsJson = JsonDocument.Parse(output);
string message = outputAsJson.RootElement
    .GetProperty("choices"u8)[0]
    .GetProperty("message"u8)
    .GetProperty("content"u8)
    .GetString();

Console.WriteLine(message);
```

The preceding code demonstrates the following `System.ClientModel` protocol method patterns:

- Uses the `BinaryContent` type as a parameter to supply data for the request body.
- Uses the `RequestContext` type to configure request options.
- Returns data using the `ClientResult` type.
- Calls the `GetRawResponse` method to access the response data.

#### Work with convenience methods

Consider the following code that uses a `ChatClient` to call the `CompleteChat` convenience method:

```csharp
OpenAIClient client = new("your-openai-key");
ChatClient chatClient = client.GetChatClient("gpt-4");

ClientResult<ChatCompletion> completion
    = chatClient.CompleteChat("What is Azure?");

Console.WriteLine($"{completion.Value.Role}: {completion.Value.Content}");
```

The preceding code demonstrates the following `System.ClientModel` convenience method patterns:

- Uses a standard C# primitive or model type as a parameter.
- Returns a `ClientResult` type that represents the result of the operation.

## Protocol and convenience method usage guidance

Many Azure SDK client libraries provide the option to use either protocol or convenience methods, but in most scenarios developers should prioritize convenience methods. Convenience methods are designed to improve the development experience while still providing flexibility when authoring requests and handling responses. Consider the following criteria when deciding which type of method to use:

- Convenience methods:
  - Enable you to work with more friendly method parameter and response types.
  - Handle various low-level concerns and optimizations for you.

- Protocol methods:
  - Provide access to lower-level types such as `RequestContext` and `RequestOptions` that are not available through convenience methods.
  - Enable access to features of the underlying REST APIs that convenience methods do not expose.

## See also

- [Understanding the Azure Core library for .NET](https://devblogs.microsoft.com/azure-sdk/understanding-the-azure-core-library-for-net/)
- [System.ClientModel library for .NET](/dotnet/api/overview/azure/system.clientmodel-readme)
