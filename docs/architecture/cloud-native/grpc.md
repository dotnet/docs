---
title: HTTP REST and gRPC
description: Learn about gRPC, its role in cloud-native applications and how it differs from HTTP REST
author: robvet
ms.date: 09/04/2019
---

# REST and gRPC

So far in this book, we’ve focused on [REST-based](https://docs.microsoft.com/azure/architecture/best-practices/api-design) communication. It's flexible architectural style for service design has been the defacto standard for cloud-native applications. A newer communication technology, entitled gRPC, however, is rapidly gaining popularity and making its way into the cloud-native world.

## REST

REST, which uses HTTP 1.1 as its transport protocol, defines a set of conventions that promote interoperability between distributed computer systems across the web. REST exposes application state as *resources*, which typically represent application entities, such as customers, products, or orders. Clients interact with representations of these resources across HTTP, embracing HTTP URLs, status codes, headers, and verbs. A fully qualified HTTP URL identifies a particular resource while the HTTP verbs perform operations against it. The verbs map to database [CRUD operations that are shown in the following table: 

|  HTTP Verb | Database Operation | Behavior |
| :--------: | :--------: | :-------- |
| GET | Select | Retrieve a resource |
| POST | Insert |  Store a resource |
| PUT | Update | Update a resource |
| PATCH | Update | Partially update a resource |
| DELETE | Delete | Remove a resource  |

While simple and widely used, REST does present challenges. One is the limited number of available HTTP verbs. This can become challenging when designing microservices that support multiple insert and update operations. Equally problematic is the fact that REST transmits raw text over the wire. 

## gRPC

gRPC, which stands for “Google Remote Procedure Call," is built upon the time-enduring [remote procedure call (RPC)](https://en.wikipedia.org/wiki/Remote_procedure_call) model, popular in distributed computing. A local client program exposes what appears to be an in-process method to complete an operation. Under-the-hood, an out-of-process network call is made to a microservice to execute the actual code. To the developer, it appears the method is executed on the client. The RPC platform abstracts the point-to-point networking communication, serialization, and execution.

gRPC is a binary message-based protocol. At the lowest level, it uses HTTP/2 for its transport protocol. Unlike HTTP 1.1, which requires each message to be returned in full in the order requested, HTTP/2 features multiplexing capabilities. It can support many parallel requests over the same connection. It also supports bidirectional communication where both client and server and can communicate at the same time. The client can be uploading request data at the same time the server is sending back response data. Streaming is built into HTTP/2 meaning that both requests and responses can send huge amounts of information. support streaming. gRPC is open source and supported across most popular platforms, including Java, C#, Golang and NodeJS. 

## Protocol Buffers

gRPC embraces an open-source technology called [Protocol Buffers](https://developers.google.com/protocol-buffers/docs/overview) to define and serialize structured data communicated across services. Protocol Buffers can also be used to generate client stubs that can invoke the services. RESTFul messages must be serialized and deserialized on both the client and server side. With gRPC, each message is wrapped in a strongly-typed service contract and serialized in a standard Protobuf representation.

## gRPC support in .NET


## Usage

At the time, of the writing of this book, most browsers have limited support for gRPC. Instead, gRPC is typically used for internal microservice to microservice communication. Figure x.x shows usage.

[Place figure here that shows external calls with HTTP and internal calls with gRPC]

In the world of cloud-native applications, gRPC could well play a major role. The performance benefits and ease of development are too good to pass up. However, make no mistake, REST will still be around for a long time. It still excels for publicly exposed APIs and for backward compatibility reasons. 




## OLD

gRPC works with Protobuf messages that are strongly typed and serialized in a binary format. gRPC is built upon HTTP/2. HTTP/2 protocol is binary. It uses multiplexed streams that means that multiple requests can be sent at the same time without the need to establish TCP connections for each. gRPC lets *stream* information both from the client, server, and bidirectionally. 

Protocol buffers are a flexible, efficient, automated mechanism for serializing structured data – think XML, but smaller, faster, and simpler. You define how you want your data to be structured once, then you can use special generated source code to easily write and read your structured data to and from a variety of data streams and using a variety of languages. You can even update your data structure without breaking deployed programs that are compiled against the "old" format.

It excels at providing high performance and ease of use, to greatly simplify the construction of all types of distributed systems.





>[!div class="step-by-step"]
>[Previous](other-deployment-options.md)
>[Next](front-end-communication.md)
