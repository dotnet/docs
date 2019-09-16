---
title: How gRPC approaches RPC - gRPC for WCF Developers
description: Comparing the key features of WCF to gRPC.
author: markrendle
ms.date: 09/02/2019
---

# How gRPC approaches RPC

The following table sets out how the key features of WCF relate to gRPC and where you can find more detailed explanations in the rest of the book.

| Features | WCF | gRPC |
| -------- | --- | ---- |
| Objective | Separate business code from networking implementation | Separate business code from interface definition and networking implementation |
| Define Services and messages (chapter 3-4)  | Service Contract, Operation Contract, and Data Contract | Uses proto file |
| Language (chapter 3-5) | Contracts written in C# or VB.NET | Custom Interface Definition Language |
| Wire format (chapter 3) | Configurable, including SOAP/XML, Plain XML, JSON, .NET Binary, and so on. | Protocol Buffers (although it's possible to use other formats).
| Interoperability (chapter 4) | When using SOAP over HTTP | Official support: .NET, Java, Python, JavaScript, C/C++, Go, Rust, Ruby, Swift, Dart, PHP. Unofficial support for other languages from the community. |
| Networking (chapter 4) | Configured at runtime. Switch between TCP, HTTP, MSMQ, and so on. | Always HTTP/2 |
| Approach (chapter 4) | Runtime generation of serialization /deserialization and networking code in base classes | Build-time generation of serialization /deserialization and networking code in base classes |
| Security (chapter 6) | Authentication, WS-Security, message encryption | Credentials, ASP.NET Core security, SSL/TLS networking |

>[!div class="step-by-step"]
<!-->[Next](interface-definition-language.md)-->
