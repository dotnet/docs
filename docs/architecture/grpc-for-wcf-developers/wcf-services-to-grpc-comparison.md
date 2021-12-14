---
title: Comparing WCF to gRPC - gRPC for WCF developers
description: A comparison of the WCF and gRPC frameworks for building distributed applications.
ms.date: 12/14/2021
---

# Comparing WCF to gRPC

The previous chapter gave you a good look at Protobuf and how gRPC handles messages. Before you work through a detailed conversion from Windows Communication Foundation (WCF) to gRPC, it's important to know how the features available in WCF are handled in gRPC and what workarounds you can use when there's no gRPC equivalent. In particular, this chapter will cover the following subjects:

- Operations and methods
- Bindings and transports
- RPC types
- Metadata
- Error handling
- WS-\* protocols

## gRPC example

When you create a new ASP.NET Core 6.0 gRPC project from Visual Studio 2022 or the command line, the gRPC equivalent of "Hello World" is generated for you. It consists of a `greeter.proto` file that defines the service and its messages, and a `GreeterService.cs` file with an implementation of the service.

```protobuf
syntax = "proto3";

option csharp_namespace = "HelloGrpc";

package Greet;

// The greeting service definition.
service Greeter {
  // Sends a greeting
  rpc SayHello (HelloRequest) returns (HelloReply);
}

// The request message that contains the user's name.
message HelloRequest {
  string name = 1;
}

// The response message that contains the greetings.
message HelloReply {
  string message = 1;
}
```

```csharp
namespace HelloGrpc;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
```

This chapter will refer to this example code when explaining different concepts and features of gRPC.

>[!div class="step-by-step"]
>[Previous](protobuf-maps.md)
>[Next](wcf-endpoints-grpc-methods.md)
