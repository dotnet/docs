---
title: Metadata - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# Metadata

It is possible to add generic key/value headers to WCF messages using an [OperationContextScope](https://docs.microsoft.com/en-us/dotnet/api/system.servicemodel.operationcontextscope?view=netframework-4.8) and the [OperationContext.OutgoingMessageHeaders](https://docs.microsoft.com/en-us/dotnet/api/system.servicemodel.operationcontext.outgoingmessageheaders?view=netframework-4.8) property.

gRPC calls and responses can also include metadata similar to HTTP headers. These are invisible to gRPC itself and are just passed through. Metadata is represented as Key/Value Pairs where the key is a string and the value is either a string or binary data. You don’t need to specify metadata in the .proto file.

Metadata is handled using the `Metadata` class from the [Grpc.Core](https://www.nuget.org/packages/Grpc.Core/) package. This class can be used with collection initializer syntax.

Here is an example of adding metadata to a call from a C# client.

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

gRPC services can access metadata from the `ServerCallContext` argument's `RequestHeaders` property.

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

Services can send metadata to clients using the `ResponseTrailers` property of `ServerCallContext`.

```csharp
public async Task<GetPortfolioResponse> GetPortfolio(GetPortfolioRequest request, ServerCallContext context)
{
    // ...
    context.ResponseTrailers.Add("Responder", _serverName);
    // ...
}

>[!div class="step-by-step"]
<!-->[Next](error-handling.md)-->
