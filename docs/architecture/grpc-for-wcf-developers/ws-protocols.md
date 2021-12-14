---
title: WS-* protocols - gRPC for WCF developers
description: Review of the WS-* protocols supported by WCF and alternatives available with gRPC
author: markrendle
ms.date: 12/14/2021
---

# WS-\* protocols

One of the real benefits of working with Windows Communication Foundation (WCF) was that it supported many of the existing _WS-\*_ standard protocols. This section will briefly cover how gRPC manages the same WS-\* protocols and discuss what options are available when there's no alternative.

## Metadata exchange: WS-Policy, WS-Discovery, and so on

SOAP services expose Web Services Description Language (WSDL) schema documents with information such as data formats, operations, or communication options. You can use this schema to generate the client code.

gRPC works best when servers and clients are generated from the same `.proto` files, but a Server Reflection optional extension does provide a way to expose dynamic information from a running server. For more information, see the [Grpc.Reflection](https://nuget.org/packages/Grpc.Reflection) NuGet package and the [gRPC C# Server Reflection](https://github.com/grpc/grpc/blob/master/doc/csharp/server_reflection.md) article.

The WS-Discovery protocol is used to locate services on a local network. gRPC services are located through DNS or a service registry such as Consul or ZooKeeper.

## Security: WS-Security, WS-Federation, XML Encryption, and so on

Security, authentication, and authorization are covered in much more detail in [chapter 6](security.md). But it's worth noting here that, unlike WCF, gRPC doesn't support WS-Security, WS-Federation, or XML Encryption. Even so, gRPC provides excellent security. All gRPC network traffic is automatically encrypted when it's using HTTP/2 over TLS. You can use X509 certificates for mutual client/server authentication.

## WS-ReliableMessaging

gRPC does not provide an equivalent to WS-ReliableMessaging. Retry semantics should be handled in code, possibly with a library like [Polly](https://github.com/App-vNext/Polly). When you're running in Kubernetes or similar orchestration environments, [service meshes](service-mesh.md) can also help to provide reliable messaging between services.

## WS-Transaction, WS-Coordination

WCF's implementation of distributed transactions uses Microsoft Distributed Transaction Coordinator (MSDTC). It works with resource managers that specifically support it, like SQL Server, MSMQ, or Windows file systems. There's no equivalent yet in the modern microservices world, in part due to the wider range of technologies in use. For a discussion of transactions, see [Appendix A](appendix.md).

>[!div class="step-by-step"]
>[Previous](error-handling.md)
>[Next](migrate-wcf-to-grpc.md)
