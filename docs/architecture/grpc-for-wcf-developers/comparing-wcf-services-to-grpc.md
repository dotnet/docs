---
title: Comparing WCF to gRPC - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# Comparing WCF to gRPC

The previous chapter should have given you a good look at Protobuf and how messages are handled in gRPC.  Before working through a detailed conversion from WCF to gRPC, it is important to look at how the range of features currently available in WCF are handled in gRPC and what workarounds you can use when there does not appear to be a gRPC equivalent. In particular, this chapter will cover operations and methods, bindings and transports, types of RPC, metadata, error handling and the WS-* protocols.

## gRPC example

When you create a new ASP.NET Core 3.0 gRPC project from Visual Studio 2019 or the command line, the gRPC equivalent of "Hello World" is generated for you. It consists of a `greeter.proto` file that defines the service and its messages, and a `GreeterService.cs` file with an implementation of the service.

```protobuf
syntax = "proto3";

option csharp_namespace = "HelloGrpc";

package Greet;

// The greeting service definition.
service Greeter {
  // Sends a greeting
  rpc SayHello (HelloRequest) returns (HelloReply);
}

// The request message containing the user's name.
message HelloRequest {
  string name = 1;
}

// The response message containing the greetings.
message HelloReply {
  string message = 1;
}
```

```csharp
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace HelloGrpc
{
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
}
```

This chapter will refer to this example code when explaining various concepts and features of gRPC.

>[!div class="step-by-step"]
<!-->[Next](wcf-endpoints-and-grpc-methods.md)-->
