---
title: Protocol Buffers - gRPC for WCF Developers
description: Introduction to the Protocol Buffers wire format used for gRPC networking.
author: markrendle
ms.date: 09/09/2019
---

# Protocol Buffers

gRPC services send and receive data as *Protocol Buffer (Protobuf) messages*, similar to WCF's data contracts. Protobuf is an efficient way of serializing structured data for machines to read and write, without the overhead that human-readable formats like XML or JSON incur.

This chapter covers how Protobuf works, and how to define your own Protobuf messages.

## How Protobuf works

Most .NET object serialization techniques, including WCF's data contracts, work by using reflection to analyze the object structure at run time. By contrast, most Protobuf libraries require you to define the structure up front using a dedicated language (*Protocol Buffer Language*) in a `.proto` file. This file is then used by a compiler to generate code for any of the supported platforms, including .NET, Java, C/C++, JavaScript, and many more. The Protobuf compiler, `protoc`, is maintained by Google, although alternative implementations are available. The generated code is efficient and optimized for fast serialization and deserialization of data.

The Protobuf wire format itself is a binary encoding, which uses some clever tricks to minimize the number of bytes used to represent messages. Knowledge of the binary encoding format isn't necessary to use Protobuf, but if you're interested you can learn more about it on [the Protocol Buffers web site](https://developers.google.com/protocol-buffers/docs/encoding).

>[!div class="step-by-step"]
<!-->[Next](protobuf-messages.md)-->
