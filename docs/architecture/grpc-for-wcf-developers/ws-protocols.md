---
title: WS-* protocols - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# WS-* protocols

One of the real benefits of working with WCF was that it supported many of the existing so-called WS-* standard protocols. In this section, we will briefly cover how these same WS-* protocols are managed in gRPC and, where there is no alternative, discuss what options are available.

## Metadata Exchange - WS-Policy, WS-Discovery, etc

SOAP services expose Web Services Description Language (WSDL) schema documents with information about data formats, operations, communication options etc. This could be used to generate Client code.

gRPC works best when servers and clients are generated from the same `.proto` files, but a server reflection optional extension does provide a way to expose dynamic information from a running server. See the [Grpc.Reflection Nuget package](https://nuget.org/packages/Grpc.Reflection) and [the documentation](https://github.com/grpc/grpc/blob/master/doc/csharp/server_reflection.md)

## Security – WS-Security, WS-Federation, XML Encryption, etc

We will cover security, authentication and authorization in much more detail in Chapter 6. But it is worth noting here that, unlike WCF, gRPC does not support WS-Security, WS Federation, or XML Encryption. Even so, gRPC offers greater security than WCF because all gRPC communications are automatically encrypted because of HTTP/2 TLS, and can use X509 certificates for mutual client/server authentication.

## WS-ReliableMessaging

gRPC transport provides similar guarantees to WCF Reliable Sessions without any need for additional configuration or code.

## WS-Transaction, WS-Coordination

WCF’s implementation of distributed transactions uses Windows’ Microsoft Distributed Transaction Coordinator or MSDTC. It works with resource managers that specifically support it, like SQL Server, MSMQ, Windows file systems, etc. In the modern, open, cross-platform microservices world there is no equivalent. See Appendix A for a discussion of transactions.


>[!div class="step-by-step"]
<!-->[Next](migrating-wcf-to-grpc.md)-->
