---
title: WS-* protocols - gRPC for WCF Developers
description: Review of the WS-* protocols supported by WCF and alternatives available with gRPC
author: markrendle
ms.date: 09/02/2019
---

# WS-\* protocols

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

One of the real benefits of working with Windows Communication Foundation (WCF) was that it supported many of the existing _WS-\*_ standard protocols. This section will briefly cover how gRPC manages the same WS-\* protocols and discuss what options are available when there's no alternative.

## Metadata Exchange - WS-Policy, WS-Discovery, and so on

SOAP services expose Web Services Description Language (WSDL) schema documents with information such as data formats, operations, or communication options. This schema could be used to generate the client code.

gRPC works best when servers and clients are generated from the same `.proto` files, but a server reflection optional extension does provide a way to expose dynamic information from a running server. For more information, see the [Grpc.Reflection](https://nuget.org/packages/Grpc.Reflection) NuGet package and the [gRPC C# Server Reflection](https://github.com/grpc/grpc/blob/master/doc/csharp/server_reflection.md) article.

The WS-Discovery protocol is used to locate services on a local network. gRPC services are generally located using DNS or a service registry such as Consul or ZooKeeper.

## Security – WS-Security, WS-Federation, XML Encryption, and so on

Security, authentication, and authorization are covered in much more detail in [Chapter 6](authentication.md). But it's worth noting here that, unlike WCF, gRPC doesn't support WS-Security, WS Federation, or XML Encryption. Even so, gRPC provides excellent security; all gRPC network traffic is automatically encrypted when using HTTP/2 over TLS, and X509 certificates may be used for mutual client/server authentication.

## WS-ReliableMessaging

gRPC does not provide an equivalent to WS-ReliableMessaging. Retry semantics should be handled in code, possibly with a library like [Polly](https://github.com/App-vNext/Polly). When running in Kubernetes or similar orchestration environments, [service meshes](service-mesh.md) can also help to provide reliable messaging between services.

## WS-Transaction, WS-Coordination

WCF’s implementation of distributed transactions uses Windows’ Microsoft Distributed Transaction Coordinator or MSDTC. It works with resource managers that specifically support it, like SQL Server, MSMQ, or Windows file systems. In the modern microservices world, in part due to the wider range of technologies in use, there is no equivalent as yet. For a discussion of transactions, see [Appendix A](appendix.md).

>[!div class="step-by-step"]
<!-->[Next](migrating-wcf-to-grpc.md)-->
