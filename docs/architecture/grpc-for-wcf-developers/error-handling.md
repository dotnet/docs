---
title: Error handling - gRPC for WCF Developers
description: Topics pertaining to error handling in gRPC. Includes a table of the most commonly used status codes.
ms.date: 09/02/2019
---

# Error handling

[!INCLUDE [download-alert](includes/download-alert.md)]

Windows Communication Foundation (WCF) uses <xref:System.ServiceModel.FaultException%601> and [FaultContract](xref:System.ServiceModel.FaultContractAttribute) to provide detailed error information, including supporting the SOAP Fault standard.

Unfortunately, the current version of gRPC lacks the sophistication found with WCF, and only has limited built-in error handling based on simple status codes and metadata. The following table is a quick guide to the most commonly used status codes:

| Status code | Problem |
| ----------- | ------- |
| `GRPC_STATUS_UNIMPLEMENTED` | Method hasn't been written. |
| `GRPC_STATUS_UNAVAILABLE` | Problem with the whole service. |
| `GRPC_STATUS_UNKNOWN` | Invalid response. |
| `GRPC_STATUS_INTERNAL` | Problem with encoding/decoding. |
| `GRPC_STATUS_UNAUTHENTICATED` | Authentication failed. |
| `GRPC_STATUS_PERMISSION_DENIED` | Authorization failed. |
| `GRPC_STATUS_CANCELLED` | Call was canceled, usually by the caller. |

## Raise errors in ASP.NET Core gRPC

An ASP.NET Core gRPC service can send an error response by throwing an `RpcException`, which can be caught by the client as if it were in the same process. The `RpcException` must include a status code and description, and can optionally include metadata and a longer exception message. The metadata can be used to send supporting data, similar to how `FaultContract` objects can carry additional data for WCF errors.

```csharp
public async Task<GetPortfolioResponse> GetPortfolio(GetPortfolioRequest request, ServerCallContext context)
{
    var user = context.GetHttpContext().User;
    if (!ValidateUser(user))
    {
        var metadata = new Metadata
        {
            { "User", user.Identity.Name }
        };
        throw new RpcException(new Status(StatusCode.PermissionDenied, "Permission denied"), metadata);
    }
}
```

## Catch errors in gRPC clients

Just like WCF clients can catch <xref:System.ServiceModel.FaultException%601> errors, a gRPC client can catch an `RpcException` to handle errors. Because `RpcException` isn't a generic type, you can't catch different error types in different blocks. But you can use C#'s *exception filters* feature to declare separate `catch` blocks for different status codes, as shown in the following example:

```csharp
try
{
    var portfolio = await client.GetPortfolioAsync(new GetPortfolioRequest { Id = id });
}
catch (RpcException ex) when (ex.StatusCode == StatusCode.PermissionDenied)
{
    var userEntry = ex.Trailers.FirstOrDefault(e => e.Key == "User");
    Console.WriteLine($"User '{userEntry.Value}' does not have permission to view this portfolio.");
}
catch (RpcException)
{
    // Handle any other error type ...
}
```

> [!IMPORTANT]
> When you provide additional metadata for errors, be sure to document the relevant keys and values in your API documentation, or in comments in your `.proto` file.

## gRPC richer error model

Google has developed a [richer error model](https://cloud.google.com/apis/design/errors#error_model) that's more like WCF's [FaultContract](xref:System.ServiceModel.FaultContractAttribute), but this model isn't supported in C# yet. Currently, it's only available for Go, Java, Python, and C++.

>[!div class="step-by-step"]
>[Previous](metadata.md)
>[Next](ws-protocols.md)
