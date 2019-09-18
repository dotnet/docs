---
title: WS-* protocols - gRPC for WCF Developers
description: Review of the WS-* protocols supported by WCF and alternatives available with gRPC
author: markrendle
ms.date: 09/02/2019
---

# WS-\* protocols

One of the real benefits of working with Windows Communication Foundation (WCF) was that it supported many of the existing _WS-\*_ standard protocols. This section will briefly cover how gRPC manages the same WS-\* protocols and discuss what options are available when there's no alternative.

## Metadata Exchange - WS-Policy, WS-Discovery, and so on

SOAP services expose Web Services Description Language (WSDL) schema documents with information such as data formats, operations, or communication options. This schema could be used to generate the client code.

gRPC works best when servers and clients are generated from the same `.proto` files, but a server reflection optional extension does provide a way to expose dynamic information from a running server. For more information, see the [Grpc.Reflection](https://nuget.org/packages/Grpc.Reflection) NuGet package and the [gRPC C# Server Reflection](https://github.com/grpc/grpc/blob/master/doc/csharp/server_reflection.md) article.

## Security – WS-Security, WS-Federation, XML Encryption, and so on

Security, authentication, and authorization are covered in much more detail in [Chapter 6](authentication.md). But it's worth noting here that, unlike WCF, gRPC doesn't support WS-Security, WS Federation, or XML Encryption. Even so, gRPC offers greater security than WCF because all gRPC communications are automatically encrypted because of HTTP/2 TLS, and can use X509 certificates for mutual client/server authentication.

## WS-ReliableMessaging

gRPC transport provides similar guarantees to WCF Reliable Sessions without any need for additional configuration or code.

## WS-Transaction, WS-Coordination

WCF’s implementation of distributed transactions uses Windows’ Microsoft Distributed Transaction Coordinator or MSDTC. It works with resource managers that specifically support it, like SQL Server, MSMQ, or Windows file systems. In the modern, open, cross-platform microservices world, there's no equivalent. For a discussion of transactions, see [Appendix A](appendix.md).

>[!div class="step-by-step"]
<!-->[Next](migrating-wcf-to-grpc.md)-->
