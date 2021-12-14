---
title: WCF bindings and transports - gRPC for WCF developers
description: Learn how the different WCF bindings and transports compare to gRPC.
ms.date: 12/14/2021
---

# WCF bindings and transports

Windows Communication Foundation (WCF) has built-in *bindings* that specify different network protocols, wire formats, and other implementation details. gRPC effectively has just one network protocol and one wire format. (Technically you *can* customize the wire format, but that's beyond the scope of this book.) You're likely to discover that gRPC offers the best solution in most cases.

What follows is a short discussion about the most relevant WCF bindings and how they compare to their equivalents in gRPC.

## NetTCP

WCF's NetTCP binding allows for persistent connections, small messages, and two-way messaging. But it works only between .NET clients and servers. gRPC allows the same functionality but is supported across multiple programming languages and platforms.

gRPC has many features of WCF's NetTCP binding, but they're not always implemented in the same way. For example, in WCF, encryption is controlled through configuration and handled in the framework. In gRPC, encryption is achieved at the connection level through HTTP/2 over TLS.

## HTTP

The WCF binding called BasicHttpBinding is usually text-based and uses SOAP as the wire format. It's slow compared to the NetTCP binding. It's used to provide cross-platform interoperability, or connection over internet infrastructure.

The equivalent in gRPC uses HTTP/2 as the underlying transport layer with the binary Protobuf wire format for messages. So it can offer performance at the NetTCP service level and full cross-platform interoperability with all modern programming languages and frameworks.

## Named pipes

WCF provided a *named pipes* binding for communication between processes on the same physical machine. ASP.NET Core gRPC doesn't support named pipes. For inter-process communication (IPC) using gRPC instead supports Unix domain sockets. Unix domain sockets are supported on Linux and [modern versions of Windows](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/).

For more information, see [Inter-process communication with gRPC](/aspnet/core/grpc/interprocess).

## MSMQ

MSMQ is a proprietary Windows message queue. WCF's binding to MSMQ enables "fire and forget" requests from clients that might be processed at any time in the future. gRPC doesn't natively provide any message queue functionality.

The best alternative is to directly use a messaging system like Azure Service Bus, RabbitMQ, or Kafka. You can implement this functionality with the client placing messages directly onto the queue, or a gRPC client streaming service that enqueues the messages.

## WebHttpBinding

WebHttpBinding (also known as WCF REST), with the `WebGet` and `WebInvoke` attributes, enabled you to develop RESTful APIs that could speak JSON at a time when this behavior was less common. If you have a RESTful API built with WCF REST, consider migrating it to a regular ASP.NET Core MVC Web API application. This migration would provide the same functionality as a conversion to gRPC.

>[!div class="step-by-step"]
>[Previous](wcf-endpoints-grpc-methods.md)
>[Next](rpc-types.md)
