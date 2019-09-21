---
title: Metadata - gRPC for WCF Developers
description: How metadata is used in gRPC to pass additional context between clients and servers
author: markrendle
ms.date: 09/02/2019
---

# Metadata

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

"Metadata" refers to additional data that may be useful while processing requests and responses but is not part of the actual application data. Metadata might include authentication tokens, request identifiers and tags for monitoring purposes, or information about the data like the number of records in a dataset.

It's possible to add generic key/value headers to WCF messages using an <xref:System.ServiceModel.OperationContextScope> and the <xref:System.ServiceModel.OperationContext.OutgoingMessageHeaders?displayProperty=nameWithType> property, and handle them using <xref:System.ServiceModel.Channels.MessageProperties>.

gRPC calls and responses can also include metadata similar to HTTP headers. These are mostly invisible to gRPC itself and are passed through to be processed by your application code or middleware. Metadata is represented as key/value pairs where the key is a string and the value is either a string or binary data. You don’t need to specify metadata in the `.proto` file.

Metadata is handled using the `Metadata` class from the [Grpc.Core](https://www.nuget.org/packages/Grpc.Core/) NuGet package. This class can be used with collection initializer syntax.

The following example shows how to add metadata to a call from a C# client:

```csharp
var metadata = new Metadata
{
    { "Requester", _clientName }
};

var request = new GetPortfolioRequest
{
    Id = portfolioId
};

var response = await client.GetPortfolioAsync(request, metadata);
```

gRPC services can access metadata from the `ServerCallContext` argument's `RequestHeaders` property:

```csharp
public async Task<GetPortfolioResponse> GetPortfolio(GetPortfolioRequest request, ServerCallContext context)
{
    var requesterHeader = context.RequestHeaders.FirstOrDefault(e => e.Key == "Requester");
    if (requesterHeader != null)
    {
        _logger.LogInformation($"Request from {requesterHeader.Value}");
    }
    // ...
}
```

Services can send metadata to clients using the `ResponseTrailers` property of `ServerCallContext`:

```csharp
public async Task<GetPortfolioResponse> GetPortfolio(GetPortfolioRequest request, ServerCallContext context)
{
    // ...
    context.ResponseTrailers.Add("Responder", _serverName);
    // ...
}

>[!div class="step-by-step"]
<!-->[Next](error-handling.md)-->
