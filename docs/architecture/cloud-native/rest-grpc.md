---
title: REST and gRPC
description: Learn about gRPC, its role in cloud-native applications and how it differs from HTTP REST
author: robvet
ms.date: 09/08/2019
---

# gRPC

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

So far in this book, we’ve focused on [REST-based](https://docs.microsoft.com/azure/architecture/best-practices/api-design) communication. REST is an architectural style that promotes interoperability between services distributed across computer systems. It's implemented with a HTTP-based request/response model. Every response from the server is a reply to a request from a client. While REST is widely implemented, a newer communication technology, entitled gRPC, is rapidly gaining popularity for cloud-native applications.

## Introduction

gRPC is an open-source communication protocol that originates from Google. It's built upon the [remote procedure call (RPC)](https://en.wikipedia.org/wiki/Remote_procedure_call) model, popular in distributed computing. A local client program exposes an in-process method to execute what appears to be a local operation. Behind the scenes, however, the local call invokes an out-of-process call to a remote microservice across a distributed network. The developer codes the operation as a local procedure call. The underlying platform abstracts the point-to-point networking communication, serialization, and execution.

gRPC is a modern RPC framework that is lightweight and highly performant. It uses HTTP/2 for its transport protocol. While compatible with HTTP 1.1, HTTP/2 features many advanced capabilities:

- HTTP/2 is a binary protocol, unlike HTTP 1.1, which sends data as clear text.
- HTTP/2 supports multiplexing, or multiple parallel requests over the same connection, while HTTP 1.1 is limited to processing one request/response round trip at a time.
- HTTP/2 supports full-duplex, or bidirectional communication, where both client and server and can communicate at the same time. The client can be sending request data at the same time the server is returning response data.
- HTTP/2 features built-in streaming with which both requests and responses can asynchronously stream large data sets. Multiple data streams can process independently on the same HTTP/2 connection.
- Combining gRPC and HTTP/2, performance dramatically increases. In Microsoft [Windows Communication Foundation (WCF)](https://docs.microsoft.com/dotnet/framework/wcf/whats-wcf) parlance, gRPC performance meets and exceeds the speed and efficiency of [NetTCP bindings](https://docs.microsoft.com/dotnet/api/system.servicemodel.nettcpbinding?view=netframework-4.8). However, unlike NetTCP, which favors the Microsoft stack, gRPC is cross-platform.

gRPC is supported across most popular platforms, including Java, JavaSript, C#, Golang, and NodeJS.

## Protocol Buffers

gRPC embraces another open-source technology called [Protocol Buffers](https://developers.google.com/protocol-buffers/docs/overview). This technology is used to define service contracts for each microservice. Using a common Interface Definition Language (IDL), the developer creates a ".proto" file that describes each service along with its methods, inputs, and outputs. Then, using the Protobuf compiler, "Proton," the developer generates both client and server code for any of the supported platforms. The generated code is optimized for fast serialization/deserialization of data. At runtime, each message is wrapped in the strongly-typed service contract and serialized in a standard Protobuf representation.

The book, [gRPC for WCF Developers](https://docs.microsoft.com/en-us/dotnet/architecture/grpc-for-wcf-developers/), available for free from Microsoft, provides detailed coverage of gRPC and Protocol Buffers. 

## gRPC support in .NET

The Microsoft .NET Core framework 3.0 includes tooling and native support for gRPC. Figure 4-20 shows the Visual Studio 2019 template that scaffolds a gRPC skeleton project for a gRPC service. Note how .NET Core supports the Windows, Linux, and macOS platforms.

![gRPC Support in Visual Studio 2019](./media/visual-studio-2019-grpc-template.png)

**Figure 4-20**. gRPC support in Visual Studio 2019

.NET Core 3.0 seamlessly integrates gRPC into its framework, including endpoint routing, built-in IoC support, and logging. The open-source Kestrel web server fully supports HTTP/2 connections.  

Figure 4-21 shows the structure of a gRPC service in Visual Studio 2019. Note how the structure includes folders for the proto description files and the service code.

![gRPC project in Visual Studio 2019](./media/grpc-project.png  )

**Figure 4-21**. gRPC project in Visual Studio 2019

## gRPC Usage

gRPC is well suited for the following scenarios:

- Low latency and high throughput communication. gRPC is great for lightweight microservices where efficiency is critical.
- Point-to-point real-time communication. gRPC has excellent support for bi-directional streaming. gRPC services can push messages in real time without polling.
- Polyglot environments – gRPC tooling supports most popular development languages, making it a good choice for multi-language environments.
- Network constrained environments – gRPC messages are serialized with Protobuf, a lightweight message format. A gRPC message is always smaller than an equivalent JSON message.

At the time of writing of this book, most browsers have limited support for gRPC. gRPC heavily uses HTTP/2 features and modern don't provide the level of control required to support a gRPC client. gRPC is typically used for internal microservice to microservice communication. Figure 4-22 shows a simple, but common usage pattern.

![gRPC Usage Patterns](./media/grpc-usage.png)

**Figure 4-22**. gRPC usage patterns

Note in the previous figure how front-end traffic (both browser and mobile) is implemented with HTTP when invoking the API gateway. However, the gateway to microservice and microservice to microservice calls implement gRPC. As discussed previously, common ".proto" files define each of the microservices and are used to generate code stubs for both the calling client and the service itself. Consideration should be given to centralizing the gRPC service definitions in a single repo. This practice minimizes duplication, improves manageability, and provides consistent versioning.  

Looking ahead, gRPC could well play a major role in dethroning the dominance of REST for cloud-native systems. The performance benefits and ease of development are too good to pass up. However, make no mistake, REST will still be around for a long time. It still excels for publicly exposed APIs and for backward compatibility reasons.

>[!div class="step-by-step"] 
>[Previous](service-to-service-communication.md)
>[Next](service-mesh-communication-infrastructure.md)
