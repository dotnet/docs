---
title: Metadata - gRPC for WCF developers
description: How metadata is used in gRPC to pass additional context between clients and servers.
ms.date: 09/02/2019
---

# Metadata

[!INCLUDE [download-alert](includes/download-alert.md)]

*Metadata* refers to additional data that might be useful during the processing of requests and responses but that’s not part of the actual application data. Metadata might include authentication tokens, request identifiers and tags for monitoring purposes, and information about the data, like the number of records in a dataset.

It's possible to add generic key/value headers to Windows Communication Foundation (WCF) messages by using an <xref:System.ServiceModel.OperationContextScope> and the <xref:System.ServiceModel.OperationContext.OutgoingMessageHeaders?displayProperty=nameWithType> property and handle them by using <xref:System.ServiceModel.Channels.MessageProperties>.

gRPC calls and responses can also include metadata that's similar to HTTP headers. This metadata is mostly invisible to gRPC itself and is passed through to be processed by your application code or middleware. Metadata is represented as key/value pairs, where the key is a string and the value is either a string or binary data. You don’t need to specify metadata in the `.proto` file.

Metadata is handled by the `Metadata` class of the [Grpc.Core.Api](https://www.nuget.org/packages/Grpc.Core.Api/) NuGet package. This class can be used with collection initializer syntax.

This example shows how to add metadata to a call from a C# client:

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

Services can send metadata to clients by using the `ResponseTrailers` property of `ServerCallContext`:

```csharp
public async Task<GetPortfolioResponse> GetPortfolio(GetPortfolioRequest request, ServerCallContext context)
{
    // ...
    context.ResponseTrailers.Add("Responder", _serverName);
    // ...
}
```

>[!div class="step-by-step"]
>[Previous](rpc-types.md)
>[Next](error-handling.md)
