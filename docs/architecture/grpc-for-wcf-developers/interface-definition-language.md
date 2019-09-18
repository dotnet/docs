---
title: Interface Definition Language - gRPC for WCF Developers
description: Introducing the Protocol Buffers IDL.
author: markrendle
ms.date: 09/02/2019
---

# Interface Definition Language

With WCF, services can expose description metadata using the Web Service Definition Language (WSDL), which is generated dynamically using .NET Reflection at runtime. Developers can use this metadata to generate clients for those services, potentially in other languages if a platform-neutral binding such as SOAP over HTTP is used.

gRPC uses the Interface Definition Language (IDL) from Protocol Buffers. The Protocol Buffers IDL is a custom, platform-neutral language with an open specification. Developers hand-code `.proto` files to describe services along with their inputs and outputs. These `.proto` files can then be used to generate language- or platform-specific stubs for clients and servers, allowing multiple different platforms to communicate. By sharing `.proto` files, teams can generate code to use each others' services without needing to take a code dependency.

One of the advantages of the Protobuf IDL is that as a custom language it enables gRPC to be completely language and platform agnostic, not favoring any technology over another.

The Protobuf IDL is also much easier for humans to both read and write than WSDL. Changing the WSDL of a WCF service typically requires making the changes to the service code itself, running the service and regenerating the WSDL file from the server. By contrast, with a `.proto` file, changes are simple to apply and automatically flow through the generated code. Visual Studio 2019 builds `.proto` files in the background when they are saved; when using other editors such as VS Code the changes will be applied when the project is built.

When compared with XML, messages encoded using Protobuf have many advantages:

- They can be up to 10x smaller.
- Encoding, decoding and transmitting can be up to 100x faster.
- Simpler and less ambiguous.
- The generated data access classes are easier to use programmatically.

The potential disadvantage of Protobuf is that, because the messages are not human readable, additional tooling is required to debug message content.

> [!TIP]
> gRPC *does* support server reflection for dynamically accessing services without pre-compiled stubs, although it is intended more for general-purpose tools than application-specific clients. [Find more information about gRPC Server Reflection on GitHub.](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md)

>[!div class="step-by-step"]
<!-->[Next](network-protocols.md)-->
