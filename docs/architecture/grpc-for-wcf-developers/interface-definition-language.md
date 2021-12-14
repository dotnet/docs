---
title: Interface Definition Language - gRPC for WCF Developers
description: Introducing the Protocol Buffers IDL.
ms.date: 12/14/2021
---

# Interface Definition Language

With Windows Communication Foundation (WCF), services can expose description metadata by using the Web Service Definition Language (WSDL). WSDL is generated dynamically by using .NET reflection at run time. Developers can use this metadata to generate clients for those services, potentially in other languages if they're using a platform-neutral binding such as SOAP over HTTP.

gRPC uses the Interface Definition Language (IDL) from Protocol Buffers. The Protocol Buffers IDL is a custom, platform-neutral language with an open specification. Developers author `.proto` files to describe services, along with their inputs and outputs. These `.proto` files can then be used to generate language- or platform-specific stubs for clients and servers, allowing multiple different platforms to communicate. By sharing `.proto` files, teams can generate code to use each others' services, without needing to take a code dependency.

One of the advantages of the Protobuf IDL is that as a custom language, it enables gRPC to be completely language and platform agnostic, not favoring any technology over another.

The Protobuf IDL is also designed for humans to both read and write, whereas WSDL is intended as a machine-readable/writable format. Changing the WSDL of a WCF service typically requires changing the service, running the service, and regenerating the WSDL file from the server. By contrast, with a `.proto` file, changes are simple to apply with a text editor, and automatically flow through the generated code. Visual Studio 2022 builds `.proto` files in the background when they are saved. With other editors, such as VS Code, the changes are applied when the project is built.

When compared with XML, and particularly SOAP, messages encoded by using Protobuf have many advantages. Protobuf messages tend to be smaller than the same data serialized as SOAP XML, and encoding, decoding, and transmitting them over a network can be faster.

The potential disadvantage of Protobuf compared to SOAP is that, because the messages aren't readable by humans, additional tooling is required to debug message content.

> [!TIP]
> gRPC *does* support server reflection for dynamically accessing services without pre-compiled stubs, although it's intended more for general-purpose tools than application-specific clients. For more information, see [GRPC Server Reflection Protocol](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md) on GitHub.

> [!NOTE]
> WCF's binary format, used with the NetTCP binding, is much closer to Protobuf in terms of compactness and performance. But NetTCP is only usable between .NET clients and servers, whereas Protobuf is a cross-platform solution.

>[!div class="step-by-step"]
>[Previous](approach.md)
>[Next](network-protocols.md)
