---
title: WCF bindings and transports - gRPC for WCF Developers
description: Learn how the different WCF bindings and transports compare to gRPC.
ms.date: 09/02/2019
---

# WCF bindings and transports

WCF has lots of different built-in *bindings* that specify different network protocols, wire formats, and other implementation details. gRPC effectively has just one network protocol and one wire format (technically the wire format *may* be customized, but that is beyond the scope of this book). You are likely to discover that gRPC offers the best solution in most cases. What follows is a short discussion about the most relevant WCF bindings and how they compare to their equivalent in gRPC.

## NetTCP

WCF's NetTCP binding allows for persistent connections, small messages, and two-way messaging but only works between .NET clients and servers. gRPC allows the same functionality but is supported across multiple programming languages and platforms. gRPC has many of the features of WCF NetTCP binding, although not always implemented in the same way. For example, in WCF, encryption is controlled through configuration and handled in the framework. In gRPC, encryption is achieved at the connection level using HTTP/2 over TLS.

## HTTP

WCF's BasicHttpBinding is usually text based, using SOAP as the wire format, and is slow compared to the NetTCP binding. It's generally used to provide cross-platform interoperability, or connection over internet infrastructure. The equivalent in gRPC—because it uses HTTP/2 as the underlying transport layer with the binary Protobuf wire format for messages—can offer NetTCP service level performance but with full cross-platform interoperability with all modern programming languages and frameworks.

## Named Pipes

WCF provided a Named Pipes binding for communication between processes on the same physical machine. Named pipes are not supported by the first release of ASP.NET Core gRPC. Adding client and server support for named pipes (and Unix domain sockets) is a goal for a future release.

## MSMQ

MSMQ is a proprietary Windows message queue. WCF's binding to MSMQ enables "fire and forget" requests from clients that may be processed at any time in the future. gRPC doesn't natively provide any message queue functionality. The best alternative would be to directly use a messaging system like Azure Service Bus, RabbitMQ, or Kafka. This could be implemented with the client placing messages directly onto the queue, or a gRPC client streaming service that enqueues the messages.

## WebHttpBinding

The WebHttpBinding (also known as WCF ReST), with the `WebGet` and `WebInvoke` attributes, enabled you to develop ReSTful APIs that could speak JSON at a time when this was less common than now. Therefore, if you have a RESTful API built with WCF REST, consider migrating it to a regular ASP.NET Core MVC Web API application, which would provide equivalent functionality, rather than converting to gRPC.

>[!div class="step-by-step"]
>[Previous](wcf-endpoints-grpc-methods.md)
>[Next](rpc-types.md)
