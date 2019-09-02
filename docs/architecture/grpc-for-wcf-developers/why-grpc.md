---
title: Why gRPC is recommended for WCF developers
description: gRPC for WCF Developers | Why gRPC is recommended for WCF developers
author: markrendle
ms.date: 09/02/2019
---

# Why gRPC is recommended for WCF developers

Before diving deeply into the language and techniques of gRPC it is worth pulling together some ideas about why, given there are alternatives available, gRPC is the right solution for WCF developers who want to migrate to .NetCore.

[Mark to provide text about similarities]

## Benefits of gRPC

Additional reasons why gRPC stands above other solutions are:

### Performance

As already discussed, using HTTP/2 rather than HTTP/1 removes the requirement for human-readability code and instead use the smaller faster binary protocol. This is more efficient for computers to parse. HTTP/2 also supports multiplexing requests over a single connection enabling responses to be sent as soon as they are ready without the need to wait in a queue.  Fewer resources are needed when using gRPC which makes it a good solution to use for mobile devices and over slower networks. [Mark to check]

### Simplicity and Productivity

gRPC is a comprehensive RPC solution. It has thoroughly addressed the full range of connectivity issues. gRPC works consistently across multiple languages. gRPC is simple with much of the boilerplate auto-generated. Therefore more developer time is freed up to focus on Business Logic.

Streaming – gRPC has full bi-directional streaming, which is very similar to WCF's Full Duplex services but without the dependency on complicated network bindings and transports. gRPC streaming can operate over regular internet connections, load balancers and service meshes.

Security. HTTP/2 is a fundamentally more secure transport method than HTTP/1. SSL/TLS encrypted connections are required by the protocol, removing the need for complex encryption configuration at the service level.

>[!div class="step-by-step"]
<!-->[Next](protocol-buffers.md)-->
