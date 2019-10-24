---
title: How gRPC approaches RPC - gRPC for WCF Developers
description: Comparing the key features of WCF to gRPC.
author: markrendle
ms.date: 09/02/2019
---

# How gRPC approaches RPC

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Windows Communication Foundation (WCF) and gRPC are both implementations of the *Remote Procedure Call* (RPC) pattern, which aims to make calls to services running on a different machine, or in a different process, seamlessly work as though they were just method calls in the client application. While the aims of WCF and gRPC are the same, the details of the implementation are quite different.

The following table sets out how the key features of WCF relate to gRPC and where you can find more detailed explanations in the rest of the book.

| Features | WCF | gRPC |
| -------- | --- | ---- |
| Objective | Separate business code from networking implementation | Separate business code from interface definition and networking implementation |
| Define Services and messages (chapter 3-4)  | Service Contract, Operation Contract, and Data Contract | Uses proto file to declare services and messages |
| Language (chapter 3-5) | Contracts written in C# or Visual Basic | Protocol Buffer language |
| Wire format (chapter 3) | Configurable, including SOAP/XML, Plain XML, JSON, .NET Binary, and so on. | Protocol Buffer binary format (although it's possible to use other formats).
| Interoperability (chapter 4) | When using SOAP over HTTP | Official support: .NET, Java, Python, JavaScript, C/C++, Go, Rust, Ruby, Swift, Dart, PHP. Unofficial support for other languages from the community. |
| Networking (chapter 4) | Configured at runtime. Switch between NetTCP, HTTP, MSMQ, and so on. | HTTP/2, currently over TCP only with ASP.NET Core gRPC. |
| Approach (chapter 4) | Runtime generation of serialization /deserialization and networking code in base classes | Build-time generation of serialization /deserialization and networking code in base classes |
| Security (chapter 6) | Authentication, WS-Security, message encryption | Credentials, ASP.NET Core security, TLS networking |

>[!div class="step-by-step"]
>[Previous](grpc-overview.md)
>[Next](interface-definition-language.md)
