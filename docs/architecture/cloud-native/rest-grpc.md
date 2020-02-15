---
title: REST and gRPC
description: Learn about gRPC, its role in cloud-native applications and how it differs from HTTP REST
author: robvet
ms.date: 11/25/2019
---

# gRPC

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

So far in this book, we’ve focused on [REST-based](https://docs.microsoft.com/azure/architecture/best-practices/api-design) communication. We've seen that REST is a flexible architectural style that defines CRUD-based operations against data resources. Clients interact with these resources across HTTP using a request/response communication model. While REST is widely implemented, a newer communication technology, gRPC, is gaining rapid momentum for cloud-native applications.

## Introduction

gRPC is a modern, high-performance framework that evolves the RPC [remote procedure call (RPC)](https://en.wikipedia.org/wiki/Remote_procedure_call) protocol, traditionally found in distributed applications. As an application level tool, it streamlines messaging between clients and back-end services across multiple platforms. Originating from Google, gRPC is now part of the  [Cloud Native Computing Foundation (CNCF)](https://www.cncf.io/) ecosystem and is considered an [incubating project](https://github.com/cncf/toc/blob/master/process/graduation_criteria.adoc) at this time.  

In cloud-native applications, developers often work across programming languages, frameworks, and technologies. This inneroperability can complicate message contracts and the plumbing required for cross-service communication.  gRPC provides a "uniform horizontal layer" that abstracts these concerns, enabling developers to code in their native language and keep focus on business functionality - not communication plumbing.  

A gRPC client app exposes a local, in-process function that implements an operation. Under the covers, that local function invokes aother function from a service on remote machine. What appears to be a simple local call essentially becomes a transparent out-of-process call to a service on a remote computer. The RPC plumbing simplfies developer effort by abstracting the point-to-point networking communication, serialization, and execution between computers.

gRPC offers comprehensive support across most popular development stacks, including Java, JavaSript, C#, Golang, Swift, and NodeJS. 

## Performance

gRPC uses HTTP/2 for its transport protocol. While compatible with HTTP 1.1, HTTP/2 features many advanced capabilities:

- A binary protocol for data transport - unlike HTTP 1.1, which sends data as clear text.
- Multiplexing support for sending multiple parallel requests over the same connection - unlike HTTP 1.1 which is limited to processing one request/response at a time.
- Full-duplex enabling bidirectional communication where both client requests and server responses are sent simultaneously.
- Built-in streaming enabling requests and responses to asynchronously stream large data sets.

gRPC is lightweight and highly performant. It can be up to 8x faster than JSON serialization with messages 60-80% smaller. In Microsoft [Windows Communication Foundation (WCF)](https://docs.microsoft.com/dotnet/framework/wcf/whats-wcf) parlance, gRPC performance exceeds the speed and efficiency of [NetTCP bindings](https://docs.microsoft.com/dotnet/api/system.servicemodel.nettcpbinding?view=netframework-4.8). Unlike NetTCP, which favors the Microsoft stack, gRPC is cross-platform.

## Protocol Buffers

gRPC embraces an open-source technology called [Protocol Buffers](https://developers.google.com/protocol-buffers/docs/overview). Protocol Buffers provide a highly efficient and platform-neutral serialization format for serializing structured messages that services send to each other. Using a cross-platform Interface Definition Language (IDL), developers define a service contract for each microservice. The contract, implemented as a text-based ".proto" file, describes the methods, inputs, and outputs for each service.  

Using the ".proto file," the Protobuf compiler, "Protoc," generates client and service code for your target platform. The code includes the following components:

- A strongly-typed DTO (Data Transfer Object) shared by the client and service.
- A strongly-typed base class with the required network plumbing that the remote service can inherit and extend.
- A client stub that contains the required plumbing to invoke the remote service.

At runtime, each message is serialized as a standard Protobuf representation and exchanged among the client and remote services. Unlike JSON or XML, Protobuf messages are serialized as compiled binary bytes.

The book, [gRPC for WCF Developers](https://docs.microsoft.com/dotnet/architecture/grpc-for-wcf-developers/), available from the Microsoft Architecture Site, provides in depth coverage of gRPC and Protocol Buffers. 

## gRPC support in .NET

Microsoft .NET Core 3.0 includes tooling and native support for gRPC. gRPC is now seamlessly integrated into its framework with support for endpoint routing, built-in IoC, and logging. The open-source Kestrel web server fully supports HTTP/2 connections. Figure 4-20 shows a Visual Studio 2019 template that scaffolds a skeleton project for a gRPC service. Note how .NET Core fully supports the Windows, Linux, and macOS platforms.

![gRPC Support in Visual Studio 2019](./media/visual-studio-2019-grpc-template.png)

**Figure 4-20**. gRPC support in Visual Studio 2019
  
Figure 4-21 shows the structure of a simple gRPC service genreated with the built-in scaffolding from Visual Studio 2019.  

![gRPC project in Visual Studio 2019](./media/grpc-project.png  )

**Figure 4-21**. gRPC project in Visual Studio 2019

In the previous figure, note the proto description file and service code.As you'll see shortly, additional configuration is generated in both the Startup class and underlying project file.

An excellent introduction to building a gRPC service is [gRPC with ASP.NET Core 3.0](https://www.dotnetcurry.com/aspnet-core/1514/grpc-asp-net-core-3) from the .NET Curry magazine series.

## gRPC usage

Favor gRPC for the following sceaniros:

- Synchronous backend micrservice-to-microservice communication where an immediate response is required in order to continue processing.


 high-performance, compact, lightweight protocol for exchanging messages and data.


- Low latency and high throughput communication where performance is critical.
- Point-to-point real-time communication - gRPC can push messages in real time without polling and has excellent support for bi-directional streaming.
- Polyglot environments that need to support mixed programming platforms.
- Network constrained environments – gRPC messages are serialized with Protobuf, a lightweight message format. A gRPC message is always smaller than an equivalent JSON message.

At the time of this writing, gRPC is primarily found in backend services. Most modern browsers cannot provide the level of HTTP/2 control required to support a front-end gRPC client. 

## Implementation

 The [microservice reference architecture](https://github.com/dotnet-architecture/eShopOnContainers) for eShop on Containers provides guidance for implementing gRPC on the .NET Core platform. Figure 4-22 shows the implementation.
![gRPC Usage Patterns](./media/grpc-implementation.png)

**Figure 4-22**. gRPC implementation

In the previous figure, note how eShop exposes four different API gateways embracing the [Backend for Frontends pattern](https://docs.microsoft.com/azure/architecture/patterns/backends-for-frontends). The Web-Marketing gateway exposes simple CRUD operations with a RESTful. It also includes an Aggregator microservice that implements gRPC calls for complex operations that require synchronous calls to multiple backend microservices.

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


The eShop on Containers reference application provides guidance on implementing gRPC in a microservice-based application. When it comes to enterprise grade messaging with WCF and SOAP-based services, gRPC becomes a contender to consider when replatforming these systems. The programming experience is similar and the performance is compelling. gRPC is even more compelling considering that WCF is not officially supported on .NET Core.

Looking ahead, gRPC could well play a major role in dethroning the dominance of REST for cloud-native systems. The performance benefits and ease of development are compelling. However, REST will still most likely be around for a long time. It excels for publicly exposed APIs and for backward compatibility reasons.

>[!div class="step-by-step"] 
>[Previous](service-to-service-communication.md)
>[Next](service-mesh-communication-infrastructure.md)





## Extra

the glue for micro-services communication, especially when latency is a key factor. 
