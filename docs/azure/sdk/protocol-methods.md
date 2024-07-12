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

Azure SDK client libraries expose two different categories of methods to make requests to an Azure service:

- **Protocol methods** provide a thin wrapper around the underlying REST API for a corresponding Azure service. Protocol methods feature the following map primitive input parameters to HTTP request values and return a raw HTTP response object.

- **Convenience methods** provide a convenience layer over the lower level protocol layer to add support for the .NET type system and other benefits. Convenience methods accept C# model types as parameters that map to the body of an underlying REST API request. These methods also handle the details of request and response management to allow developers to focus on sending and receiving data objects, instead of lower level concerns.

### Azure SDK client library dependency considerations

Azure SDK client libraries depend on one of two different low level libraries:

- **Azure.Core** provides shared primitives, abstractions, and helpers for building modern .NET Azure SDK client libraries. These libraries follow the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) and can be easily identified by package and namespaces names starting with 'Azure', e.g. `Azure.Storage.Blobs`.

- **System.ClientModel** provides shared primitives, abstractions, and helpers for .NET service client libraries. The `System.ClientModel` library is a general purpose library designed to help build libraries for a variety of platforms and services, whereas the `Azure.Core` library is specifically designed for building Azure client libraries.

Protocol and convenience methods implement slightly different patterns based on the underlying dependency chain of the respective library. These differences impact the types used for request parameters and response objects. 

The following table compares the differences between the request and response types used by client libraries based on their underlying dependency:

|Request and response types  |Azure.Core  | System.ClientModel |
|---------|---------|---------|
|Request body     | `RequestContent`         | `BinaryContent`         |
|Advanced Options     | `RequestContext`         | `RequestOptions`         |
|Raw HTTP Response     | `Response`         | `PipelineResponse`         |
|Input model     | `IPersistableModel<T>`         | `IPersistableModel<T>`         |
|Output model     | `IPersistableModel<T>`         | `IPersistableModel<T>`         |
|Return type with output model     | `Response<T>`         | `ClientResult<T>`         |

The sections ahead provide implement examples of these concepts.

## Work with protocol methods

The coding patterns and types used by client library protocol methods vary slightly depending on whether the relevant library depends on `Azure.Core` or `System.ClientModel`. The differences primarily surface in the C# types used for managing request and response data.

### Protocol methods using libraries that depend on Azure.Core

The `Azure.AI.ContentSafety` library depends on the `Azure.Core` library and provides a `ContentSafetyClient` class that exposes both protocol and convenience methods.

Consider the following code that uses the `AnalyzeText` protocol method on the `ContentSafetyClient`:

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
Response response = safetyClient.AnalyzeText(message, new RequestContext());

using (StreamReader streamReader = new StreamReader(response.ContentStream))
{
    // Display the results
    Console.WriteLine(streamReader.ReadToEnd());
}
```

The preceding code demonstrates the following protocol method concepts:
    - Uses the `RequestContent` type as a parameter.
    - Returns data using the `Response` type.
    - Reads the `ContentStream` to access the response data.

### Protocol methods using libraries that depend on System.ClientModel

The `OpenAI` library depends on the `System.ClientModel` library and provides a `ChatClient` class that exposes both protocol and convenience methods.

Consider the following code that uses the `AnalyzeText` protocol method on the `ChatClient`:

```C#
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
ClientResult result = chatClient.CompleteChat(content);
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
    - Uses the `BinaryContent` type as a parameter.
    - Returns data using the `ClientResult` type.
    - Reads the `GetRawResponse` method to access the response data.

## Work with convenience methods

Convenience methods streamline the client library development experience by handling various lower-level concerns internally. They enable you to pass your data objects as parameters directly and automatically handle mapping that data to the request body. Convenience methods often act as wrappers around the lower-level protocol methods.

### Convenience methods using libraries that depend on Azure.Core

The `Azure.AI.ContentSafety` library depends on the `Azure.Core` library and provides a `ContentSafetyClient` class that exposes convenience methods.

Consider the following code that uses the `AnalyzeText` protocol method on the `ContentSafetyClient`:

```csharp
// Create the client
var safetyClient = new ContentSafetyClient(
    new Uri("content-safety-service-uri"),
    new AzureKeyCredential("content-safety-key"));

// Call the convenience method
AnalyzeTextResult result2 = safetyClient.AnalyzeText("What is Microsoft Azure?");

foreach (var item in result2.CategoriesAnalysis)
{
    Console.Write($"{item.Category}: ");
    Console.Write(item.Severity);
    Console.WriteLine();
}
```

The preceding code demonstrates the following `Azure.Core` convenience method patterns:
    - Uses a standard C# primitive or model type as a parameter.
    - Returns a friendly C# type that represents the result of the operation.

### Convenience methods using libraries that depend on System.ClientModel

```csharp
AsyncResultCollection<StreamingChatCompletionUpdate> updates
    = chatClient.CompleteChatStreamingAsync("Say 'this is a test.'");

Console.WriteLine($"Assistant:");
await foreach (StreamingChatCompletionUpdate update in updates)
{
    foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
    {
        Console.Write(updatePart.Text);
    }
}
```
