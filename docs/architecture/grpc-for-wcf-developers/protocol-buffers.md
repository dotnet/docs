---
title: Protocol Buffers - gRPC for WCF developers
description: Introduction to the Protocol Buffers wire format used for gRPC networking.
ms.date: 09/09/2019
---

# Protocol buffers

gRPC services send and receive data as *Protocol Buffer (Protobuf) messages*, similar to data contracts in Windows Communication Foundation (WCF). Protobuf is an efficient way of serializing structured data for machines to read and write, without the overhead that human-readable formats like XML or JSON incur.

This chapter covers how Protobuf works, and how to define your own Protobuf messages.

## How Protobuf works

Most .NET object serialization techniques, including WCF's data contracts, work by using reflection to analyze the object structure at run time. By contrast, most Protobuf libraries require you to define the structure up front by using a dedicated language (*Protocol Buffer Language*) in a `.proto` file. A compiler then uses this file to generate code for any of the supported platforms. Supported platforms include .NET, Java, C/C++, JavaScript, and many more.

The Protobuf compiler, `protoc`, is maintained by Google, although alternative implementations are available. The generated code is efficient and optimized for fast serialization and deserialization of data.

The Protobuf wire format is a binary encoding. It uses some clever tricks to minimize the number of bytes used to represent messages. Knowledge of the binary encoding format isn't necessary to use Protobuf. But if you're interested, you can learn more about it on [the Protocol Buffers website](https://developers.google.com/protocol-buffers/docs/encoding).

>[!div class="step-by-step"]
>[Previous](why-grpc.md)
>[Next](protobuf-messages.md)
