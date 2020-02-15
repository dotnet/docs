---
title: REST and gRPC
description: Learn about gRPC, its role in cloud-native applications and how it differs from HTTP REST
author: robvet
ms.date: 11/25/2019
---

# gRPC

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

So far in this book, we’ve focused on [REST-based](https://docs.microsoft.com/azure/architecture/best-practices/api-design) communication. REST is a flexible architectural style that defines CRUD-based operations against data resources. Clients interact with these resources across HTTP using a request/response communication model. While REST is widely used, a newer communication technology, gRPC, is rapidly gaining popularity for cloud-native applications.

## Introduction

Originating from Google, gRPC is a open-source communication technology that evolves the RPC [remote procedure call (RPC)](https://en.wikipedia.org/wiki/Remote_procedure_call) protocol widely found in distributed applications. A gRPC client app exposes a local, in-process function that implements an operation. Under the covers, that local method invokes a function from a service on remote machine. What appears to be local call essentially becomes an out-of-process call to a function on a remote computer. The RPC plumbing abstracts the point-to-point networking communication, serialization, and execution between computers.

gRPC is lightweight and highly performant. It uses HTTP/2 for its transport protocol. While compatible with HTTP 1.1, HTTP/2 features many advanced capabilities:

- A binary protocol for data transport - unlike HTTP 1.1, which sends data as clear text.
- Multiplexing support for sending multiple parallel requests over the same connection - unlike HTTP 1.1 which is limited to processing one request/response at a time.
- Full-duplex enabling bidirectional communication where both client requests and server responses are sent simultaneously.
- Built-in streaming enabling requests and responses to asynchronously stream large data sets.
- Support across most popular development stacks, including Java, JavaSript, C#, Golang, Swift, and NodeJS. 

gRPC with HTTP/2 is a high performance communication protocol. It can be up to 8x faster than JSON serialization with messages 60-80% smaller. In Microsoft [Windows Communication Foundation (WCF)](https://docs.microsoft.com/dotnet/framework/wcf/whats-wcf) parlance, gRPC performance exceeds the speed and efficiency of [NetTCP bindings](https://docs.microsoft.com/dotnet/api/system.servicemodel.nettcpbinding?view=netframework-4.8). Unlike NetTCP, which favors the Microsoft stack, gRPC is cross-platform.

## Protocol Buffers

gRPC embraces another open-source technology called [Protocol Buffers](https://developers.google.com/protocol-buffers/docs/overview). Protocol Buffers provide a highly efficient, platform-neutral engine for serializing structured messages that services send to each other. Using a cross-platform Interface Definition Language (IDL), developers defines a service contract for each microservice. The contract, implemented as a ".proto" file, describes the methods, inputs, and outputs for each service. Using the .proto file, the Protobuf compiler, "Proton," genrates client and service code for your target platform. The code includes the following components:

- A strongly-typed DTO (Data Transfer Object) shared by the client and service.
- A strongly-typed base class with the required network plumbing that the service can inherit and extend.
- A stub for the client that contains the required plumbing to invoke the remote service.

At runtime, each message is serialized as a standard Protobuf representation and exchanged across client and remote services.

The book, [gRPC for WCF Developers](https://docs.microsoft.com/dotnet/architecture/grpc-for-wcf-developers/), available for the Microsoft Architecture Site, provides detailed coverage of gRPC and Protocol Buffers. 

## gRPC support in .NET

Microsoft .NET Core 3.0 includes tooling and native support for gRPC. It seamlessly integrates gRPC into its framework, including endpoint routing, built-in IoC support, and logging. The open-source Kestrel web server fully supports HTTP/2 connections. Figure 4-20 shows a Visual Studio 2019 template that scaffolds a skeleton project for a gRPC service. Note how .NET Core fully supports the Windows, Linux, and macOS platforms.

![gRPC Support in Visual Studio 2019](./media/visual-studio-2019-grpc-template.png)

**Figure 4-20**. gRPC support in Visual Studio 2019
  
Figure 4-21 shows the structure of a gRPC service in Visual Studio 2019. Note the folders for the proto description files and service code. 

![gRPC project in Visual Studio 2019](./media/grpc-project.png  )

**Figure 4-21**. gRPC project in Visual Studio 2019

An excellent introduction to building a gRPC service is [gRPC with ASP.NET Core 3.0](https://www.dotnetcurry.com/aspnet-core/1514/grpc-asp-net-core-3) from the .NET Curry magazine series.

## gRPC usage

gRPC is well suited for the following scenarios:

- Synchronous backend micrservice communication where an immedate response is required in order to continue processing.
- Low latency and high throughput communication. gRPC is great for lightweight microservices where efficiency is critical.
- Point-to-point real-time communication. gRPC has excellent support for bi-directional streaming. gRPC services can push messages in real time without polling.
- Polyglot environments – gRPC tooling supports most modern development languages, making it a good choice for multi-language environments.
- Network constrained environments – gRPC messages are serialized with Protobuf, a lightweight message format. A gRPC message is always smaller than an equivalent JSON message.

As we disucssed, gRPC relies heavily on HTTP/2 features. At the time of this writing, most modern browsers cannot provide the level of control required to support a gRPC client.
 
 The [microservice reference architecture](https://github.com/dotnet-architecture/eShopOnContainers) for eShop on Containers provides guidance for implementing gRPC on the .NET Core platform. Figure 4-22 shows the implementation.
![gRPC Usage Patterns](./media/grpc-implementation.png)

**Figure 4-22**. gRPC implementation

In the previous figure, note how eShop exposes four different API gateways embracing the [Backend for Frontends pattern](https://docs.microsoft.com/azure/architecture/patterns/backends-for-frontends). The Web-Marketing gateway exposes simple CRUD operations with a RESTful. It also includes a Aggregator microservice that implements gRPC calls for complex operations that require synchronous calls to multiple backend microservices.

### gRPC client code

The API service leverages the built-in gRPC client plumbing from the .NET Core 3.1 framework.

You start by creating a .proto file which defines each the methods, inputs, and outputs for each exposed service operation. Figure-23 presents the proto file for the Shopping Basket service.  

```csharp
syntax = "proto3";

option csharp_namespace = "GrpcBasket";

package BasketApi;

service Basket {
	rpc GetBasketById(BasketRequest) returns (CustomerBasketResponse) {}
	rpc UpdateBasket(CustomerBasketRequest) returns (CustomerBasketResponse) {}
}

message BasketRequest {
	string id = 1;
}

message CustomerBasketRequest {
	string buyerid = 1;
	repeated BasketItemResponse items = 2;
}

message CustomerBasketResponse {
	string buyerid = 1;
	repeated BasketItemResponse items = 2;
}

message BasketItemResponse {
	string id = 1;
	int32 productid = 2;
	string productname = 3;
	double unitprice = 4;
	double oldunitprice = 5;
	int32 quantity = 6;
	string pictureurl = 7;
}
```
**Figure 4-23** Proto file for the Shopping Basket service

Once defined, you include the proto file in your service by declaring it in the .csproj file, shown in Figure 4-24.

```csharp
 <ItemGroup>
    <Protobuf Include="..\..\..\Services\Basket\Basket.API\Proto\basket.proto" GrpcServices="Client" />
  </ItemGroup>
```
**Figure 4-24** Declaring a proto file 

At this point, building the project will generate the gRPC plumbing which is added to the obj folder in the project. Figure 4-25 shows the generated code.

![gRPC client plumbing code](./media/grpc-client-plumbing.png)

**Figure 4-25** gRPC client plumbing code in Visual Studio 2019 

Now, you can add a service class that exposes local methods that leverages the grpc plumbing to make remote calls to the backend basket service.

### gRPC server code


 Both of these services implement gRPC client functionality, known as stubs, which provide the plumbing to make remote calls.

The backend Basket and Catalog services expose gRPC services.



Note in the previous figure that front-end traffic (both browser and mobile) is implemented with HTTP when invoking the API gateway. However, traffic behind the gateway and across microservices implement gRPC. As discussed previously, ".proto" files define each of the microservices and are used to generate code stubs for both the client and the service. Consideration should be given to centralizing the gRPC service definitions in a single repo. This practice minimizes duplication, improves manageability, and provides consistent versioning.  

Looking ahead, gRPC could well play a major role in dethroning the dominance of REST for cloud-native systems. The performance benefits and ease of development are compelling. However, make no mistake, REST will still be around for a long time. It still excels for publicly exposed APIs and for backward compatibility reasons.

>[!div class="step-by-step"] 
>[Previous](service-to-service-communication.md)
>[Next](service-mesh-communication-infrastructure.md)



In ASP.NET Core world gRPC is new kid on the block and it’s too early to say if it’s here to replace REST and WebAPI that are easier to consume for client applications. Actually I don’t think so. Having thin and simple service interface that doesn’t require advanced tooling will remain the important benefit.

When it comes to SOAP and WCF it’s a different story. Overview of Protocol Buffers brings out the following advantages of protocol buffer messages over XML based messages:

3 to 10 times smaller,
20 to 100 times faster,
less ambiguous.
Those who have experiences with WCF and SOAP should find these numbers great.

AS WCF is not officially supported on .NET Core then gRPC is currently the only serious option for enterprice grade messaging between systems.

Wrapping up
gRPC is a little bit similar to WCF but still a totally different beast. It is using binary format for data exchange between systems and it leads to way smaller message payloads. Using HTTP/2 features it provides four different communication patterns to support also services under heavy load of communication requests. As there’s no WCF support on .NET Core officially, gRPC is currently the best option to take when it’s about enterprise grade web services.
